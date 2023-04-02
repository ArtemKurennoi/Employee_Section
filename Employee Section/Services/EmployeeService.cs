using Employee_Section.Models;
using System.Threading.Tasks;
using System;
using Employee_Section.Interfaces;
using System.Collections.Generic;

namespace Employee_Section.Services
{
    /// <summary>
    /// Cлой бизнес-логики.
    /// </summary>
    public class EmployeeService : IEmployeeService
    {
        // Репозиторий для работы с базой данных.
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<List<Employee>> GetEmployeeAllAsync()
        {
            return await _employeeRepository.GetByAllAsync();
        }

        public async Task<Employee> GetEmployeeByIdAsync(int id)
        {
            var employee = await _employeeRepository.GetByIdAsync(id);

            if (employee == null)
            {
                throw new InvalidOperationException("Сотрудник не найден");
            }

            return employee;
        }

        public async Task<Employee> CreateEmployeeAsync(Employee employee)
        {
            if (await _employeeRepository.IsEmployeeExistsAsync(employee.FullName))
            {
                throw new InvalidOperationException("Сотрудник с таким ФИО уже существует");
            }

            await _employeeRepository.AddAsync(employee);

            return employee;
        }

        public async Task<Employee> UpdateEmployeeAsync(Employee employee)
        {
            var existingEmployee = await _employeeRepository.GetByIdAsync(employee.Id);

            if (existingEmployee == null)
            {
                throw new InvalidOperationException("Сотрудник не найден");
            }

            if (await _employeeRepository.IsEmployeeExistsAsync(employee.FullName))
            {
                throw new InvalidOperationException("Сотрудник с таким ФИО уже существует");
            }

            await _employeeRepository.UpdateAsync(existingEmployee);

            return existingEmployee;
        }

        public async Task DeleteEmployeeAsync(int id)
        {
            var result = await _employeeRepository.DeleteAsync(id);

            if (result)
            {
                throw new InvalidOperationException("Сотрудник не найден");
            }
        }
    }
}
