

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MianXiangProject.DataTableOption.MXJobOption.Dtos
{
    /// <summary>
    /// ��������¸�λ
    /// </summary>
    public class CreateOrUpdateMXJobInput
    {
        [Required]
        public MXJobEditDto MXJob { get; set; }

    }
}