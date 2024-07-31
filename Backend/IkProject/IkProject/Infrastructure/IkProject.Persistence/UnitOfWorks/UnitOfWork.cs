using IkProject.Application.Repositories;
using IkProject.Application.UnitOfWorks;
using IkProject.Persistence.Context;
using IkProject.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IkProject.Persistence.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IkPorjectDbContext _dbContext;
        public UnitOfWork(IkPorjectDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async ValueTask DisposeAsync() => await _dbContext.DisposeAsync();
 
        IReadRepository<T> IUnitOfWork.GetReadRepository<T>() => new ReadRepository<T>(_dbContext);

        IWriteRepository<T> IUnitOfWork.GetWriteRepository<T>() => new WriteRepository<T>(_dbContext);

        public int Save() => _dbContext.SaveChanges();

        public async Task<int> SaveAsync() => await _dbContext.SaveChangesAsync();
    }
}
