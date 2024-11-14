using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiceoTest.Shared
{
	public abstract class AuditableEntity
	{
		public int CreatedBy { get; set; }
		public DateTime CreatedAt { get; set; }
		public int? UpdatedBy { get; set; }
		public DateTime? UpdatedAt { get; set; }
	}
}
