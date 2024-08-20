using WebAPI_Funcionarios.Models;

namespace WebAPI_Funcionarios.Service.EmployeeService
{
    public interface IEmployeeInterface
    {
        //Interface Methods
       //Get and Post return Lists, so we have to use Lists
        Task<ServiceResponse<List<EmployeesModel>>> GetEmployees();
        Task<ServiceResponse<List<EmployeesModel>>> CreateEmployee(EmployeesModel newEmployee);
        Task<ServiceResponse<EmployeesModel>> GetEmployeeByID(int id);
        Task<ServiceResponse<List<EmployeesModel>>> UpdateEmployee(EmployeesModel employeeEdited);
        Task<ServiceResponse<List<EmployeesModel>>> DeleteEmployee(int id);
        Task<ServiceResponse<List<EmployeesModel>>> InactiveEmployee(int id);

    }
}
