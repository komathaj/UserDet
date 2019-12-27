using Dapper;
using Emp.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace Emp.DAL
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private SqlConnection con;
       

        private void connection()
        {
            string constr = @"Server=DESKTOP-BJ3UTJU\INSTANCE1; Initial Catalog=Celo; Integrated Security=True; MultipleActiveResultSets=True;";
            con = new SqlConnection(constr);


        }
       /// <summary>
       ///  This is used for getting one set of Employee entity
       /// </summary>
       /// <param name="UserID"> employee Id</param>
       /// <returns></returns>
       

        public Employee Get(int UserID)
        {
            connection();
            using (IDbConnection db = con)
            {
                return db.Query<Employee>("Select * From [Celo].[dbo].[User]  WHERE Id = @UserID", new { UserID }).SingleOrDefault();
            }
        }
        /// <summary>
        ///  Getting a list of Employees
        /// </summary>
        /// <param name="NoOfUsers"></param>
        /// <returns></returns>
        public List<Employee> GetEmployees(int NoOfUsers)
        {
            var lstEmployee = new List<Employee>();
            connection();
            using (IDbConnection db = con)
            {
                lstEmployee= db.Query<Employee>("Select * From [Celo].[dbo].[User]").ToList();
            }
            if (NoOfUsers > 0)
                lstEmployee = lstEmployee.Take<Employee>(NoOfUsers).ToList();
            return lstEmployee;

        }
        public List<Employee> GetEmployees()
        {
            var lstEmployee = new List<Employee>();
            connection();
            using (IDbConnection db = con)
            {
                
                lstEmployee = db.Query<Employee>("Select * From [Celo].[dbo].[User]").ToList();
            }
            
            
            return lstEmployee;

        }
        /// <summary>
        /// Based on the search parameter first name
        /// </summary>
        /// <param name="Name"></param>
        /// <returns></returns>
        public List<Employee> GetEmployees(string Name)
        {
            var lstEmployee = new List<Employee>();
            connection();
            using (IDbConnection db = con)
            {
                lstEmployee = db.Query<Employee>("Select * From [Celo].[dbo].[User]").ToList();
            }
            Name = Name.Trim();
            lstEmployee = lstEmployee.Where(x => x.FName.StartsWith(Name,StringComparison.OrdinalIgnoreCase) || x.LName.StartsWith(Name, StringComparison.OrdinalIgnoreCase)).ToList();
            return lstEmployee;
        }

        public int Update(Employee emp)
        {
            connection();
            using (IDbConnection db = con)
            {
                string sqlQuery = "UPDATE [Celo].[dbo].[User] SET Title = @Title, " +
                " FName = @FName, " + " LName = @LName,Email = @Email,DOB = @DOB,PhoneNumber = @PhoneNumber,Images = @Images " + "WHERE ID = @ID";
                int rowsAffected = db.Execute(sqlQuery, emp);
                return rowsAffected;
            }
        }

        public int Delete(int UserID)
        {
            connection();
            using (IDbConnection db = con)
            {
                var affectedRows = db.Execute("Delete from [Celo].[dbo].[User] Where ID = @ID", new { ID = UserID });
                return affectedRows;
                
            }
        }
    }
}
