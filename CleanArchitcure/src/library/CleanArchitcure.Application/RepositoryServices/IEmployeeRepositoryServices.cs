using CleanArchitcure.Application.ModelVm;
using CleanArchitcure.Application.Services;
using CleanArchitcure.Domain.Model;

namespace CleanArchitcure.Application.RepositoryServices;

public interface IEmployeeRepositoryServices : IRepositoryServices<Employee, EmployeeVm>
{
	Task InsertAsync(EmployeeVm employeeVM, CancellationToken cancellationToken);
}
