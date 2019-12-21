using Abp.AutoMapper;
using MianXiangProject.CommandShare.Models;
using MianXiangProject.DataTables;
using System;
using System.Collections.Generic;
using System.Text;

namespace MianXiangProject.DataTableOption.WxAppletUserOption.Dtos
{
    /// <summary>
    /// WxAppletUser对象
    /// </summary>
    [AutoMapFrom(typeof(WxAppletUser))]
    public class WXAppletUserDto:MXEntityDto
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

    }
}
