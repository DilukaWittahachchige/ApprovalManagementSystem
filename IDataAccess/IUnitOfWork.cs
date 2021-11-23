
using System.Threading.Tasks;

namespace IDataAccess
{
    public interface IUnitOfWork
    {
        IRequestInfoRepository RequestInfoRepository();
        IApprovalInfoRepository ApprovalInfoRepository();
        Task SaveAsync();
        ValueTask DisposeAsync();
    }
}
