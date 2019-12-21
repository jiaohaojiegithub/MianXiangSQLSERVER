
using Abp.Runtime.Validation;
using MianXiangProject.CommandShare.Models;
using MianXiangProject.DataTables;

namespace MianXiangProject.DataTableOption.MXJobOption.Dtos
{
    public class GetMXJobsInput : PagedSortedAndFilteredInputDto, IShouldNormalize
    {

        /// <summary>
        /// 正常化排序使用
        /// </summary>
        public void Normalize()
        {
            if (string.IsNullOrEmpty(Sorting))
            {
                Sorting = "Id";
            }
        }

    }
}
