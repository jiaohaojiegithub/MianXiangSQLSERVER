using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MianXiangProject.CommandShare.Models
{
    /// <summary>
    /// 所有数据条件查询
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class PagedAllInputDto<T>: IPagedResultRequest
    {
        /// <summary>
        /// 总数目条数
        /// </summary>
        [Range(1, AppConsts.MaxPageSize)]
        public int MaxResultCount { get; set; }
        /// <summary>
        /// 跳过数
        /// </summary>

        [Range(0, int.MaxValue)]
        public int SkipCount { get; set; }
        /// <summary>
        /// 过滤文本
        /// </summary>
        public T FilterText { get; set; }

        /// <summary>
        /// 排序字段
        /// </summary>
        public string Sorting { get; set; }
        /// <summary>
        /// 是否模糊匹配
        /// </summary>
        public bool IsLike { get; set; }
        /// <summary>
        /// 默认的数据
        /// </summary>
        public PagedAllInputDto()
        {
            MaxResultCount = AppConsts.DefaultPageSize;
            Sorting = "Id";
            IsLike = true;
        }
        /// <summary>
        /// 赋值的数据
        /// </summary>
        /// <param name="maxResultCount">总数目条数</param>
        /// <param name="sorting">排序字段</param>
        /// <param name="filterText">过滤对象</param>
        /// <param name="skipCount">跳过数</param>
        /// <param name="isLike">模糊匹配</param>
        public PagedAllInputDto(int maxResultCount,string sorting,T filterText,int skipCount,bool isLike)
        {
            MaxResultCount = maxResultCount;
            Sorting = sorting;
            FilterText = filterText;
            SkipCount = skipCount;
            IsLike = isLike;
        }
    }
}
