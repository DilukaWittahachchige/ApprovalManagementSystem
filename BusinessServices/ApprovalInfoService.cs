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
    public class ApprovalInfoService : IApprovelInfoService
    {
        /// <summary>
        ///   IUnitOfWork private field 
        /// </summary>
        private readonly IUnitOfWork _unityOfWork;

        /// <summary>
        ///  Population ServiceConstructer
        /// </summary>
        /// <param name="unityOfWork"></param>
        public ApprovalInfoService(IUnitOfWork unityOfWork)
        {
            this._unityOfWork = unityOfWork;
        }

        /// <summary>
        ///  Load population details by state
        /// </summary>
        /// <param name="stateIdList"></param>
        /// <returns></returns>
        public async Task<IEnumerable<ApprovaInfoDto>> LoadAllByIdAsync(int id)
        {
            try
            {
                var approvaInfoList = new List<ApprovaInfoDto>();

               

                return approvaInfoList;
            }
            catch (Exception ex)
            {
                //TODO: Global exception handling 
                throw ex.InnerException;
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="isActual"></param>
        /// <returns></returns>
        private static ApprovaInfoDto ConvertToDomainActual(ApprovaInfoEntity obj)
        {
            if (obj == null)
            {
                return new ApprovaInfoDto();
            }

            return new ApprovaInfoDto()
            {
                Id = obj.Id,
                Comment = obj.Comment,
                ManagerId = obj.ManagerId,
                RequestId = obj.RequestId,
                IsApproved = obj.IsApproved
            };
        }
   
    }
}
