using System;
using System.Collections.Generic;
using System.Text;

namespace MianXiangProject.DataTables
{
    /// <summary>
    /// 微信用户
    /// </summary>
    public class WxUserInfo : MXEntity
    {
        /// <summary>
        /// Uid标识
        /// </summary>
        public string Uid { get; set; }
        /// <summary>
        /// 微信Openid
        /// </summary>
        public string Openid { get; set; }
        /// <summary>
        /// 微信UnionId
        /// </summary>
        public string UnionId { get; set; }
        /// <summary>
        /// 昵称
        /// </summary>
        public string Nickname { get; set; }
        /// <summary>
        /// 真实姓名
        /// </summary>
        public string RealName { get; set; }
        /// <summary>
        /// 性别
        /// </summary>
        public int Sex { get; set; }
        /// <summary>
        /// 语言
        /// </summary>
        public string Language { get; set; }
        /// <summary>
        /// 地区
        /// </summary>
        public string Area { get; set; }
        /// <summary>
        /// 城市
        /// </summary>
        public string City { get; set; }
        /// <summary>
        /// 省份
        /// </summary>
        public string Province { get; set; }
        /// <summary>
        /// 国家
        /// </summary>
        public string Country { get; set; }
        /// <summary>
        /// 头像地址
        /// </summary>
        public string Headimgul { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }
    }
}
