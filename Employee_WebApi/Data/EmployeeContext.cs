using Employee_WebApi.Model;
using Microsoft.EntityFrameworkCore;

namespace Employee_WebApi.Data
{
    public class EmployeeContext:DbContext
    {
        public DbSet<Employee>Employees { get; set; }
        public EmployeeContext(DbContextOptions<EmployeeContext> options):base(options) 
        {
            
        }
    }
}
