namespace Employee_WebApi.Repository
{
    public interface IGenericRepository<T>
    {
        public IQueryable<T> GetAll();
        public T GetByid(Guid id);

        public int Add(T entity);

    }
}
