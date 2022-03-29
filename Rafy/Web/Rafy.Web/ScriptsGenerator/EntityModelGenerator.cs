﻿/*******************************************************
 * 
 * 作者：胡庆访
 * 创建时间：20120220
 * 说明：此文件只包含一个类，具体内容见类型注释。
 * 运行环境：.NET 4.0
 * 版本号：1.0.0
 * 
 * 历史记录：
 * 创建文件 胡庆访 20120220
 * 
*******************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.CodeDom.Compiler;
using System.IO;
using Rafy.MetaModel;
using Rafy.Web.ClientMetaModel;
using Rafy.ManagedProperty;
using Rafy.Web.EntityDataPortal;
using Rafy.Domain;

namespace Rafy.Web
{
    /// <summary>
    /// 实体定义脚本的生成器
    /// </summary>
    internal class EntityModelGenerator
    {
        private EntityModel _entityModel;

        internal EntityMeta EntityMeta { get; set; }

        internal EntityModel Generate()
        {
            _entityModel = new EntityModel();
            _entityModel.isTree = this.EntityMeta.IsTreeEntity;

            this.WriteFields();

            //以下代码与 EXTJS 5 有冲突。
            this.WriteReference();

            this.WriteChildren();

            this.WriteTreeAssociations();

            return _entityModel;
        }

        private void WriteFields()
        {
            var properties = this.EntityMeta.EntityProperties;
            for (int i = 0, c = properties.Count; i < c; i++)
            {
                var property = properties[i];
                var mp = property.ManagedProperty;

                //只为树状实体输出以下两个属性。
                if (mp == Entity.TreePIdProperty || mp == Entity.TreeIndexProperty)
                {
                    if (!_entityModel.isTree)
                    {
                        continue;
                    }
                }

                //引用属性在客户端输出一个引用 Id 属性和一个 Display 属性，而引用实体属性不显示在客户端。
                if (mp is IRefEntityProperty) continue;

                var propertyType = mp.PropertyType;
                var refIdProperty = mp as IRefIdProperty;
                if (refIdProperty != null)
                {
                    propertyType = refIdProperty.KeyProvider.KeyType;
                }
                else if (mp == Entity.TreePIdProperty)
                {
                    propertyType = this.EntityMeta.IdType;
                }

                var serverType = ServerTypeHelper.GetServerType(propertyType);
                if (serverType.Name == SupportedServerType.Unknown) { continue; }

                var pName = property.Name;
                var field = new EntityField
                {
                    name = pName,
                    type = serverType,
                    persist = property.Runtime.CanWrite,
                };
                _entityModel.fields.Add(field);

                if (mp is IRefIdProperty)
                {
                    //由于 Id 不能用于显示，所以为引用属性添加一个纯视图属性，用于显示。
                    field = new EntityField
                    {
                        name = DisplayRefProperty(refIdProperty),
                        type = ServerTypeHelper.GetServerType(typeof(string)),
                        persist = false,
                    };
                    _entityModel.fields.Add(field);
                }
                else
                {
                    var v = mp.GetMeta(this.EntityMeta.EntityType).DefaultValue;
                    field.defaultValue = EntityJsonConverter.ToClientValue(property.PropertyType, v);
                }
            }
        }

        private void WriteReference()
        {
            var properties = this.EntityMeta.EntityProperties;
            for (int i = 0, c = properties.Count; i < c; i++)
            {
                var property = properties[i];
                var refProperty = property.ManagedProperty as IRefEntityProperty;
                if (refProperty != null)
                {
                    var association = new BelongsToAssociation
                    {
                        associationKey = refProperty.RefEntityProperty.Name,
                        foreignKey = refProperty.RefIdProperty.Name,
                        model = ClientEntities.GetClientName(refProperty.RefEntityType),
                    };

                    _entityModel.associations.Add(association);
                }
            }
        }

        private void WriteChildren()
        {
            var em = this.EntityMeta;
            var children = em.ChildrenProperties;
            for (int i = 0, c = children.Count; i < c; i++)
            {
                var child = children[i];

                var listProperty = child.ManagedProperty as IListProperty;
                if (listProperty.HasManyType == HasManyType.Composition)
                {
                    var pRefMeta = child.ChildType.FindParentReferenceProperty();
                    if (pRefMeta != null)
                    {
                        var childType = child.ChildType.EntityType;
                        var association = new HasManyAssociation
                        {
                            name = child.Name,
                            foreignKey = (pRefMeta.ManagedProperty as IRefProperty).RefIdProperty.Name,
                            model = ClientEntities.GetClientName(childType),
                        };
                        _entityModel.associations.Add(association);
                    }
                }
            }
        }

        private void WriteTreeAssociations()
        {
            var supportTree = this.EntityMeta.IsTreeEntity;

            if (supportTree)
            {
                foreach (var property in this.EntityMeta.EntityProperties)
                {
                    if (property.ManagedProperty == Entity.TreePIdProperty)
                    {
                        _entityModel.associations.Add(new BelongsToAssociation
                        {
                            associationKey = "TreeParent",
                            foreignKey = property.Name,
                            model = ClientEntities.GetClientName(this.EntityMeta.EntityType),
                        });
                        _entityModel.associations.Add(new HasManyAssociation
                        {
                            name = "TreeChildren",
                            foreignKey = property.Name,
                            model = ClientEntities.GetClientName(this.EntityMeta.EntityType),
                        });

                        break;
                    }
                }
            }
        }

        internal static string DisplayRefProperty(IRefProperty refProperty)
        {
            return refProperty.RefEntityProperty.Name + "_Display";
        }
    }
}
