using IkProject.Application.Repositories;
using IkProject.Domain.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IkProject.Persistence.Repositories
{
    public class WriteRepository<T> : IWriteRepository<T> where T : BaseEntity, new()
    {
        private readonly DbContext _dbContext;

        public WriteRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        private DbSet<T> Table { get => _dbContext.Set<T>(); }

        public async Task AddAsync(T entity)
        {
            entity.Id = Guid.NewGuid();
            entity.Status = DataStatus.Created;
            entity.Created = DateTime.UtcNow;
            await Table.AddAsync(entity);
        }

        public async Task AddRangeAsync(IList<T> entities)
        {
            await Table.AddRangeAsync(entities);
        }

        public async Task<T> UpdateAsync(T entity)
        {
            entity.Status = DataStatus.Updated;
            entity.Updated = DateTime.UtcNow;
            await Task.Run(() => Table.Update(entity));
            return entity;
        }

        public async Task RemoveAsync(T entity)
        {
            await Task.Run(() => Table.Remove(entity));
        }

        public async Task DeleteAsync(T entity)
        {
            entity.Status = DataStatus.Deleted;
            entity.Deleted = DateTime.UtcNow;
            await Task.Run(() => Table.Update(entity));
        }
    }
}
