﻿/*******************************************************
 * 
 * 作者：胡庆访
 * 创建时间：20110623
 * 说明：此文件只包含一个类，具体内容见类型注释。
 * 运行环境：.NET 4.0
 * 版本号：1.0.0
 * 
 * 历史记录：
 * 创建文件 胡庆访 20110623
 * 
*******************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;

namespace Rafy.WPF
{
    /// <summary>
    /// LogicalView 的集合。
    /// </summary>
    public class LogicalViewCollection : Collection<LogicalView>
    {
        /// <summary>
        /// 获取某一个关系视图
        /// </summary>
        /// <param name="entityType"></param>
        /// <returns></returns>
        public LogicalView this[Type entityType]
        {
            get
            {
                var res = this.Find(entityType);
                if (res == null) throw new InvalidOperationException("没有找到指定的视图：" + entityType);
                return res;
            }
        }

        /// <summary>
        /// 尝试找到某一个关系视图
        /// </summary>
        /// <param name="entityType"></param>
        /// <returns></returns>
        public LogicalView Find(Type entityType)
        {
            return this.FirstOrDefault(s => s.EntityType == entityType);
        }
    }
}