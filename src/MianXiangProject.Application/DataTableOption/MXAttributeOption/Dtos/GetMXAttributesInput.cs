
using Abp.Runtime.Validation;
using MianXiangProject.CommandShare.Models;

namespace  MianXiangProject.DataTableOption.MXAttributeOption.Dtos
{
    /// <summary>
    /// 查询分页
    /// </summary>
    public class GetMXAttributesInput : PagedSortedAndFilteredInputDto, IShouldNormalize
    {
        /// <summary>
        /// 默认
        /// </summary>
        public GetMXAttributesInput():base()
        {
            IsLike = true;
        }
        public GetMXAttributesInput(string Filter) : base()
        {
            FilterText = Filter;
            
        }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="filter">过滤文本</param>
        /// <param name="maxResultCount">最大数量</param>
        /// <param name="skipCount">跳过数量</param>
        /// <param name="sorting">排序</param>
        /// <param name="isLike">模糊匹配</param>
        public GetMXAttributesInput(string filter,int maxResultCount,int skipCount,string sorting,bool isLike=false) 
        {
            FilterText = filter;
            MaxResultCount = maxResultCount;
            SkipCount = skipCount;
            Sorting = sorting;
            IsLike = isLike;
        }
        /// <summary>
        /// 模糊匹配
        /// </summary>
        public bool IsLike { get; set; }

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
