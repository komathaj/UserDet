using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emp.Models;
using Emp.DAL;
namespace Emp.BLL
{
    public class EmpBLL
    {
        public int Update(Employee emp)
        {
            var dataRepos = new EmployeeRepository();
            return dataRepos.Update(emp);
            
        }
        public int Delete(int userID)
        {
            var dataRepos = new EmployeeRepository();
            return dataRepos.Delete(userID);
        }

        public List<Employee> GetEmployees(int NoOfUsers)
        {
            var dataRepos = new EmployeeRepository();
            return dataRepos.GetEmployees(NoOfUsers);
        }

        public List<Employee> GetEmployees(string Name)
        {
            var dataRepos = new EmployeeRepository();
            return dataRepos.GetEmployees(Name);
        }
        public List<Employee> GetEmployees()
        {
            var dataRepos = new EmployeeRepository();
            return dataRepos.GetEmployees();
        }
        public Employee Get(int UserID)
        {
            var dataRepos = new EmployeeRepository();
            return dataRepos.Get(UserID);
        }
    }
}
