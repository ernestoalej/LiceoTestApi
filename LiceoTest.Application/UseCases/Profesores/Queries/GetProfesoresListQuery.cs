using LiceoTest.Application.UseCases.Profesores.Models;
using LiceoTest.Core.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiceoTest.Application.UseCases.Profesores.Queries
{
	public class GetProfesoresListQuery : IRequest<IEnumerable<ProfesorModel>>
	{
	}
}
