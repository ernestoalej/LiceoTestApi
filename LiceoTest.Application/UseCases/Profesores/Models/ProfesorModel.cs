using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiceoTest.Application.UseCases.Profesores.Models
{
	public class ProfesorModel
	{
		public int Id { get; set; }
		public required string Cedula { get; set; }
		public required string Nombres { get; set; }
		public required string Apellidos { get; set; }
		public DateTime FechaNacimiento { get; set; }
	}
}
