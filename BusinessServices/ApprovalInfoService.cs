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
    public class ApprovalInfoService : IApprovelInfoService
    {
        /// <summary>
        ///   IUnitOfWork private field 
        /// </summary>
        private readonly IUnitOfWork _unityOfWork;

        private readonly IEmailService _emailService;

        /// <summary>
        ///  Population ServiceConstructer
        /// </summary>
        /// <param name="unityOfWork"></param>
        public ApprovalInfoService(IUnitOfWork unityOfWork, IEmailService emailService)
        {
            this._unityOfWork = unityOfWork;
            this._emailService = emailService;
        }

        /// <summary>
        ///  Load population details by state
        /// </summary>
        /// <param name="stateIdList"></param>
        /// <returns></returns>
        public async Task<IEnumerable<ApprovaInfoDto>> LoadAllByIdAsync(int requestId)
        {
            try
            {
                var reqApprovalStatus = new List<ApprovaInfoDto>();
                var allApprovalInfoList = await _unityOfWork.ApprovalInfoRepository().GetAsync();
                var reqApprovalInfo = allApprovalInfoList.ToList().Where(x => x.RequestId == requestId);

                reqApprovalInfo.ToList().ForEach(x =>
                {
                    var replyEmailInfo = this._emailService.LoadReplyByRequestIdAsync(x.ManagerId, x.RequestId);
                    if(replyEmailInfo == null)
                    {
                        replyEmailInfo = new ApprovaInfoDto();
                        replyEmailInfo.IsApproved = null;
                        replyEmailInfo.ManagerId = x.ManagerId;
                        replyEmailInfo.RequestId = x.RequestId;
                        reqApprovalStatus.Add(replyEmailInfo);
                    }
                    else
                    {
                        reqApprovalStatus.Add(replyEmailInfo);
                    }
                });

                //return approvaInfoList?.Select(x => ConvertToDomain(x));
                return reqApprovalStatus;
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
        private static ApprovaInfoDto ConvertToDomain(ApprovaInfoEntity obj)
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
