using Employee_Section.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Employee_Section.Interfaces
{
    public interface IEmployeeRepository
    {
        Task<List<Employee>> GetByAllAsync();
        Task<Employee> GetByIdAsync(int employeeId);
        Task<Employee> AddAsync(Employee employee);
        Task<Employee> UpdateAsync(Employee employee);
        Task<bool> DeleteAsync(int employeeId);
        Task<bool> IsEmployeeExistsAsync(string fullName);
    }
}
