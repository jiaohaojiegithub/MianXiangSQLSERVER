using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using MianXiangProject.DataTableOption.WxAppletUserOption.Dtos;
using MianXiangProject.DataTables;
using System;
using System.Collections.Generic;
using System.Text;

namespace MianXiangProject.DataTableOption.WxAppletUserOption
{
    /// <summary>
    /// 微信数据
    /// </summary>
    public class WXAppletUserApplicationService : AsyncCrudAppService<WxAppletUser, WXAppletUserDto, int, PagedResultRequestDto, CreateWXAppletUserDto, WXAppletUserDto>, IWXAppletUserApplicationService
    {
        private readonly IRepository<WxAppletUser> _WxAppletUserRepository;
        public WXAppletUserApplicationService(IRepository<WxAppletUser> WxAppletUserRepository) : base(WxAppletUserRepository)
        {
            _WxAppletUserRepository = WxAppletUserRepository;

            LocalizationSourceName = MianXiangProjectConsts.LocalizationSourceName;
        }
    }
}
