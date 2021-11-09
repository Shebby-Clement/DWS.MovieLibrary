using AutoMapper;
using DWS.MovieLibrary.Domain.Dtos;
using DWS.MovieLibrary.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DWS.MovieLibrary.Domain.Config
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {

            CreateMap<MovieDto, Movie>();
            CreateMap<Movie, MovieDto>();

            CreateMap<Person, PersonDto>();
            CreateMap<PersonDto, Person>();

        }
    }
}
