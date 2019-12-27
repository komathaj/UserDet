using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emp.Models;
namespace Emp.DAL
{
    public interface IEmployeeRepository
    {
         int Update(Employee emp);
        int Delete(int UserID);

        Employee Get(int UserID);
        List<Employee> GetEmployees(int NoOfUsers);
        List<Employee> GetEmployees(string Name);
        List<Employee> GetEmployees();

    }
}
