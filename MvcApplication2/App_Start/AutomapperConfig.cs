using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcApplication2.App_Start
{
    using System.Web.UI;

    using AutoMapper;

    public class AutomapperConfig
    {
        public static void Register()
        {
            Mapper.CreateMap<Models.Application, Entities.Application>()
                .ForMember(dest => dest.Created, opt => opt.NullSubstitute(DateTime.Now))
                .ForMember(dest => dest.Modified, opt => opt.NullSubstitute(DateTime.Now));
            Mapper.CreateMap<Entities.Application, Models.Application>();
            Mapper.CreateMap<Models.Link, Entities.Link>();
            Mapper.CreateMap<Entities.Link, Models.Link>();
        }
    }
}