

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MianXiangProject.DataTableOption.MXCompanyOption.Dtos
{
    public class CreateOrUpdateMXCompanyInput
    {
        [Required]
        public MXCompanyEditDto MXCompany { get; set; }

    }
}