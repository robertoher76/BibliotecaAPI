﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Biblioteca.Entities.DTO;
using Biblioteca.Entities.Models;

namespace Biblioteca.BL.Automapper
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile() 
        {
            CreateMap<Autor, AutorDto>()
                .ForMember(destination => destination.Codigo, options => options.MapFrom(source => source.id))
                .ForMember(destination => destination.NombreAutor, options => options.MapFrom(source => source.Nombre))
                .ForMember(destination => destination.ApellidoAutor, options => options.MapFrom(source => source.Apellido))
                .ReverseMap();

        }
    }
}
