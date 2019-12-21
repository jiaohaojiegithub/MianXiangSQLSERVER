
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


using MianXiangProject.DataTableOption.MXJobOption.Dtos;
using MianXiangProject.DataTables;

namespace MianXiangProject.DataTableOption.MXJobOption
{
    /// <summary>
    /// MXJob应用层服务的接口方法
    ///</summary>
    public interface IMXJobAppService : IApplicationService
    {
        /// <summary>
		/// 获取MXJob的分页列表信息
		///</summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<PagedResultDto<MXJobListDto>> GetPaged(GetMXJobsInput input);


		/// <summary>
		/// 通过指定id获取MXJobListDto信息
		/// </summary>
		Task<MXJobListDto> GetById(EntityDto<int> input);


        /// <summary>
        /// 返回实体的EditDto
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<GetMXJobForEditOutput> GetForEdit(NullableIdDto<int> input);


        /// <summary>
        /// 添加或者修改MXJob的公共方法
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task CreateOrUpdate(CreateOrUpdateMXJobInput input);


        /// <summary>
        /// 删除MXJob信息的方法
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task Delete(EntityDto<int> input);


        /// <summary>
        /// 批量删除MXJob
        /// </summary>
        Task BatchDelete(List<int> input);


		/// <summary>
        /// 导出MXJob为excel表
        /// </summary>
        /// <returns></returns>
		//Task<FileDto> GetToExcel();

    }
}
