
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


using  MianXiangProject.DataTableOption.MXQuestionOption.Dtos;

namespace MianXiangProject.DataTableOption.MXQuestionOption
{
    /// <summary>
    /// MXQuestion应用层服务的接口方法
    ///</summary>
    public interface IMXQuestionAppService : IApplicationService
    {
        /// <summary>
		/// 获取MXQuestion的分页列表信息
		///</summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<PagedResultDto<MXQuestionListDto>> GetPaged(GetMXQuestionsInput input);


		/// <summary>
		/// 通过指定id获取MXQuestionListDto信息
		/// </summary>
		Task<MXQuestionListDto> GetById(EntityDto<int> input);


        /// <summary>
        /// 返回实体的EditDto
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<GetMXQuestionForEditOutput> GetForEdit(NullableIdDto<int> input);


        /// <summary>
        /// 添加或者修改MXQuestion的公共方法
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task CreateOrUpdate(CreateOrUpdateMXQuestionInput input);


        /// <summary>
        /// 删除MXQuestion信息的方法
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task Delete(EntityDto<int> input);


        /// <summary>
        /// 批量删除MXQuestion
        /// </summary>
        Task BatchDelete(List<int> input);


		/// <summary>
        /// 导出MXQuestion为excel表
        /// </summary>
        /// <returns></returns>
		//Task<FileDto> GetToExcel();

    }
}
