using Employee_WebApi.Exceptions;
using Employee_WebApi.Model;
using Employee_WebApi.Repository;

namespace Employee_WebApi.Service
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IGenericRepository<Employee> _repository;
        public EmployeeService(IGenericRepository<Employee> genericRepository)
        {
            _repository = genericRepository;
        }
        public string AddEmployee(Employee employee)
        {
           var emp=_repository.Add(employee);
           
            return "Employee Added Succesfully";

        }

        public List<Employee> GetAll()
        {
          return   _repository.GetAll().ToList();
        }

        public Employee GetById(Guid id)
        {
            var emp=_repository.GetAll().FirstOrDefault(x => x.Id == id);
            if (emp == null)
            {
                throw new InvalidInputException("Invalid Id");
            }
            return emp;

        }
    }
}
