
using Abp.Runtime.Validation;
using MianXiangProject.CommandShare.Models;
namespace MianXiangProject.DataTableOption.MXCompanyOption.Dtos
{
    public class GetMXCompanysInput : PagedSortedAndFilteredInputDto, IShouldNormalize
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
