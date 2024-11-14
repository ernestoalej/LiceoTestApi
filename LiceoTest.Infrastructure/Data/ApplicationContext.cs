using Audit.EntityFramework;
using Audit.EntityFramework.Interceptors;
using LiceoTest.Core.Entities;
using LiceoTest.Shared;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LiceoTest.Infrastructure.Data;

public class ApplicationContext : AuditDbContext, IUnitOfWork
{

	public virtual DbSet<Profesor> Profesores { get; set; }


    public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		base.OnModelCreating(modelBuilder); // Configuraciones adicionales si es necesario

		modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

	}
	public async Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default)
	{

		var currentUserId = 1; // TODO: Por ahora como no está integrados los usuarios dejamos solo id = 1, que sería el admin.
			//(await Users.FirstOrDefaultAsync(u => u.UserName == _userNameResolver.UserName, cancellationToken))
			//?.Id ??
			//0; // seeder

		//await _mediator.DispatchDomainEventsAsync(this); // TODO: este método lo dejamos comentado porque por ahora usaremos lo eventos de dominio.

		foreach (var entity in ChangeTracker.Entries()
					 .Where(e => e.State is EntityState.Added or EntityState.Modified))
		{
			entity.Property(entity.State == EntityState.Added ? "CreatedAt" : "UpdatedAt").CurrentValue =
				DateTime.UtcNow;
			entity.Property(entity.State == EntityState.Added ? "CreatedBy" : "UpdatedBy").CurrentValue = currentUserId;
		}

		await base.SaveChangesAsync(cancellationToken);

		return true;
	}

	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
	{
		// optionsBuilder.UseSqlServer(_configuration.GetConnectionString("effic")).EnableSensitiveDataLogging();
		optionsBuilder.AddInterceptors(new AuditCommandInterceptor());
	}
}
