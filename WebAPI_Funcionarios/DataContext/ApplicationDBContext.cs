using Microsoft.EntityFrameworkCore;
using WebAPI_Funcionarios.Models;

namespace WebAPI_Funcionarios.DataContext
{
    public class ApplicationDBContext : DbContext
    {
        //Connection with DB using CodeFirst
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {
        }

        //Create table like our employeesModel
        public DbSet<EmployeesModel> employees { get; set; }
    }
}
