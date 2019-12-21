
using System;
using System.Data;
using System.Linq;
using System.Linq.Dynamic;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

using Abp.UI;
using Abp.AutoMapper;
using Abp.Authorization;
using Abp.Linq.Extensions;
using Abp.Domain.Repositories;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using MianXiangProject.DataTableOption.MXAttributeOption.Dtos;

namespace MianXiangProject.DataTableOption.MXAttributeOption
{
    /// <summary>
    /// MXAttribute应用层服务的接口方法
    ///</summary>
    public interface IMXAttributeAppService : IApplicationService
    {
        /// <summary>
		/// 获取MXAttribute的分页列表信息
		///</summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<PagedResultDto<MXAttributeListDto>> GetPaged(GetMXAttributesInput input);


		/// <summary>
		/// 通过指定id获取MXAttributeListDto信息
		/// </summary>
		Task<MXAttributeListDto> GetById(EntityDto<int> input);


        /// <summary>
        /// 返回实体的EditDto
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<GetMXAttributeForEditOutput> GetForEdit(NullableIdDto<int> input);


        /// <summary>
        /// 添加或者修改MXAttribute的公共方法
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task CreateOrUpdate(CreateOrUpdateMXAttributeInput input);


        /// <summary>
        /// 删除MXAttribute信息的方法
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task Delete(EntityDto<int> input);


        /// <summary>
        /// 批量删除MXAttribute
        /// </summary>
        Task BatchDelete(List<int> input);


		/// <summary>
        /// 导出MXAttribute为excel表
        /// </summary>
        /// <returns></returns>
		//Task<FileDto> GetToExcel();

    }
}
