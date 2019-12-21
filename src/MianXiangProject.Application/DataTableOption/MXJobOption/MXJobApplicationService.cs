
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
using Abp.Extensions;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Application.Services.Dto;
using Abp.Linq.Extensions;


using MianXiangProject.DataTables;
using MianXiangProject.DataTableOption.MXJobOption.Dtos;



namespace MianXiangProject.DataTableOption.MXJobOption
{
    /// <summary>
    /// MXJob应用层服务的接口实现方法  
    ///</summary>
    [AbpAuthorize]
    public class MXJobAppService : MianXiangProjectAppServiceBase, IMXJobAppService
    {
        private readonly IRepository<MXJob, int> _entityRepository;

        /// <summary>
        /// 构造函数 
        ///</summary>
        public MXJobAppService(
        IRepository<MXJob, int> entityRepository
        )
        {
            _entityRepository = entityRepository; 
        }


        /// <summary>
        /// 获取MXJob的分页列表信息
        ///</summary>
        /// <param name="input"></param>
        /// <returns></returns>
		 
        public async Task<PagedResultDto<MXJobListDto>> GetPaged(GetMXJobsInput input)
		{

		    var query = _entityRepository.GetAll();
			// TODO:根据传入的参数添加过滤条件
            

			var count = await query.CountAsync();

			var entityList = await query
					.OrderBy(input.Sorting).AsNoTracking()
					.PageBy(input)
					.ToListAsync();

			var entityListDtos = ObjectMapper.Map<List<MXJobListDto>>(entityList);
			//var entityListDtos =entityList.MapTo<List<MXJobListDto>>();

			return new PagedResultDto<MXJobListDto>(count,entityListDtos);
		}


		/// <summary>
		/// 通过指定id获取MXJobListDto信息
		/// </summary>
		 
		public async Task<MXJobListDto> GetById(EntityDto<int> input)
		{
			var entity = await _entityRepository.GetAsync(input.Id);

		    return ObjectMapper.Map<MXJobListDto>(entity);
		}

		/// <summary>
		/// 获取编辑 MXJob
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		
		public async Task<GetMXJobForEditOutput> GetForEdit(NullableIdDto<int> input)
		{
			var output = new GetMXJobForEditOutput();
MXJobEditDto editDto;

			if (input.Id.HasValue)
			{
				var entity = await _entityRepository.GetAsync(input.Id.Value);

				editDto = ObjectMapper.Map<MXJobEditDto>(entity);

				//mXJobEditDto = ObjectMapper.Map<List<mXJobEditDto>>(entity);
			}
			else
			{
				editDto = new MXJobEditDto();
			}

			output.MXJob = editDto;
			return output;
		}


		/// <summary>
		/// 添加或者修改MXJob的公共方法
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		
		public async Task CreateOrUpdate(CreateOrUpdateMXJobInput input)
		{

			if (input.MXJob.Id.HasValue)
			{
				await Update(input.MXJob);
			}
			else
			{
				await Create(input.MXJob);
			}
		}


		/// <summary>
		/// 新增MXJob
		/// </summary>
		
		protected virtual async Task<MXJobEditDto> Create(MXJobEditDto input)
		{
			//TODO:新增前的逻辑判断，是否允许新增

            var entity = ObjectMapper.Map<MXJob>(input);
            //var entity=input.MapTo<MXJob>();
			

			entity = await _entityRepository.InsertAsync(entity);
			return ObjectMapper.Map<MXJobEditDto>(entity);
		}

		/// <summary>
		/// 编辑MXJob
		/// </summary>
		
		protected virtual async Task Update(MXJobEditDto input)
		{
			//TODO:更新前的逻辑判断，是否允许更新

			var entity = await _entityRepository.GetAsync(input.Id.Value);
			//input.MapTo(entity);

			 ObjectMapper.Map(input, entity);
		    await _entityRepository.UpdateAsync(entity);
		}



		/// <summary>
		/// 删除MXJob信息的方法
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		
		public async Task Delete(EntityDto<int> input)
		{
			//TODO:删除前的逻辑判断，是否允许删除
			await _entityRepository.DeleteAsync(input.Id);
		}



		/// <summary>
		/// 批量删除MXJob的方法
		/// </summary>
		
		public async Task BatchDelete(List<int> input)
		{
			// TODO:批量删除前的逻辑判断，是否允许删除
			await _entityRepository.DeleteAsync(s => input.Contains(s.Id));
		}


		/// <summary>
		/// 导出MXJob为excel表,等待开发。
		/// </summary>
		/// <returns></returns>
		//public async Task<FileDto> GetToExcel()
		//{
		//	var users = await UserManager.Users.ToListAsync();
		//	var userListDtos = ObjectMapper.Map<List<UserListDto>>(users);
		//	await FillRoleNames(userListDtos);
		//	return _userListExcelExporter.ExportToFile(userListDtos);
		//}

    }
}


