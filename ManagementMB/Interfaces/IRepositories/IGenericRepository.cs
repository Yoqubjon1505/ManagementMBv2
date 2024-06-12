namespace ManagementMB.Interfaces.IRepositories
{
    public interface IGenericRepository<T>
    {
        IQueryable<T> GetAll();
        T GetById(Guid id);
        void Add(T entity);
        void Update(T entity);
        void Delete(Guid id);
    }
}
