using System;
using System.Collections.Generic;
using System.Text;

namespace MianXiangProject.DataTables
{
    /// <summary>
    /// 访问用户数据存储
    /// </summary>
    public class WxAppletUser : MXEntity
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
