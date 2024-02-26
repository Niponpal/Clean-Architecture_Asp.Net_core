using AutoMapper;
using CleanArchitcure.Domain.Model;

namespace CleanArchitcure.Application.ModelVm;
[AutoMap(typeof(Employee),ReverseMap = true)]
public class EmployeeVm
{
	public int Id { get; set; }
	public string Name { get; set; } = string.Empty;
	public string Email { get; set; } = string.Empty;
	public string Phone { get; set; } = string.Empty;
	public string Address { get; set; } = string.Empty;
}
