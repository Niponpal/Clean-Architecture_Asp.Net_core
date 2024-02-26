using CleanArchitcure.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchitcure.Infrastructure.Configraion;

public class EmployeeCongigration : IEntityTypeConfiguration<Employee>
{
	public void Configure(EntityTypeBuilder<Employee> builder)
	{
		builder.ToTable(nameof(Employee));
		builder.HasKey(e => e.Id);
		builder.Property(e => e.Name).HasMaxLength(50).IsRequired();
		builder.Property(e => e.Email).HasMaxLength(50).IsRequired();
		builder.Property(e => e.Phone).HasMaxLength(50).IsRequired();
		builder.Property(e => e.Address).HasMaxLength(50).IsRequired();
		builder.HasData(new Employee
		{
			Id = 1,
			Name = "Nipon",
			Email = "niponpal@gimail.com",
			Phone = "asaer"

		});
		
	}
}
