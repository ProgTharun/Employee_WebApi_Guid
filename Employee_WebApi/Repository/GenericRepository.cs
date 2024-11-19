
using Employee_WebApi.Data;
using Microsoft.EntityFrameworkCore;

namespace Employee_WebApi.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly EmployeeContext _employeeContext;
        private readonly DbSet<T> _table;
        public GenericRepository(EmployeeContext employeeContext)
        {
            _employeeContext = employeeContext;
            _table = _employeeContext.Set<T>();
        }
        public int Add(T entity)
        {
            _table.Add(entity);
            return _employeeContext.SaveChanges();
        }

        public IQueryable<T> GetAll()
        {
            return _table.AsQueryable();
        }

        public T GetByid(Guid id)
        {
            return _table.Find(id);
        }
    }
}
