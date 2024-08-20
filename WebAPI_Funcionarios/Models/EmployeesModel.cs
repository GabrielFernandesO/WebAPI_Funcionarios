using System.ComponentModel.DataAnnotations;
using WebAPI_Funcionarios.Enums;

namespace WebAPI_Funcionarios.Models
{
    public class EmployeesModel
    {
        //Model to build Employees

        //Define id as primary key
        [Key]
        public int id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set;}
        public EnumDepartament departament { get; set; }

        public bool active { get; set; }
        public EnumWorkShift work_shift { get; set; }
        public DateTime creation_date { get; set; } = DateTime.Now.ToLocalTime();
        public DateTime updated_date { get; set;} = DateTime.Now.ToLocalTime();

    }
}
