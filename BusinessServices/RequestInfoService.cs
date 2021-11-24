using Common.Email;
using Domain;
using EF.Models;
using IBusinessServices;
using IDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessServices
{
    public class RequestInfoService : IRequestInfoService
    {
        /// <summary>
        ///   IUnitOfWork private field 
        /// </summary>
        private readonly IUnitOfWork _unityOfWork;

        private readonly IEmailService _emailService;
    
        public RequestInfoService(IUnitOfWork unityOfWork, IEmailService emailService)
        {
            this._unityOfWork = unityOfWork;
            this._emailService = emailService;
        }
 
        public async Task<IEnumerable<RequestInfoDto>> LoadAllByIdAsync(int id)
        {
            try
            {
               var requestInfoList = await _unityOfWork.RequestInfoRepository().GetAsync();
               var emailInfo = _emailService.SendEmailInfo(1);
               return requestInfoList?.Select(x => ConvertToDomain(x));
            }
            catch (Exception ex)
            {
                //TODO: Global exception handling 
                throw ex.InnerException;
            }
        }
 
        private static RequestInfoDto ConvertToDomain(RequestInfoEntity obj)
        {
            if (obj == null)
            {
                return new RequestInfoDto();
            }

            return new RequestInfoDto()
            {
                Id = obj.Id,  
                CreateUserId = obj.CreateUserId, 
                RequestInfo = obj.RequestInfo,  
                Status = obj.Status  
            };
        }

    }
}
