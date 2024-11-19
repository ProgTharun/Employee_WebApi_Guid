using Employee_WebApi.Model;

namespace Employee_WebApi.Service
{
    public interface IEmployeeService
    {
        public List<Employee> GetAll();
        public Employee GetById(Guid id);

        public string AddEmployee(Employee employee);

    }
}
