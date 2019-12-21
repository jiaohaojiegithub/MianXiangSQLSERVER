using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MianXiangProject.DataTables
{
    /// <summary>
    /// 属性表
    /// </summary>
    public class MXAttribute : MXEntity
    {
        /// <summary>
        /// 属性名
        /// </summary>
        public string AttributeName { get; set; }
        /// <summary>
        /// 属性值
        /// </summary>
        public string AttributeValue { get; set; }
        /// <summary>
        /// 属性类型
        /// </summary>
        public string AttributeType { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        [StringLength(400)]
        public string Description { get; set; }
    }
}
