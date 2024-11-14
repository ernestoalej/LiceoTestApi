using LiceoTest.Core.enums.Profesores;
using LiceoTest.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiceoTest.Core.Entities
{
	public class Profesor : Entity
	{
        public required string Cedula { get; set; }
        public required string Nombres { get; set; }
		public required string Apellidos { get; set; }
        public DateTime FechaNacimiento { get; set; }
        //public required List<SituacionCargoEnum> SituacionCargo { get; set; }
	}
}
