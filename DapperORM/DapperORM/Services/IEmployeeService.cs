using DapperORM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DapperORM.Services
{
    public interface IEmployeeService
    {
        IList<Employee> GetEmployees();
        public void Update(Employee employee);
        public void Create(Employee employee);
        public void Delete(Employee employee);
    }
}
