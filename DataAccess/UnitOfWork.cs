using EF;
using IDataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace DataAccess
{
    public class UnitOfWork : IAsyncDisposable, IUnitOfWork
    {
        private ApprovalManagementSystemContext context = new ApprovalManagementSystemContext
            ();
        //Private Field for actual data repository and estimate data repositor
        private readonly IApprovalInfoRepository _actualDataRepository;
        private readonly IRequestInfoRepository _estimateDataRepository;

        //Constructor Dependency Injection
        public UnitOfWork(
            IApprovalInfoRepository actualDataRepository,
            IRequestInfoRepository estimateDataRepository
            )
        {
            this._actualDataRepository = actualDataRepository;
            this._estimateDataRepository = estimateDataRepository;
        }

        public IApprovalInfoRepository ApprovalInfoRepository()
        {
            return this._actualDataRepository;
        }

        public IRequestInfoRepository RequestInfoRepository()
        {
            return this._estimateDataRepository;
        }

        public async Task SaveAsync()
        {
            await context.SaveChangesAsync();
        }

        private bool disposed = false;

        protected virtual async Task DisposeAsync(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    await context.DisposeAsync();
                }
            }
            this.disposed = true;
        }

        /// <summary>
        ///  Object management / Garbage collection 
        /// </summary>
        public async ValueTask DisposeAsync()
        {
            await DisposeAsync(true);
            GC.SuppressFinalize(this);
        }
    }
}
