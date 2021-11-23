
using System.Threading.Tasks;

namespace IDataAccess
{
    public interface IUnitOfWork
    {
        IRequestInfoRepository EstimateDataRepository();
        IApprovaInfoRepository ActualDataRepository();
        Task SaveAsync();
        ValueTask DisposeAsync();
    }
}
