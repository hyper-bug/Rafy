﻿/*******************************************************
 * 
 * 作者：胡庆访
 * 创建日期：20211125
 * 说明：此文件只包含一个类，具体内容见类型注释。
 * 运行环境：.NET 4.0
 * 版本号：1.0.0
 * 
 * 历史记录：
 * 创建文件 胡庆访 20211125 10:05
 * 
*******************************************************/

using System;
using System.Collections.Generic;
using System.Text;

namespace Rafy.Domain
{
    /// <summary>
    /// 控制器的配置属性。如果该属性需要由客户端传输给服务端时，则需要为属性添加此标记。
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class ControllerClientSettingsAttribute : Attribute { }
}