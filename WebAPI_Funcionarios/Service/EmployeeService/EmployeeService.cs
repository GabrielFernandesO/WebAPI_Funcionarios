using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using WebAPI_Funcionarios.DataContext;
using WebAPI_Funcionarios.Models;

namespace WebAPI_Funcionarios.Service.EmployeeService
{
    public class EmployeeService : IEmployeeInterface
    {
        //Only Read
        //Possibilite to access all db created
        private readonly ApplicationDBContext _context;

        //Connection with DB to do Operations with MySQLServer
        public EmployeeService(ApplicationDBContext context) 
        { 
            _context = context;
        }

        public async Task<ServiceResponse<List<EmployeesModel>>> GetEmployees()
        {
            ServiceResponse<List<EmployeesModel>> serviceResponse = new ServiceResponse<List<EmployeesModel>>();

            try
            {
                serviceResponse.data = _context.employees.ToList();

                if(serviceResponse.data.Count == 0)
                {
                    serviceResponse.message = "Data Not Found";
                }
            }
            catch (Exception ex )
            {
                serviceResponse.message = ex.Message;
                serviceResponse.success = false;
            }

            return serviceResponse;

        }


        public async Task<ServiceResponse<List<EmployeesModel>>> CreateEmployee(EmployeesModel newEmployee)
        {
            ServiceResponse<List<EmployeesModel>> serviceResponse = new ServiceResponse<List<EmployeesModel>>();

            try
            {

                if(newEmployee == null)
                {
                    serviceResponse.data = null;
                    serviceResponse.message = "No data";
                    serviceResponse.success=false;

                    return serviceResponse;
                }

                _context.Add(newEmployee);
                await _context.SaveChangesAsync();

                serviceResponse.data = _context.employees.ToList();
                serviceResponse.message = "Employee created";
            }
            catch (Exception ex)
            {

                serviceResponse.message = ex.Message;
                serviceResponse.success = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<EmployeesModel>> GetEmployeeByID(int id)
        {
            ServiceResponse<EmployeesModel> serviceResponse = new ServiceResponse<EmployeesModel>();

            try
            {
                //Select in DB to return just one employee
                EmployeesModel employee = _context.employees.FirstOrDefault(x => x.id == id);

                if(employee == null)
                {
                    serviceResponse.data=null;
                    serviceResponse.message = "Employee not found";
                    serviceResponse.success=false;

                    return serviceResponse;
                }

                serviceResponse.data = employee;
            }
            catch (Exception ex)
            {
                serviceResponse.message = ex.Message;
                serviceResponse.success = false;
            }

            return serviceResponse;

        }


        public async Task<ServiceResponse<List<EmployeesModel>>> DeleteEmployee(int id)
        {
            ServiceResponse<List<EmployeesModel>> serviceResponse = new ServiceResponse<List<EmployeesModel>>();

            try
            {
                EmployeesModel employee = _context.employees.FirstOrDefault(x => x.id == id);

                if(employee == null)
                {
                    serviceResponse.data=null;
                    serviceResponse.message = "Employee not found";
                    serviceResponse.success = false;
                }

                _context.employees.Remove(employee);
                await _context.SaveChangesAsync();
                

                serviceResponse.data = _context.employees.ToList();
                serviceResponse.message = "Employee deleted";

            }
            catch (Exception ex)
            {
                serviceResponse.message = ex.Message;
                serviceResponse.success = false;
            }

            return serviceResponse;
        }


        public async Task<ServiceResponse<List<EmployeesModel>>> UpdateEmployee(EmployeesModel employeeEdited)
        {
            ServiceResponse<List<EmployeesModel>> serviceResponse = new ServiceResponse<List<EmployeesModel>>();

            try
            {
                EmployeesModel employee = _context.employees.AsNoTracking().FirstOrDefault(x => x.id == employeeEdited.id);

                if(employee == null)
                {
                    serviceResponse.data = null;
                    serviceResponse.message = "Employee not found";
                    serviceResponse.success = false;

                    return serviceResponse;
                }

                employee.updated_date = DateTime.Now.ToLocalTime();

                _context.employees.Update(employeeEdited);
                await _context.SaveChangesAsync();

                serviceResponse.data = _context.employees.ToList();
                serviceResponse.message = "Employee updated";

            }
            catch (Exception ex)
            {
                serviceResponse.message = ex.Message;
                serviceResponse.success = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<EmployeesModel>>> InactiveEmployee(int id)
        {
            ServiceResponse<List<EmployeesModel>> serviceResponse = new ServiceResponse<List<EmployeesModel>>();

            try
            {
                EmployeesModel employee = _context.employees.FirstOrDefault(x => x.id == id);

                if( employee == null)
                {
                    serviceResponse.data=null;
                    serviceResponse.message = "Employee not found";
                    serviceResponse.success = false; 
                    return serviceResponse;
                }

                employee.active = false;
                employee.updated_date = DateTime.Now.ToLocalTime();

                _context.employees.Update(employee);
                await _context.SaveChangesAsync();

                serviceResponse.data = _context.employees.ToList();
                serviceResponse.message = "Employee inactived";

            }
            catch (Exception ex)
            {
                serviceResponse.message = ex.Message;
                serviceResponse.success = false;
            }

            return serviceResponse;

        }

  
    }
}
