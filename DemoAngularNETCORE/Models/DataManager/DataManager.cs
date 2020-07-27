using DemoAngularNETCORE.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoAngularNETCORE.Models.DataManager
{
    public class DataManager : IDataRepository<Employee>
    {
        readonly EmployeeContext _employeeContext;

        public DataManager(EmployeeContext context)
        {
            _employeeContext = context;
        }

        public IEnumerable<Employee> GetAll()
        {
            return _employeeContext.Employees.ToList();
        }

        public Employee Get(long id)
        {
            return _employeeContext.Employees
                  .FirstOrDefault(e => e.EmployeeId == id);
        }

        public void Add(Employee entity)
        {
            _employeeContext.Employees.Add(entity);
            _employeeContext.SaveChanges();
        }

        public void Update(Employee employee, Employee entity)
        {
            employee.FirstName = entity.FirstName;
            employee.LastName = entity.LastName;
            employee.Email = entity.Email;
            employee.PhoneNumber = entity.PhoneNumber;
            employee.Gender = entity.Gender;
            _employeeContext.SaveChanges();
        }

        public void Delete(Employee employee)
        {
            _employeeContext.Employees.Remove(employee);
            _employeeContext.SaveChanges();
        }
    }
}
