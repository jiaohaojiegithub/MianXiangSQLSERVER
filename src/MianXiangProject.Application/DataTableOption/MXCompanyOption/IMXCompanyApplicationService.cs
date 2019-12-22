
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


using MianXiangProject.DataTableOption.MXCompanyOption.Dtos;
using MianXiangProject.DataTables;

namespace MianXiangProject.DataTableOption.MXCompanyOption
{
    /// <summary>
    /// MXCompany应用层服务的接口方法
    ///</summary>
    public interface IMXCompanyAppService : IApplicationService
    {
        /// <summary>
		/// 获取MXCompany的分页列表信息
		///</summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<PagedResultDto<MXCompanyListDto>> GetPaged(GetMXCompanysInput input);
        /// <summary>
        /// 获取全部数据
        /// </summary>
        /// <returns></returns>
        Task<PagedResultDto<MXCompanyListDto>> GetAllAsync();
        /// <summary>
        /// 通过指定id获取MXCompanyListDto信息
        /// </summary>
        Task<MXCompanyListDto> GetById(EntityDto<int> input);


        /// <summary>
        /// 返回实体的EditDto
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<GetMXCompanyForEditOutput> GetForEdit(NullableIdDto<int> input);


        /// <summary>
        /// 添加或者修改MXCompany的公共方法
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task CreateOrUpdate(CreateOrUpdateMXCompanyInput input);


        /// <summary>
        /// 删除MXCompany信息的方法
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task Delete(EntityDto<int> input);


        /// <summary>
        /// 批量删除MXCompany
        /// </summary>
        Task BatchDelete(List<int> input);


		/// <summary>
        /// 导出MXCompany为excel表
        /// </summary>
        /// <returns></returns>
		//Task<FileDto> GetToExcel();

    }
}
