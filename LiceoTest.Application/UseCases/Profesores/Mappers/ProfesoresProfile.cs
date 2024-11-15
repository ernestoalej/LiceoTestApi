using AutoMapper;
using LiceoTest.Application.UseCases.Profesores.Models;
using LiceoTest.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiceoTest.Application.UseCases.Profesores.Mappers
{
	public class ProfesoresProfile : Profile
	{
        public ProfesoresProfile()
        {
            CreateMap<Profesor, ProfesorModel>();
        }
    }
}
