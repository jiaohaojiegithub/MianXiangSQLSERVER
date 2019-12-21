using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MianXiangProject.DataTables
{
    /// <summary>
    /// 岗位
    /// </summary>
    public class MXJob : MXEntity
    {
        /// <summary>
        /// 岗位名称
        /// </summary>
        [StringLength(100)]
        public string JobName { get; set; }
        /// <summary>
        /// 岗位类别
        /// </summary>
        [StringLength(100)]
        public string JobType { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        [StringLength(400)]
        public string Description { get; set; }

      
     
    }
}
