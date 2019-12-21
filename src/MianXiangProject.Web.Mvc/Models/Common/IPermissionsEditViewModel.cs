using System.Collections.Generic;
using MianXiangProject.Roles.Dto;

namespace MianXiangProject.Web.Models.Common
{
    public interface IPermissionsEditViewModel
    {
        List<FlatPermissionDto> Permissions { get; set; }
    }
}