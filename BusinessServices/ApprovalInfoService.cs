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
        public async Task<IEnumerable<ApprovaInfoDto>> LoadAllByIdAsync(int id)
        {
            try
            {
                var approvaInfoList = await _unityOfWork.ApprovalInfoRepository().GetAsync();
                var emailInfo = await this._emailService.LoadEmailInfo(1);
                var replyInfo = LoadReplyUserInfo(emailInfo.ToList().FirstOrDefault().To);

                return approvaInfoList?.Select(x => ConvertToDomain(x));
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

        private string[] LoadReplyUserInfo(string replyToAddress)
        {
            //String replyFor = replyToAddress;
            //Int64 userId = Convert.ToInt64(replyFor.Substring(replyFor.StartsWith("+") + 3, replyFor.LastIndexOf("un")));
            //var info =  replyFor.Substring(replyFor.LastIndexOf("un") + 2, replyFor.IndexOf("@") - replyFor.LastIndexOf("un") - 2);

            var replyInfo = new string[2];

            return replyInfo;
        }

    }
}
