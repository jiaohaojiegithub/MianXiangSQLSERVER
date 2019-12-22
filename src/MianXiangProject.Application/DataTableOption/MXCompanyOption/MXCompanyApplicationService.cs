
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
using MianXiangProject.DataTableOption.MXCompanyOption.Dtos;



namespace MianXiangProject.DataTableOption.MXCompanyOption
{
    /// <summary>
    /// MXCompany应用层服务的接口实现方法  
    ///</summary>
    [AbpAuthorize]
    public class MXCompanyAppService : MianXiangProjectAppServiceBase, IMXCompanyAppService
    {
        private readonly IRepository<MXCompany, int> _entityRepository;
        /// <summary>
        /// 构造函数 
        ///</summary>
        public MXCompanyAppService(
        IRepository<MXCompany, int> entityRepository
        )
        {
            _entityRepository = entityRepository; 
        }


        /// <summary>
        /// 获取MXCompany的分页列表信息
        ///</summary>
        /// <param name="input"></param>
        /// <returns></returns>
		 
        public async Task<PagedResultDto<MXCompanyListDto>> GetPaged(GetMXCompanysInput input)
		{

		    var query = _entityRepository.GetAll();
			// TODO:根据传入的参数添加过滤条件
            

			var count = await query.CountAsync();

			var entityList = await query
					.OrderBy(input.Sorting).AsNoTracking()
					.PageBy(input)
					.ToListAsync();

			 var entityListDtos = ObjectMapper.Map<List<MXCompanyListDto>>(entityList);
			//var entityListDtos =entityList.MapTo<List<MXCompanyListDto>>();

			return new PagedResultDto<MXCompanyListDto>(count,entityListDtos);
		}


		/// <summary>
		/// 通过指定id获取MXCompanyListDto信息
		/// </summary>
		 
		public async Task<MXCompanyListDto> GetById(EntityDto<int> input)
		{
			var entity = await _entityRepository.GetAsync(input.Id);

		    return ObjectMapper.Map<MXCompanyListDto>(entity);
		}

		/// <summary>
		/// 获取编辑 MXCompany
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		
		public async Task<GetMXCompanyForEditOutput> GetForEdit(NullableIdDto<int> input)
		{
			var output = new GetMXCompanyForEditOutput();
MXCompanyEditDto editDto;

			if (input.Id.HasValue)
			{
				var entity = await _entityRepository.GetAsync(input.Id.Value);

				editDto = ObjectMapper.Map<MXCompanyEditDto>(entity);

				//mXCompanyEditDto = ObjectMapper.Map<List<mXCompanyEditDto>>(entity);
			}
			else
			{
				editDto = new MXCompanyEditDto();
			}

			output.MXCompany = editDto;
			return output;
		}


		/// <summary>
		/// 添加或者修改MXCompany的公共方法
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		
		public async Task CreateOrUpdate(CreateOrUpdateMXCompanyInput input)
		{

			if (input.MXCompany.Id.HasValue)
			{
				await Update(input.MXCompany);
			}
			else
			{
				await Create(input.MXCompany);
			}
		}


		/// <summary>
		/// 新增MXCompany
		/// </summary>
		
		protected virtual async Task<MXCompanyEditDto> Create(MXCompanyEditDto input)
		{
			//TODO:新增前的逻辑判断，是否允许新增

             var entity = ObjectMapper.Map<MXCompany>(input);
            //var entity=input.MapTo<MXCompany>();
			

			entity = await _entityRepository.InsertAsync(entity);
			return ObjectMapper.Map<MXCompanyEditDto>(entity);
		}

		/// <summary>
		/// 编辑MXCompany
		/// </summary>
		
		protected virtual async Task Update(MXCompanyEditDto input)
		{
			//TODO:更新前的逻辑判断，是否允许更新

			var entity = await _entityRepository.GetAsync(input.Id.Value);
			//input.MapTo(entity);

			 ObjectMapper.Map(input, entity);
		    await _entityRepository.UpdateAsync(entity);
		}



		/// <summary>
		/// 删除MXCompany信息的方法
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		
		public async Task Delete(EntityDto<int> input)
		{
			//TODO:删除前的逻辑判断，是否允许删除
			await _entityRepository.DeleteAsync(input.Id);
		}



		/// <summary>
		/// 批量删除MXCompany的方法
		/// </summary>
		
		public async Task BatchDelete(List<int> input)
		{
			// TODO:批量删除前的逻辑判断，是否允许删除
			await _entityRepository.DeleteAsync(s => input.Contains(s.Id));
		}
		/// <summary>
		/// 获取全部数据
		/// </summary>
		/// <returns></returns>
		public async Task<PagedResultDto<MXCompanyListDto>> GetAllAsync()
		{
			var query = _entityRepository.GetAll();
			// TODO:根据传入的参数添加过滤条件


			var count = await query.CountAsync();

			var entityList = await query
					
					.ToListAsync();

			var entityListDtos = ObjectMapper.Map<List<MXCompanyListDto>>(entityList);
			//var entityListDtos =entityList.MapTo<List<MXCompanyListDto>>();

			return new PagedResultDto<MXCompanyListDto>(count, entityListDtos);
		}

		/// <summary>
		/// 导出MXCompany为excel表,等待开发。
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


