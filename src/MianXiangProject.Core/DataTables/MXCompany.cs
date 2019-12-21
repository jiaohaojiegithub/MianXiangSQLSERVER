using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MianXiangProject.DataTables
{
    /// <summary>
    /// 公司表
    /// </summary>
    public class MXCompany :MXEntity
    {
        /// <summary>
        /// 公司名
        /// </summary>
        [StringLength(100)]
        public string CompanyName { get; set; }
        /// <summary>
        /// 公司类型
        /// </summary>
        [StringLength(100)]
        public string CompanyType { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        [StringLength(400)]
        public string Description { get; set; }

    }
}
