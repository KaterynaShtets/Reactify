using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using Shared.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace DAL.EFCore
{
    public abstract class Repository<TEntity, TContext> : IRepository<TEntity>
        where TEntity: class, IEntity
        where TContext: DbContext
    {
        private readonly TContext _context;
        private readonly DbSet<TEntity> _entities;

        protected Repository(TContext context)
        {
            _context = context;
            _entities = context.Set<TEntity>();
        }

        public async Task<TEntity> Add(TEntity entity)
        {
            await _entities.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<TEntity> Delete(int id)
        {
            var entity = await _entities.FindAsync(id);
            _entities.Remove(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task<TEntity> Get(int id)
        {
            return await _entities.FindAsync(id);
        }

        public async Task<List<TEntity>> GetAll()
        {
            return await _entities.ToListAsync();
        }

        public  IQueryable<TEntity> GetAll2()
        {
            return _entities.AsQueryable<TEntity>();
        }
        //public DbSet<TEntity> GetAll3()
        //{
        //    return _context<>;
        //}

        public async Task<TEntity> Update(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
