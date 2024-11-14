using LiceoTest.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiceoTest.Infrastructure.Data.Configurations
{
	public class ProfesorConfiguration : IEntityTypeConfiguration<Profesor>
	{
		public void Configure(EntityTypeBuilder<Profesor> builder)
		{
			ArgumentNullException.ThrowIfNull(builder, nameof(builder));

			builder.HasKey(e => e.Id);

			builder.ToTable("T_Profesores");

			builder.Property(p => p.Nombres).HasMaxLength(60);
			builder.Property(p => p.Apellidos).HasMaxLength(60);

			builder.HasIndex(e => e.Cedula).IsUnique();


			builder.HasData(
				new Profesor
				{
					Id = 1,
					Cedula = "V-4629015",
					Nombres = "Fredy Ernesto",
					Apellidos = "Contreras Mendoza",
					FechaNacimiento = new DateTime(1953, 7, 27),
					CreatedBy = 1
			});
		}
	}
}
