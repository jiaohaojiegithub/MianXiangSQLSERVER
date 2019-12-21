

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MianXiangProject.DataTableOption.MXJobOption.Dtos
{
    /// <summary>
    /// 创建与更新岗位
    /// </summary>
    public class CreateOrUpdateMXJobInput
    {
        [Required]
        public MXJobEditDto MXJob { get; set; }

    }
}