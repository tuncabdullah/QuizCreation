using Microsoft.EntityFrameworkCore;
using QuizCreation.Core.Data.Abstract;
using QuizCreation.Entities.Concrete.Common;
using System.Linq.Expressions;
namespace QuizCreation.Core.Data.Concrete
{

    public class EfEntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity> where TEntity : BaseEntity, new()
    {
        protected readonly DbContext _context;
        private DbSet<TEntity> _dbSet;
        public EfEntityRepositoryBase(DbContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }
        public async Task AddAsync(TEntity entity)
         => await _dbSet.AddAsync(entity);
        public async Task AddRangeAsync(IEnumerable<TEntity> entities)
         => await _dbSet.AddRangeAsync(entities);

        public IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {  return filter == null ?
                _dbSet.ToList() :
                _dbSet.Where(filter).ToList(); 
        }

        public TEntity GetById(Expression<Func<TEntity, bool>> filter)
        {
            return _dbSet.SingleOrDefault(filter);
        }

        public void Remove(TEntity entity)
         => _dbSet.Remove(entity);

        public void RemoveRange(IEnumerable<TEntity> entities)
         => _dbSet.RemoveRange(entities);

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
