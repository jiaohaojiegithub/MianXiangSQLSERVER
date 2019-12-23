using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.Web.Models;
using MianXiangProject.Controllers;
using MianXiangProject.DataTableOption.MXCompanyOption;
using MianXiangProject.DataTableOption.MXJobOption;
using MianXiangProject.DataTableOption.MXQuestionOption;
using MianXiangProject.DataTableOption.MXQuestionOption.Dtos;
using MianXiangProject.Web.Models.DataTablesViewDtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MianXiangProject.Web.Controllers
{
    public class MXQuestionController : MianXiangProjectControllerBase
    {
        private readonly IMXQuestionAppService _MXQuestionAppService;

        private readonly IMXJobAppService _mXJobAppService;
        private readonly IMXCompanyAppService _MXCompanyAppService;

        public MXQuestionController(IMXQuestionAppService MXQuestionAppService,
              IMXJobAppService mXJobAppService,
            IMXCompanyAppService MXCompanyAppService)
        {
            _MXQuestionAppService = MXQuestionAppService;
            _mXJobAppService = mXJobAppService;
            _MXCompanyAppService = MXCompanyAppService;
        }

        public async Task<IActionResult> Index()
        {
            var modelDto = (await _MXQuestionAppService.GetPaged(new GetMXQuestionsInput())).Items;
            var modeMXJob = (await _mXJobAppService.GetAllAsync()
        ).Items;
            var modelMXCompany = (await _MXCompanyAppService
               .GetAllAsync()
               ).Items;
            var viewModel = new MXQuestionViewModel
            {
                MXQuestionList = modelDto,
                MXCompanyList = modelMXCompany,
                MXJobList = modeMXJob
            };


            return View(viewModel);
        }
        [DontWrapResult, HttpPost]
        public async Task<IActionResult> GetListAsync(GetMXQuestionsInput input)
        {
            var result = await _MXQuestionAppService.GetPaged(input);
            return Json(new
            {
               // draw=(input.SkipCount/input.MaxResultCount)+1,//当前页
                recordsTotal= result.TotalCount,
                recordsFiltered=result.TotalCount,
                data= result.Items
            });
        }
        public async Task<IActionResult> EditMXQuestionModal(int Id)
        {
            var modelDto = await _MXQuestionAppService.GetById(new EntityDto<int> { Id = Id });
            var modeMXJob = (await _mXJobAppService.GetAllAsync()
      ).Items;
            var modelMXCompany = (await _MXCompanyAppService
               .GetAllAsync()
               ).Items;
            var editViewModel = new EdtiMXQuestionViewModel
            {
                MXQuestionInfo = modelDto,
                MXCompanyList = modelMXCompany,
                MXJobList = modeMXJob
            };
            return View("_EditMXQuestionModal", editViewModel);
        }
        /*
        [DontWrapResult]
        public JsonResult GetResultList(int limit = 10, int start = 0, int page=1)
        {

            var pagedTasks = _Question_BankAppService.GetAllAsync(new MXDataTable.Dto.PagedQuestion_BankResultRequestDto
            {
                SkipCount = offset,
                MaxResultCount = limit
            }).Result;

            return Json(new
            {
                total = pagedTasks.TotalCount,
                rows = pagedTasks.Items
            });
            //return Json(pagedTasks.Items);
        }
        */
    }
}