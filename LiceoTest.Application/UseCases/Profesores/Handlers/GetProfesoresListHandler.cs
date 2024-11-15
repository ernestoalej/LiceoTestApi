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
using AutoMapper.QueryableExtensions;
using AutoMapper;

namespace LiceoTest.Application.UseCases.Profesores.Handlers;
public class GetProfesoresListHandler : IRequestHandler<GetProfesoresListQuery, IEnumerable<ProfesorModel>>
{
	private readonly ApplicationContext _context;
	private readonly IMapper _mapper;

	public GetProfesoresListHandler(ApplicationContext context, IMapper mapper)
    {
		_context = context ?? throw new ArgumentNullException(nameof(context));
		_mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
	}

	public async Task<IEnumerable<ProfesorModel>> Handle(GetProfesoresListQuery request, CancellationToken cancellationToken)
	{
		var res = await _context.Profesores
			.ProjectTo<ProfesorModel>(_mapper.ConfigurationProvider)
			.ToListAsync(cancellationToken);

		return res;
	}
}
