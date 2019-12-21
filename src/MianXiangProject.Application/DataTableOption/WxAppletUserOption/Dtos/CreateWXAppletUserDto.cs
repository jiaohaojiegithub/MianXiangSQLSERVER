using Abp.AutoMapper;
using MianXiangProject.DataTables;
using MianXiangProject.SharedCommand;
using System;
using System.Collections.Generic;
using System.Text;

namespace MianXiangProject.DataTableOption.WxAppletUserOption.Dtos
{
    /// <summary>
    /// 创建数据
    /// </summary>
    [AutoMapTo(typeof(WxAppletUser))]
    public class CreateWXAppletUserDto
    {
        /// <summary>
        /// 微信参数
        /// </summary>
        public string UnionId { get; set; }
        /// <summary>
        /// 微信参数
        /// </summary>
        public string OpenId { get; set; }
        /// <summary>
        /// 微信参数
        /// </summary>
        public string SessionKey { get; set; }
        /// <summary>
        /// 微信参数
        /// </summary>
        public string SessionId { get; set; }
        /// <summary>
        /// 排序
        /// </summary>
        public int Sort { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        public DataState State { get; set; }
    }
}
