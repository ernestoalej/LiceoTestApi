using LiceoTest.Application.UseCases.Profesores.Queries;
using LiceoTest.Core.Entities;
using LiceoTest.Infrastructure.Data;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using LiceoTest.Application.UseCases.Profesores.Models;

namespace LiceoTest.Application.UseCases.Profesores.Handlers;
public class GetProfesoresListHandler : IRequestHandler<GetProfesoresListQuery, IEnumerable<ProfesorModel>>
{
	private readonly ApplicationContext _context;

	public GetProfesoresListHandler(ApplicationContext context)
    {
		_context = context ?? throw new ArgumentNullException(nameof(context));
	}

	public async Task<IEnumerable<ProfesorModel>> Handle(GetProfesoresListQuery request, CancellationToken cancellationToken)
	{
		var res = await _context.Profesores
			.Select(p => new ProfesorModel
			{
				Id = p.Id,
				Cedula = p.Cedula,
				Nombres = p.Nombres,
				Apellidos = p.Apellidos,
				FechaNacimiento = p.FechaNacimiento
			}).ToListAsync(cancellationToken: cancellationToken).ConfigureAwait(false);

		return res;
	}
}
