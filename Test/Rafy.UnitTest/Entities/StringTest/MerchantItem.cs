using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Permissions;
using System.Text;
using Rafy;
using Rafy.Data;
using Rafy.Domain;
using Rafy.Domain.ORM;
using Rafy.Domain.ORM.Query;
using Rafy.Domain.Validation;
using Rafy.ManagedProperty;
using Rafy.MetaModel;
using Rafy.MetaModel.Attributes;
using Rafy.MetaModel.View;

namespace UT
{
    /// <summary>
    /// 商人的房产
    /// </summary>
    [ChildEntity]
    public partial class MerchantItem : StringTestIntEntity
    {
        #region 引用属性

        public static readonly Property<string> HouseMerchantIdProperty =
            P<MerchantItem>.Register(e => e.HouseMerchantId);
        public string HouseMerchantId
        {
            get { return this.GetProperty(HouseMerchantIdProperty); }
            set { this.SetProperty(HouseMerchantIdProperty, value); }
        }
        public static readonly RefEntityProperty<HouseMerchant> HouseMerchantProperty =
            P<MerchantItem>.RegisterRef(e => e.HouseMerchant, HouseMerchantIdProperty, ReferenceType.Parent);
        public HouseMerchant HouseMerchant
        {
            get { return this.GetRefEntity(HouseMerchantProperty); }
            set { this.SetRefEntity(HouseMerchantProperty, value); }
        }

        public static readonly Property<string> HouseIdProperty =
            P<MerchantItem>.Register(e => e.HouseId);
        public string HouseId
        {
            get { return this.GetProperty(HouseIdProperty); }
            set { this.SetProperty(HouseIdProperty, value); }
        }
        public static readonly RefEntityProperty<House> HouseProperty =
            P<MerchantItem>.RegisterRef(e => e.House, HouseIdProperty);
        public House House
        {
            get { return this.GetRefEntity(HouseProperty); }
            set { this.SetRefEntity(HouseProperty, value); }
        }

        #endregion

        #region 组合子属性

        #endregion

        #region 一般属性

        public static readonly Property<string> NameProperty = P<MerchantItem>.Register(e => e.Name);
        public string Name
        {
            get { return this.GetProperty(NameProperty); }
            set { this.SetProperty(NameProperty, value); }
        }

        #endregion

        #region 只读属性

        public static readonly Property<string> RD_MerchantNameProperty = P<MerchantItem>.Register(e => e.RD_MerchantName);
        public string RD_MerchantName
        {
            get { return this.GetProperty(RD_MerchantNameProperty); }
        }

        #endregion
    }

    /// <summary>
    /// 商人的房产 列表类。
    /// </summary>
    public partial class MerchantItemList : StringTestEntityList { }

    /// <summary>
    /// 商人的房产 仓库类。
    /// 负责 商人的房产 类的查询、保存。
    /// </summary>
    public partial class MerchantItemRepository : StringTestEntityRepository
    {
        /// <summary>
        /// 单例模式，外界不可以直接构造本对象。
        /// </summary>
        protected MerchantItemRepository() { }
    }

    /// <summary>
    /// 商人的房产 配置类。
    /// 负责 商人的房产 类的实体元数据的配置。
    /// </summary>
    internal class MerchantItemConfig : StringTestEntityConfig<MerchantItem>
    {
        /// <summary>
        /// 配置实体的元数据
        /// </summary>
        protected override void ConfigMeta()
        {
            //配置实体的所有属性都映射到数据表中。
            Meta.MapTable().MapAllProperties();
            MapRefValue(MerchantItem.RD_MerchantNameProperty, e => e.HouseMerchant.Name, ReferenceValueDataMode.Redundancy);
        }
    }
}