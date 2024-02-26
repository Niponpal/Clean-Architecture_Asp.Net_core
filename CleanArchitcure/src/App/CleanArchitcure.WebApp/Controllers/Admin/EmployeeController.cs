using CleanArchitcure.Application.ModelVm;
using CleanArchitcure.Application.RepositoryServices;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitcure.WebApp.Controllers.Admin
{
	public class EmployeeController : Controller
	{
		private readonly IEmployeeRepositoryServices employeeRepository;

		public EmployeeController(IEmployeeRepositoryServices employeeRepository)
		{
			this.employeeRepository = employeeRepository;
		}

		public async Task<ActionResult<EmployeeVm>> Index(CancellationToken cancellationToken)
		{
			return View(await employeeRepository.GetAllAsync(cancellationToken));
		}
		[HttpGet]
		public async Task<ActionResult<EmployeeVm>> CreateOrEdit(CancellationToken cancellationToken, int id)
		{
			if (id == 0)
			{
				return View(new EmployeeVm());
			}
			else
			{
				var entitys = await employeeRepository.GetByIdAsync(id, cancellationToken);
				return View(entitys);
			}
		}
		[HttpPost]
		public async Task<ActionResult<EmployeeVm>> CreateOrEdit(int id, CancellationToken cancellationToken, EmployeeVm employeeVM)
		{
			if (id == 0)
			{
				if (ModelState.IsValid)
				{
					  await employeeRepository.InsertAsync(id,employeeVM, cancellationToken);
					return RedirectToAction("Index");
				}

			}
			else
			{
				await employeeRepository.UpdatedAsync(id, employeeVM, cancellationToken);
				return RedirectToAction("Index");
			}
			return View(employeeVM);
		}
		public async Task<ActionResult<EmployeeVm>> Deleted(int id, CancellationToken cancellationToken)
		{
			if (id != 0)
			{
				await employeeRepository.DeltedASync(id, cancellationToken);
				return RedirectToAction("Index");
			}
			return RedirectToAction("Index");
		}
		public async Task<ActionResult<EmployeeVm>> Details(int id, CancellationToken cancellationToken)
		{
			var entiys = await employeeRepository.GetByIdAsync(id, cancellationToken);
			return View(entiys);
		}
	}
}
