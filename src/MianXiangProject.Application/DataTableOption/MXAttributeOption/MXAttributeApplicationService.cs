
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
using MianXiangProject.DataTableOption.MXAttributeOption.Dtos;

namespace MianXiangProject.DataTableOption.MXAttributeOption
{
    /// <summary>
    /// MXAttribute应用层服务的接口实现方法  
    ///</summary>
    [AbpAuthorize]
    public class MXAttributeAppService : MianXiangProjectAppServiceBase, IMXAttributeAppService
	{
        private readonly IRepository<MXAttribute, int> _entityRepository;

        /// <summary>
        /// 构造函数 
        ///</summary>
        public MXAttributeAppService(
        IRepository<MXAttribute, int> entityRepository
        )
        {
            _entityRepository = entityRepository; 
        }


        /// <summary>
        /// 获取MXAttribute的分页列表信息
        ///</summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<PagedResultDto<MXAttributeListDto>> GetPaged(GetMXAttributesInput input)
		{

		    var query = _entityRepository.GetAll();
			// TODO:根据传入的参数添加过滤条件
            

			var count = await query.CountAsync();

			var entityList = await query
					.OrderBy(input.Sorting).AsNoTracking()
					.PageBy(input)
					.ToListAsync();

		    var entityListDtos = ObjectMapper.Map<List<MXAttributeListDto>>(entityList);
			//var entityListDtos =entityList.MapTo<List<MXAttributeListDto>>();

			return new PagedResultDto<MXAttributeListDto>(count,entityListDtos);
		}


		/// <summary>
		/// 通过指定id获取MXAttributeListDto信息
		/// </summary>
		public async Task<MXAttributeListDto> GetById(EntityDto<int> input)
		{
			var entity = await _entityRepository.GetAsync(input.Id);

		    return ObjectMapper.Map<MXAttributeListDto>(entity); 
			//entity.MapTo<MXAttributeListDto>();
		}

		/// <summary>
		/// 获取编辑 MXAttribute
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		public async Task<GetMXAttributeForEditOutput> GetForEdit(NullableIdDto<int> input)
		{
			var output = new GetMXAttributeForEditOutput();
MXAttributeEditDto editDto;

			if (input.Id.HasValue)
			{
				var entity = await _entityRepository.GetAsync(input.Id.Value);

				editDto = ObjectMapper.Map<MXAttributeEditDto>(entity);

				//mXAttributeEditDto = ObjectMapper.Map<List<mXAttributeEditDto>>(entity);
			}
			else
			{
				editDto = new MXAttributeEditDto();
			}

			output.MXAttribute = editDto;
			return output;
		}


		/// <summary>
		/// 添加或者修改MXAttribute的公共方法
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		public async Task CreateOrUpdate(CreateOrUpdateMXAttributeInput input)
		{

			if (input.MXAttribute.Id.HasValue)
			{
				await Update(input.MXAttribute);
			}
			else
			{
				await Create(input.MXAttribute);
			}
		}


		/// <summary>
		/// 新增MXAttribute
		/// </summary>
		protected virtual async Task<MXAttributeEditDto> Create(MXAttributeEditDto input)
		{
			//TODO:新增前的逻辑判断，是否允许新增

             var entity = ObjectMapper.Map <MXAttribute>(input);
            //var entity=input.MapTo<MXAttribute>();
			

			entity = await _entityRepository.InsertAsync(entity);
			return ObjectMapper.Map<MXAttributeEditDto>(entity);
		}

		/// <summary>
		/// 编辑MXAttribute
		/// </summary>
		protected virtual async Task Update(MXAttributeEditDto input)
		{
			//TODO:更新前的逻辑判断，是否允许更新

			var entity = await _entityRepository.GetAsync(input.Id.Value);
			//input.MapTo(entity);

			ObjectMapper.Map(input, entity);
		    await _entityRepository.UpdateAsync(entity);
		}



		/// <summary>
		/// 删除MXAttribute信息的方法
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		public async Task Delete(EntityDto<int> input)
		{
			//TODO:删除前的逻辑判断，是否允许删除
			await _entityRepository.DeleteAsync(input.Id);
		}



		/// <summary>
		/// 批量删除MXAttribute的方法
		/// </summary>
		public async Task BatchDelete(List<int> input)
		{
			// TODO:批量删除前的逻辑判断，是否允许删除
			await _entityRepository.DeleteAsync(s => input.Contains(s.Id));
		}


		/// <summary>
		/// 导出MXAttribute为excel表,等待开发。
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


