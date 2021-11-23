using ApprovalManagementSystem.Models;
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
    [Route("api/request")]
    [ApiController]
    public class RequestInfoController : ControllerBase
    {

        private readonly IRequestInfoService _requestInfoService;

        public RequestInfoController(IRequestInfoService approvalInfoService)
        {
            this._requestInfoService = approvalInfoService;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> LoadAllActiveAsync([ModelBinder(BinderType = typeof(CustomModelBinder))] RequestQuery query)
        {
            // TODO: Need to change 
            var requestInfoList = await this._requestInfoService.LoadAllByIdAsync(1);

            if (requestInfoList == null)
            {
                return NotFound();
            }

            return Ok(requestInfoList.Select(x => ConvertToModel(x)));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        private static RequestInfoModel ConvertToModel(RequestInfoDto obj)
        {
            if (obj == null)
            {
                return new RequestInfoModel();
            }

            return new RequestInfoModel()
            {
               Id = obj.Id,  
               CreateUserId =  obj.CreateUserId, 
               RequestInfo = obj.RequestInfo, 
               Status = obj.Status 
            };
        }
    }
}
