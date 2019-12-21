using Abp.Application.Services;
using Abp.Application.Services.Dto;
using MianXiangProject.DataTableOption.WxAppletUserOption.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace MianXiangProject.DataTableOption.WxAppletUserOption
{
    public interface IWXAppletUserApplicationService : IAsyncCrudAppService<WXAppletUserDto, int, PagedResultRequestDto, CreateWXAppletUserDto, WXAppletUserDto>
    {
    }
}
