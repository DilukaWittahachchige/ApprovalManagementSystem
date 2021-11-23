using ApprovalManagementSystem.Models;
using BusinessServices;
using Domain;
using IBusinessServices;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApprovalManagementSystem.Controllers
{
    [Route("api/approval")]
    [ApiController]
    public class ApprovalInfoController : ControllerBase
    {

        private readonly IApprovelInfoService _approvelInfoService;

        public ApprovalInfoController(IApprovelInfoService approvelInfoService)
        {
            this._approvelInfoService = approvelInfoService;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> LoadAllActiveAsync([ModelBinder(BinderType = typeof(CustomModelBinder))] RequestQuery query)
        {
            // TODO: Need to change 
            var approvelInfoList = await this._approvelInfoService.LoadAllByIdAsync(1);

            if (approvelInfoList == null)
            {
                return NotFound();
            }

            return Ok(approvelInfoList.Select(x => ConvertToModel(x)));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        private static ApprovalInfoModel ConvertToModel(ApprovaInfoDto obj)
        {
            if (obj == null)
            {
                return new ApprovalInfoModel();
            }

            return new ApprovalInfoModel()
            {
                Id = obj.Id,
                ManagerId = obj.ManagerId,
                RequestId = obj.RequestId,
                IsApproved = obj.IsApproved,
                Comment = obj.Comment 
            };
        }
    }
}
