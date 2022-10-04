using Microsoft.EntityFrameworkCore;
using OfertaFone.Data;
using OfertaFone.Domain.Entities;
using OfertaFone.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfertaFone.Infra.Data.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity
    {
        protected DatabaseContext _applicationDbContext;

        public IQueryable<TEntity> Table => _applicationDbContext.Set<TEntity>().AsQueryable();

        public Repository(DatabaseContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="domain"></param>
        /// <returns></returns>
        public Task<TEntity> Delete(TEntity domain)
        {
            _applicationDbContext.Remove(domain);
            return Task.FromResult(domain);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<TEntity> FindById(int? id) => await _applicationDbContext.Set<TEntity>().FindAsync(id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="domain"></param>
        /// <returns></returns>
        public Task<TEntity> Insert(TEntity domain)
        {
            _applicationDbContext.Add(domain);
            return Task.FromResult(domain);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="domain"></param>
        /// <returns></returns>
        public Task<TEntity> Update(TEntity domain)
        {
            _applicationDbContext.Update(domain);
            return Task.FromResult(domain);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task CommitAsync() => await _applicationDbContext.SaveChangesAsync();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<List<TEntity>> FindAll() => await _applicationDbContext.Set<TEntity>().ToListAsync();
    }
}
