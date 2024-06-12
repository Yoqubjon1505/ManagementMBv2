using ManagementMB.Infrastructure;
using ManagementMB.Interfaces.IRepositories;
using ManagementMB.Models;
using Microsoft.EntityFrameworkCore;

namespace ManagementMB.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly AppDbContext _appDbContext;
        public GenericRepository(AppDbContext appDbContext)
        {
            _appDbContext=appDbContext;
        }
        public void Add(T entity)
        {
           _appDbContext.Set<T>().Add(entity);
            _appDbContext.SaveChanges();
        }

        public void Delete(Guid id)
        {
            var item= _appDbContext.Set<T>().Find(id);
            _appDbContext.Set<T>().Remove(item);
            _appDbContext.SaveChanges();
        }

        public IQueryable<T> GetAll()
        {
            return _appDbContext.Set<T>();
        }

        public T GetById(Guid id)
        {
            return _appDbContext.Set<T>().Find(id);
        }

        public void Update(T entity)
        {
            _appDbContext.Entry(entity).State = EntityState.Modified;
            _appDbContext.SaveChanges();
        }
    }
}
