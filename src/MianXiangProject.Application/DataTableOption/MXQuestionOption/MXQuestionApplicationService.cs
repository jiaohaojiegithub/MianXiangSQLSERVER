
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
using  MianXiangProject.DataTableOption.MXQuestionOption.Dtos;
using Microsoft.AspNetCore.Authorization;
using Newtonsoft.Json;

namespace MianXiangProject.DataTableOption.MXQuestionOption
{
    /// <summary>
    /// MXQuestion应用层服务的接口实现方法  
    ///</summary>
    [AbpAuthorize]
    public class MXQuestionAppService : MianXiangProjectAppServiceBase, IMXQuestionAppService
    {
        private readonly IRepository<MXQuestion, int> _entityRepository;

        /// <summary>
        /// 构造函数 
        ///</summary>
        public MXQuestionAppService(
        IRepository<MXQuestion, int> entityRepository
        )
        {
            _entityRepository = entityRepository; 
           
        }


		/// <summary>
		/// 获取MXQuestion的分页列表信息
		///</summary>
		/// <param name="input"></param>
		/// <returns></returns>
		public async Task<PagedResultDto<MXQuestionListDto>> GetPaged(GetMXQuestionsInput input)
		{

		    var query = _entityRepository.GetAll();
			// TODO:根据传入的参数添加过滤条件
            

			var count = await query.CountAsync();

			var entityList = await query
					.OrderBy(input.Sorting).AsNoTracking()
					.PageBy(input)
					.ToListAsync();

			 var entityListDtos = ObjectMapper.Map<List<MXQuestionListDto>>(entityList);
			//var entityListDtos =entityList.MapTo<List<MXQuestionListDto>>();

			return new PagedResultDto<MXQuestionListDto>(count,entityListDtos);
		}


		/// <summary>
		/// 通过指定id获取MXQuestionListDto信息
		/// </summary>
		 
		public async Task<MXQuestionListDto> GetById(EntityDto<int> input)
		{
			var entity = await _entityRepository.GetAsync(input.Id);

		    return ObjectMapper.Map<MXQuestionListDto>(entity);
		}

		/// <summary>
		/// 获取编辑 MXQuestion
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		
		public async Task<GetMXQuestionForEditOutput> GetForEdit(NullableIdDto<int> input)
		{
			var output = new GetMXQuestionForEditOutput();
MXQuestionEditDto editDto;

			if (input.Id.HasValue)
			{
				var entity = await _entityRepository.GetAsync(input.Id.Value);

				editDto = ObjectMapper.Map<MXQuestionEditDto>(entity);

				//mXQuestionEditDto = ObjectMapper.Map<List<mXQuestionEditDto>>(entity);
			}
			else
			{
				editDto = new MXQuestionEditDto();
			}

			output.MXQuestion = editDto;
			return output;
		}


		/// <summary>
		/// 添加或者修改MXQuestion的公共方法
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		
		public async Task CreateOrUpdate(CreateOrUpdateMXQuestionInput input)
		{
			//input.MXQuestion.Options= JsonConvert.SerializeObject(input.MXQuestion.TestOptions);
			if (input.MXQuestion.Id.HasValue)
			{
				await Update(input.MXQuestion);
			}
			else
			{
				await Create(input.MXQuestion);
			}
		}


		/// <summary>
		/// 新增MXQuestion
		/// </summary>
		
		protected virtual async Task<MXQuestionEditDto> Create(MXQuestionEditDto input)
		{
			//TODO:新增前的逻辑判断，是否允许新增

             var entity = ObjectMapper.Map <MXQuestion>(input);
            //var entity=input.MapTo<MXQuestion>();
			

			entity = await _entityRepository.InsertAsync(entity);
			//var ss = JsonConvert.DeserializeObject<Dictionary<string, string>>(entity.Options);
			return ObjectMapper.Map<MXQuestionEditDto>(entity);
		}

		/// <summary>
		/// 编辑MXQuestion
		/// </summary>
		
		protected virtual async Task Update(MXQuestionEditDto input)
		{
			//TODO:更新前的逻辑判断，是否允许更新

			var entity = await _entityRepository.GetAsync(input.Id.Value);
			//input.MapTo(entity);

			 ObjectMapper.Map(input, entity);
		    await _entityRepository.UpdateAsync(entity);
		}



		/// <summary>
		/// 删除MXQuestion信息的方法
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		
		public async Task Delete(EntityDto<int> input)
		{
			//TODO:删除前的逻辑判断，是否允许删除
			await _entityRepository.DeleteAsync(input.Id);
		}



		/// <summary>
		/// 批量删除MXQuestion的方法
		/// </summary>
		
		public async Task BatchDelete(List<int> input)
		{
			// TODO:批量删除前的逻辑判断，是否允许删除
			await _entityRepository.DeleteAsync(s => input.Contains(s.Id));
		}
		/// <summary>
		/// 获取所有数据
		/// </summary>
		/// <returns></returns>
		public async Task<PagedResultDto<MXQuestionListDto>> GetAllAsync()
		{
			var query = _entityRepository.GetAll();
			// TODO:根据传入的参数添加过滤条件
			var count = await query.CountAsync();
			var entityList = await query
					.ToListAsync();

			var entityListDtos = ObjectMapper.Map<List<MXQuestionListDto>>(entityList);
			return new PagedResultDto<MXQuestionListDto>(count, entityListDtos);
		}

		/// <summary>
		/// 导出MXQuestion为excel表,等待开发。
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


