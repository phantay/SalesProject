using DALayer.Infrastructure;
using DALayer.Model;
using System.Collections.Generic;

namespace DALayer.Respository
{
    public class ManageAccountRepository : RepositoryBase<Employee>
    {
        public ManageAccountRepository(SalesContext context) :base(context)
        {
        }

        public void Create(Employee employee)
        {
            context.Employees.Add(employee);
        }
        
        public void GetEmployee(string id)
        {
            List<Employee> _employeeList = new List<Employee>();
            //var myResult = (from Employee in context.Employees
            //                select new
            //                {
            //                    Employee.Id,
            //                    Employee.FirstName,
            //                    Employee.LastName,
            //                    Employee.Email,
            //                    Employee.Contact,
            //                    Employee.Gender,
            //                    Employee.Address,
            //                    Employee.Username,
            //                    Employee.Password
            //                }).ToList()
            //                .Select(x => new Employee
            //                {
            //                    Id = x.Id,
            //                    FirstName = x.FirstName,
            //                    LastName = x.LastName,
            //                    Email = x.Email,
            //                    Contact = x.Contact,
            //                    Gender = x.Gender,
            //                    Address = x.Address,
            //                    Username = x.Username,
            //                    Password = x.Password
            //                }).ToList();

        }
    }
}
