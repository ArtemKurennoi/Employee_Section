using Employee_Section.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using Employee_Section.Context;
using Employee_Section.Interfaces;

namespace Employee_Section.Infrastructure
{
    /// <summary>
    /// Cлой доступа к данным.
    /// </summary>
    public class EmployeeRepository : IEmployeeRepository
    {
        // Контекст базы данных.
        private readonly EmployeeDbContext _context;

        public EmployeeRepository(EmployeeDbContext context)
        {
            _context = context;
        }

        public async Task<List<Employee>> GetByAllAsync()
        {
            return await _context.Employees.ToListAsync();
        }

        public async Task<Employee> GetByIdAsync(int employeeId)
        {
            return await _context.Employees.FindAsync(employeeId);
        }

        public async Task<Employee> AddAsync(Employee employee)
        {
            await _context.Employees.AddAsync(employee);
            await _context.SaveChangesAsync();

            return employee;
        }

        public async Task<Employee> UpdateAsync(Employee employee)
        {
            _context.Employees.Update(employee);
            await _context.SaveChangesAsync();

            return employee;
        }

        public async Task<bool> DeleteAsync(int employeeId)
        {
            var employee = await _context.Employees.FindAsync(employeeId);

            if (employee != null)
            {
                _context.Employees.Remove(employee);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<bool> IsEmployeeExistsAsync(string fullName)
        {
            return await _context.Set<Employee>().AnyAsync(e => e.FullName == fullName);
        }

    }
}
