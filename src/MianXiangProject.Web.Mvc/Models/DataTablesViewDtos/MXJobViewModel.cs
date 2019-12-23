using MianXiangProject.DataTableOption.MXJobOption.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MianXiangProject.Web.Models.DataTablesViewDtos
{
    public class MXJobViewModel
    {
        public IReadOnlyList<MXJobListDto> MXJobList { get;  set; }
    }
}
