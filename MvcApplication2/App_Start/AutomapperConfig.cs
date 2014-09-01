using System;

namespace MvcApplication2.App_Start
{
    using System.Collections;

    using AutoMapper;
    using Entities = MvcApplication2.Database.Entities;
    using Models = MvcApplication2.Models;


    public static class AutomapperConfig
    {
        public static void Register()
        {
            Mapper.CreateMap<Models.Application, Entities.Application>()
                .ForMember(dest => dest.Created, opt => opt.NullSubstitute(DateTime.Now))
                .ForMember(dest => dest.Modified, opt => opt.NullSubstitute(DateTime.Now));
            Mapper.CreateMap<Entities.Application, Models.Application>();
            Mapper.CreateMap<Entities.Category, Models.Category>();
            Mapper.CreateMap<Models.Link, Entities.Link>();
            Mapper.CreateMap<Entities.Link, Models.Link>();
        }
    }
}