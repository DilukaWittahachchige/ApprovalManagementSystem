﻿using Domain;
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
    
        public RequestInfoService(IUnitOfWork unityOfWork)
        {
            this._unityOfWork = unityOfWork;
        }
 
        public async Task<IEnumerable<RequestInfoDto>> LoadAllByIdAsync(int id)
        {
            try
            {
               var requestInfoList = await _unityOfWork.RequestInfoRepository().GetAsync();
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
