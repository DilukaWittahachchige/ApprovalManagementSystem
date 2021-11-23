using EF;
using EF.Models;
using IDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class ApprovalInfoRepository : GenericRepository<ApprovaInfoEntity>, IApprovalInfoRepository
    {
        /// <summary>
        ///  Constructer
        /// </summary>
        /// <param name="context"></param>
        public ApprovalInfoRepository(ApprovalManagementSystemContext context)
           : base(context)
        {

        }

        /// <summary>
        ///  Return all active student information
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<ApprovaInfoEntity>> LoadByRequestIdAsync()
        {
            throw new NotImplementedException();
        }
    }
}
