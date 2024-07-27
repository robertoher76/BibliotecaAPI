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

            CreateMap<Editorial, EditorialDto>()
                .ForMember(destination => destination.Codigo, options => options.MapFrom(source => source.id))
                .ForMember(destination => destination.NombreEditorial, options => options.MapFrom(source => source.Nombre))
                .ReverseMap();

            CreateMap<Libro, LibroDto>()
                .ForMember(destination => destination.Codigo, options => options.MapFrom(source => source.id))
                .ForMember(destination => destination.NombreLibro, options => options.MapFrom(source => source.Nombre))
                .ForMember(destination => destination.CodigoAutorLibro, options => options.MapFrom(source => source.CodigoAutor))
                .ForMember(destination => destination.CodigoEditorialLibro, options => options.MapFrom(source => source.CodigoEditorial))
                .ForMember(destination => destination.FechaLanzamientoLibro, options => options.MapFrom(source => source.FechaDeLanzamiento))
                .ReverseMap();
        }
    }
}
