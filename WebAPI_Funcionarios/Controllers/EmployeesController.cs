using Microsoft.AspNetCore.Mvc;
using WebAPI_Funcionarios.Models;
using WebAPI_Funcionarios.Service.EmployeeService;

namespace WebAPI_Funcionarios.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeInterface _employeeInterface;

        public EmployeesController(IEmployeeInterface employeeInterface)
        {
            _employeeInterface = employeeInterface;
        }
        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<EmployeesModel>>>> GetEmployees()
        {
            return Ok(await _employeeInterface.GetEmployees());
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<EmployeesModel>>>> CreateEmployee(EmployeesModel newEmployee)
        {
            return Ok(await _employeeInterface.CreateEmployee(newEmployee));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<EmployeesModel>>> GetEmployeeByID(int id)
        {
            return Ok(await _employeeInterface.GetEmployeeByID(id));
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<EmployeesModel>>> UpdateEmployee(EmployeesModel employeeEdited)
        {
            return Ok(await _employeeInterface.UpdateEmployee(employeeEdited));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<List<EmployeesModel>>>> DeleteEmployee(int id)
        {
            return Ok(await _employeeInterface.DeleteEmployee(id));
        }


        [HttpPut("inactiveEmployee/{id}")]
        public async Task<ActionResult<ServiceResponse<EmployeesModel>>> InactiveEmployee(int id)
        {
            return Ok(await _employeeInterface.InactiveEmployee(id));
        }
    }
}
