

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MianXiangProject.DataTableOption.MXQuestionOption.Dtos
{
    public class CreateOrUpdateMXQuestionInput
    {
        [Required]
        public MXQuestionEditDto MXQuestion { get; set; }

    }
}