using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Web.Models;
using MianXiangProject.Controllers;
using MianXiangProject.DataTableOption.MXCompanyOption;
using MianXiangProject.DataTableOption.MXJobOption;
using MianXiangProject.DataTableOption.MXQuestionOption;
using MianXiangProject.DataTableOption.MXQuestionOption.Dtos;
using MianXiangProject.Web.Models.DataTablesViewDtos;
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
            var modelDto = (await _MXQuestionAppService.GetAllAsync()).Items;
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

        //public async Task<IActionResult> EditMXQuestionModal(int Id)
        //{
        //    var modelDto = await _MXQuestionAppService.GetById(new EntityDto<int> { Id = Id });
        //    var editViewModel = new EdtiMXQuestionViewModel
        //    {
        //        MXQuestionInfo = modelDto
        //    };
        //    return View("_EditMXQuestionModal", editViewModel);
        //}
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