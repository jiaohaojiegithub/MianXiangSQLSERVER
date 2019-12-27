
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
using MianXiangProject.CommandShare.Models;
using System.Web;
using System.Text;
using Newtonsoft.Json;

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
			query = query.WhereIf(!input.FilterText.IsNullOrEmpty(), x => x.AttributeType == input.FilterText);

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
		/// 组合条件查询
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		public async Task<PagedResultDto<MXAttributeListDto>> GetPagedByFilter(PagedAllInputDto<MXAttributeFilter> input)
		{
			var query = _entityRepository.GetAll();
			// TODO:根据传入的参数添加过滤条件
			if (input.FilterText.Id.HasValue)
			{
				query = query.Where(x => x.Id == input.FilterText.Id);

			}
			else
			{
				//Expression<Func<MXAttribute, bool>> where = itme => itme.State == input.FilterText.State;
				if (input.IsLike)
				{
					query = query
						.WhereIf(!input.FilterText.AttributeType.IsNullOrWhiteSpace(), itme => itme.AttributeType.Contains(input.FilterText.AttributeType))
						.WhereIf(!input.FilterText.AttributeName.IsNullOrWhiteSpace(), itme => itme.AttributeName.Contains(input.FilterText.AttributeName))
						.WhereIf(!input.FilterText.AttributeValue.IsNullOrWhiteSpace(), itme => itme.AttributeValue.Contains(input.FilterText.AttributeValue));
				}
				else
				{
					query = query
							.WhereIf(!input.FilterText.AttributeType.IsNullOrWhiteSpace(), itme => itme.AttributeType == input.FilterText.AttributeType)
							.WhereIf(!input.FilterText.AttributeName.IsNullOrWhiteSpace(), itme => itme.AttributeName == input.FilterText.AttributeName)
							.WhereIf(!input.FilterText.AttributeValue.IsNullOrWhiteSpace(), itme => itme.AttributeValue == input.FilterText.AttributeValue);
				}
			}


			var count = await query.CountAsync();

			var entityList = await query
					.OrderBy(input.Sorting).AsNoTracking()
					.PageBy(input)
					.ToListAsync();

			var entityListDtos = ObjectMapper.Map<List<MXAttributeListDto>>(entityList);
			//var entityListDtos =entityList.MapTo<List<MXAttributeListDto>>();

			return new PagedResultDto<MXAttributeListDto>(count, entityListDtos);
		}
		/// <summary>
		/// Json 字典查询
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		public async Task<PagedResultDto<MXAttributeListDto>> GetPagedByFilterJson(GetMXAttributesInput input)
		{
			var query = _entityRepository.GetAll();
		
			input.FilterText = HttpUtility.UrlDecode(input.FilterText, Encoding.UTF8);
			var WhereJson = input.FilterText.IsNullOrWhiteSpace() ? new Dictionary<string, string>() : JsonConvert.DeserializeObject<Dictionary<string, string>>(input.FilterText);
			// TODO:根据传入的参数添加过滤条件

			//Expression<Func<MXAttribute, bool>> where = itme => itme.State == input.FilterText.State;
			if (input.IsLike)
			{
				var x = WhereJson.ContainsKey("AttributeType");
				var xv = WhereJson.GetValueOrDefault("AttributeType");
				query = query
					.WhereIf(WhereJson.ContainsKey("AttributeType"), itme => itme.AttributeType.Contains(WhereJson.GetValueOrDefault("AttributeType")))
					.WhereIf(WhereJson.ContainsKey("AttributeName"), itme => itme.AttributeName.Contains(WhereJson.GetValueOrDefault("AttributeName")))
					.WhereIf(WhereJson.ContainsKey("AttributeValue"), itme => itme.AttributeValue.Contains(WhereJson.GetValueOrDefault("AttributeValue")));
			}
			else
			{
				query = query
						.WhereIf(WhereJson.ContainsKey("AttributeType"), itme => itme.AttributeType == WhereJson.GetValueOrDefault("AttributeType"))
						.WhereIf(WhereJson.ContainsKey("AttributeName"), itme => itme.AttributeName == WhereJson.GetValueOrDefault("AttributeName"))
						.WhereIf(WhereJson.ContainsKey("AttributeValue"), itme => itme.AttributeValue == WhereJson.GetValueOrDefault("AttributeValue"));
			}


			var count = await query.CountAsync();

			var entityList = await query
					.OrderBy(input.Sorting).AsNoTracking()
					.PageBy(input)
					.ToListAsync();

			var entityListDtos = ObjectMapper.Map<List<MXAttributeListDto>>(entityList);
			//var entityListDtos =entityList.MapTo<List<MXAttributeListDto>>();

			return new PagedResultDto<MXAttributeListDto>(count, entityListDtos);
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


