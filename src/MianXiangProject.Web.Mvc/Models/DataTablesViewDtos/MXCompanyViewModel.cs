using MianXiangProject.DataTableOption.MXCompanyOption.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MianXiangProject.Web.Models.DataTablesViewDtos
{
    public class MXCompanyViewModel
    {
        public IReadOnlyList<MXCompanyListDto> MXCompanyList { get;  set; }
    }
}
