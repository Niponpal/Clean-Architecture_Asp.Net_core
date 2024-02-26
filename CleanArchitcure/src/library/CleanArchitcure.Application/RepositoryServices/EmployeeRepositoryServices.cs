using AutoMapper;
using CleanArchitcure.Application.ModelVm;
using CleanArchitcure.Application.Services;
using CleanArchitcure.Domain.Model;
using CleanArchitcure.Infrastructure.DataBase;

namespace CleanArchitcure.Application.RepositoryServices;

public class EmployeeRepositoryServices : RepositoryServices<Employee, EmployeeVm>, IEmployeeRepositoryServices
{
	public EmployeeRepositoryServices(IMapper mapper, ApplicationDbContext context) : base(mapper, context)
	{
	}

    public Task InsertAsync(EmployeeVm employeeVM, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
