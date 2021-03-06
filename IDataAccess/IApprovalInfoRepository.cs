using EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDataAccess
{
    public interface IApprovalInfoRepository : IGenericRepository<ApprovaInfoEntity>
    {
        Task<IEnumerable<ApprovaInfoEntity>> LoadByRequestIdAsync();
    }
}
