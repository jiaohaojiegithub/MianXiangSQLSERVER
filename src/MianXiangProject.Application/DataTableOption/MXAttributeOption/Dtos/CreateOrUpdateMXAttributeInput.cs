

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace  MianXiangProject.DataTableOption.MXAttributeOption.Dtos
{
    public class CreateOrUpdateMXAttributeInput
    {
        [Required]
        public MXAttributeEditDto MXAttribute { get; set; }

    }
}