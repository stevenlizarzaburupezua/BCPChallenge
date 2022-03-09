using BCP.TipoCambio.Domain;
using BCP.TipoCambio.Domain.Entities;
using BCP.TipoCambio.Repository.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using BCP.Domain.Seedwork;

namespace BCP.TipoCambio.Repository.UnitOfWork
{
    public class UnitOfWorkCore : IUnitOfWork
    {
        private BcpContext _context;
        private IStoreProcedureManager _storeProcedureManager;

        public UnitOfWorkCore(BcpContext context,
                              IStoreProcedureManager oIStoreProcedureManager)
        {
            _context = context;
            _storeProcedureManager = oIStoreProcedureManager;
        }

        #region PROCEDURES

        public void Exec(string name, Dictionary<string, object> parameters)
        {
            _storeProcedureManager.Exec(name, parameters);
        }

        public async Task ExecAsync(string name, Dictionary<string, object> parameters)
        {
            await Task.Factory.StartNew(() => Exec(name, parameters));
        }

        public List<T> Exec<T>(string name, Dictionary<string, object> parameters) where T : RawDTO
        {
            return _storeProcedureManager.Exec<T>(name, parameters);
        }
        public List<T> ExecFnc<T>(string name, Dictionary<string, object> parameters) where T : RawDTO
        {
            return _storeProcedureManager.ExecFnc<T>(name, parameters);
        }

        public async Task<List<T>> ExecAsync<T>(string name, Dictionary<string, object> parameters) where T : RawDTO
        {
            return await Task.Factory.StartNew(() => Exec<T>(name, parameters));
        }

        public List<Dictionary<string, object>> ExecDynamic(string name, Dictionary<string, object> parameters)
        {
            return _storeProcedureManager.ExecDynamic(name, parameters);
        }

        #endregion

        #region Detect Changes
        public void DetectChanges()
        {
            _context.ChangeTracker.DetectChanges();
        }
        #endregion

        #region Save Changes
        public void Save()
        {
            _context.SaveChanges();
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        private object GetPrimaryKeyValue(EntityEntry entry)
        {
            object[] arr = entry.Metadata.FindPrimaryKey().Properties
                     .Select(p => entry.Property(p.Name).CurrentValue)
                     .ToArray();

            return arr.FirstOrDefault();
        }

        #endregion

        #region Transactions

        public void BeginTransaction()
        {
            _context.Database.BeginTransaction();
        }

        public async Task BeginTransactionAsync()
        {
            await _context.Database.BeginTransactionAsync();
        }

        public void CommitTransaction()
        {
            _context.Database.CommitTransaction();
        }

        public void RollbackTransaction()
        {
            _context.Database.RollbackTransaction();
        }

        #endregion

        #region DISPOSED

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}
