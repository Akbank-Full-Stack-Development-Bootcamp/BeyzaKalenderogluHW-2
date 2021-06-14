using DapperORM.Models;
using DapperORM.Services;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Dapper;

namespace DapperORM.EmployeeDb
{
    public class EmployeeRepo : IEmployeeService
    {

        private string _connectionString = "Data Source=(localdb)\\Mssqllocaldb;Initial Catalog=DapperAPI;Integrated Security=True";
        //CREATE:
        public void Create(Employee employee)
        {
            using (var sqlConnection = new SqlConnection(_connectionString))
            {

                sqlConnection.Open();
                string sql = @"INSERT INTO Employees ( Name, Surname, Salary) VALUES ( @Name, @Surname, @Salary) ";
                sqlConnection.Query(sql, employee);

            }
        }
        // READ:
        public IList<Employee> GetEmployees()
        {   
            List<Employee> employees;
            using (var sqlConnection = new SqlConnection(_connectionString))
            {

                sqlConnection.Open();
                employees = sqlConnection.Query<Employee>("SELECT * FROM Employees").ToList();
     
            }
            return employees;
        }
        //UPDATE:
        public void Update(Employee employee)
        {
            using (var sqlConnection = new SqlConnection(_connectionString))
            {

                sqlConnection.Open();
                string sql = @"UPDATE Employees SET Name = @Name, Surname = @Surname, Salary = @Salary WHERE Id = @id";
                sqlConnection.Query(sql, employee);
                
            }
        }
        //DELETE:
        public void Delete(Employee employee)
        {
            using (var sqlConnection = new SqlConnection(_connectionString))
            {

                sqlConnection.Open();
                string sql = @"DELETE FROM Employees WHERE Id = @id";
                sqlConnection.Query(sql, employee);

            }
        }
    }
}
