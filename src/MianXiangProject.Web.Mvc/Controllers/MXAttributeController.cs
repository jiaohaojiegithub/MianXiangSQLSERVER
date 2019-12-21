using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using MianXiangProject.Controllers;
using MianXiangProject.DataTableOption.MXAttributeOption;
using MianXiangProject.Web.Models.MXAttributeViewDtos;
using Microsoft.AspNetCore.Mvc;

namespace MianXiangProject.Web.Controllers
{
    public class MXAttributeController : MianXiangProjectControllerBase
    {
        private readonly IMXAttributeAppService _mXAttributeAppService;

        public MXAttributeController(IMXAttributeAppService mXAttributeAppService)
        {
            _mXAttributeAppService = mXAttributeAppService;
        }

        public async Task<IActionResult> Index()
        {
            var modelDto = (await _mXAttributeAppService.GetPaged(new DataTableOption.MXAttributeOption.Dtos.GetMXAttributesInput())).Items;
            var viewModel = new MXAttributeViewModel
            {
                MXAttributeList = modelDto
            };
            return View(viewModel);
        }

        public async Task<IActionResult> EditMXAttributeModal(int Id)
        {
            var modelDto = await _mXAttributeAppService.GetById(new EntityDto<int> { Id = Id });
            var editViewModel = new EdtiMXAttributeViewModel
            {
                MXAttributeInfo = modelDto
            };
            return View("_EditMXAttributeModal", editViewModel);
        }
    }
}