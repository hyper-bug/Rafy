//------------------------------------------------------------------------------
// <auto-generated>
//     本文件代码自动生成。用于实现强类型接口，方便应用层使用。
//     版本号:1.4.0
//
//     请勿修改，否则在重新生成时，所有修改会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Rafy;
using Rafy.ComponentModel;
using Rafy.Data;
using Rafy.Domain;
using Rafy.Domain.ORM;
using UT;

namespace Rafy.UnitTest.Repository
{

    partial class CarRepository
    {
        #region 私有方法，本类内部使用

        /// <summary>
        /// 创建一个实体类的 Linq 查询器
        /// </summary>
        /// <returns></returns>
        [DebuggerStepThrough]
        private IQueryable<Car> CreateLinqQuery()
        {
            return base.CreateLinqQuery<Car>();
        }

        #endregion

        #region 强类型公有接口

        /// <summary>
        /// 创建一个新的实体。
        /// </summary>
        /// <returns></returns>
        [DebuggerStepThrough]
        public new Car New()
        {
            return base.New() as Car;
        }

        /// <summary>
        /// 创建一个全新的列表
        /// </summary>
        /// <returns></returns>
        [DebuggerStepThrough]
        public new CarList NewList()
        {
            return base.NewList() as CarList;
        }

        /// <summary>
        /// 优先使用缓存中的数据来通过 Id 获取指定的实体对象
        /// 
        /// 如果该实体的缓存没有打开，则本方法会直接调用 GetById 并返回结果。
        /// 如果缓存中没有这些数据，则本方法同时会把数据缓存起来。
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [DebuggerStepThrough]
        public new Car CacheById(object id)
        {
            return base.CacheById(id) as Car;
        }

        /// <summary>
        /// 优先使用缓存中的数据来查询所有的实体类
        /// 
        /// 如果该实体的缓存没有打开，则本方法会直接调用 GetAll 并返回结果。
        /// 如果缓存中没有这些数据，则本方法同时会把数据缓存起来。
        /// </summary>
        /// <returns></returns>
        [DebuggerStepThrough]
        public new CarList CacheAll()
        {
            return base.CacheAll() as CarList;
        }

        /// <summary>
        /// 通过Id在数据层中查询指定的对象
        /// </summary>
        /// <param name="id"></param>
        /// <param name="loadOptions">数据加载时选项（贪婪加载等）。</param>
        /// <returns></returns>
        [DebuggerStepThrough]
        public new Car GetById(object id, LoadOptions loadOptions = null)
        {
            return base.GetById(id, loadOptions) as Car;
        }

        /// <summary>
        /// 查询第一个实体类
        /// </summary>
        /// <param name="loadOptions">数据加载时选项（贪婪加载等）。</param>
        /// <returns></returns>
        [DebuggerStepThrough]
        public new Car GetFirst(LoadOptions loadOptions = null)
        {
            return base.GetFirst(loadOptions) as Car;
        }

        /// <summary>
        /// 分页查询所有的实体类
        /// </summary>
        /// <param name="paging"></param>
        /// <param name="loadOptions">数据加载时选项（贪婪加载等）。</param>
        /// <returns></returns>
        [DebuggerStepThrough]
        public new CarList GetAll(PagingInfo paging = null, LoadOptions loadOptions = null)
        {
            return base.GetAll(paging, loadOptions) as CarList;
        }

        /// <summary>
        /// 获取指定 id 集合的实体列表。
        /// </summary>
        /// <param name="idList"></param>
        /// <param name="loadOptions">数据加载时选项（贪婪加载等）。</param>
        /// <returns></returns>
        [DebuggerStepThrough]
        public new CarList GetByIdList(object[] idList, LoadOptions loadOptions = null)
        {
            return base.GetByIdList(idList, loadOptions) as CarList;
        }

        /// <summary>
        /// 通过组合父对象的 Id 列表，查找所有的组合子对象的集合。
        /// </summary>
        /// <param name="parentIdList"></param>
        /// <param name="paging">分页信息。</param>
        /// <param name="loadOptions">数据加载时选项（贪婪加载等）。</param>
        /// <returns></returns>
        [DebuggerStepThrough]
        public new CarList GetByParentIdList(object[] parentIdList, PagingInfo paging = null, LoadOptions loadOptions = null)
        {
            return base.GetByParentIdList(parentIdList, paging, loadOptions) as CarList;
        }

        /// <summary>
        /// 通过父对象 Id 分页查询子对象的集合。
        /// </summary>
        /// <param name="parentId"></param>
        /// <param name="paging">分页信息。</param>
        /// <param name="loadOptions">数据加载时选项（贪婪加载等）。</param>
        /// <returns></returns>
        [DebuggerStepThrough]
        public new CarList GetByParentId(object parentId, PagingInfo paging = null, LoadOptions loadOptions = null)
        {
            return base.GetByParentId(parentId, paging, loadOptions) as CarList;
        }
    
        /// <summary>
        /// 通过 CommonQueryCriteria 来查询实体列表。
        /// </summary>
        /// <param name="criteria">常用查询条件。</param>
        /// <returns></returns>
        [DebuggerStepThrough]
        public new CarList GetBy(CommonQueryCriteria criteria)
        {
            return base.GetBy(criteria) as CarList;
        }
    
        /// <summary>
        /// 通过 CommonQueryCriteria 来查询单一实体。
        /// </summary>
        /// <param name="criteria">常用查询条件。</param>
        /// <returns></returns>
        [DebuggerStepThrough]
        public new Car GetFirstBy(CommonQueryCriteria criteria)
        {
            return base.GetFirstBy(criteria) as Car;
        }

        /// <summary>
        /// 递归查找所有树型子
        /// </summary>
        /// <param name="treeIndex"></param>
        /// <param name="loadOptions">数据加载时选项（贪婪加载等）。</param>
        /// <returns></returns>
        [DebuggerStepThrough]
        public new CarList GetByTreeParentIndex(string treeIndex, LoadOptions loadOptions = null)
        {
            return base.GetByTreeParentIndex(treeIndex, loadOptions) as CarList;
        }

        /// <summary>
        /// 查找指定树节点的直接子节点。
        /// </summary>
        /// <param name="treePId">需要查找的树节点的Id.</param>
        /// <param name="loadOptions">数据加载时选项（贪婪加载等）。</param>
        /// <returns></returns>
        [DebuggerStepThrough]
        public new CarList GetByTreePId(object treePId, LoadOptions loadOptions = null)
        {
            return base.GetByTreePId(treePId, loadOptions) as CarList;
        }

        #endregion
    }
}