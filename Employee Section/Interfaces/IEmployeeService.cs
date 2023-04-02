using Employee_Section.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Employee_Section.Services
{
    public interface IEmployeeService
    {
        Task<List<Employee>> GetEmployeeAllAsync();
        Task<Employee> GetEmployeeByIdAsync(int id);
        Task<Employee> CreateEmployeeAsync(Employee employee);
        Task<Employee> UpdateEmployeeAsync(Employee employee);
        Task DeleteEmployeeAsync(int id);
    }
}
