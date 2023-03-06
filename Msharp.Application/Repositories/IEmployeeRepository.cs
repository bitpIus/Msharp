using Msharp.Domain.Entities;

namespace Msharp.Domain.Interfaces.Repositories;


public interface IEmployeeRepository
{
    IEnumerable<Employee> GetEmployees(int factoryId, bool trackChanges);
    Employee GetEmployee(int factoryId, int employeeId, bool trackChanges);
}
