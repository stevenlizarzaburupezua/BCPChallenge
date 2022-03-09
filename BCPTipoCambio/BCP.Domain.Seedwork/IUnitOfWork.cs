using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BCP.Domain.Seedwork
{
    public interface IUnitOfWork : ISql, IDisposable
    {
        void DetectChanges();
        void Save();
        Task SaveAsync();
        void BeginTransaction();
        Task BeginTransactionAsync();
        void CommitTransaction();
        void RollbackTransaction();
    }
}
