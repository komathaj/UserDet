using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace Emp.Models
{
    public class Employee
    {
       public Int32 ID { get; set; }
        public string Title { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public string Email { get; set; }
        
        public string DOB { get ; set ; }
        public string PhoneNumber { get; set; }
        public string Images { get; set; }
       
    }
}
