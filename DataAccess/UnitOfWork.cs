using EF;
using IDataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace DataAccess
{
    public class UnitOfWork : IAsyncDisposable, IUnitOfWork
    {
        private PopulationAndHouseholdDataContext context = new PopulationAndHouseholdDataContext
            ();
        //Private Field for actual data repository and estimate data repositor
        private readonly IApprovaInfoRepository _actualDataRepository;
        private readonly IRequestInfoRepository _estimateDataRepository;

        //Constructor Dependency Injection
        public UnitOfWork(
            IApprovaInfoRepository actualDataRepository,
            IRequestInfoRepository estimateDataRepository
            )
        {
            this._actualDataRepository = actualDataRepository;
            this._estimateDataRepository = estimateDataRepository;
        }

        public IApprovaInfoRepository ActualDataRepository()
        {
            return this._actualDataRepository;
        }

        public IRequestInfoRepository EstimateDataRepository()
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
