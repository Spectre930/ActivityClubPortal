using ActivityClubPortal.API.Resources;
using AutoMapper;
using ids.core.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace ActivityClubPortal.API
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //Domain to Resource
            CreateMap<Event, EventResource>().ReverseMap();
            //Resource to Domain
            CreateMap<EventResource, Event>().ReverseMap();

            //Domain to Resource
            CreateMap<User, UserResource>().ReverseMap();
            //Resource to Domain
            CreateMap<UserResource, User>().ReverseMap();

            CreateMap<Role, RoleResource>().ReverseMap();
            CreateMap<RoleResource, RoleResource>().ReverseMap();

            CreateMap<Member, MemberResource>().ReverseMap();
            CreateMap<MemberResource, Member>().ReverseMap();

            CreateMap<Guide, GuideResource>().ReverseMap();
            CreateMap<GuideResource, Guide>().ReverseMap();

            CreateMap<Lookup, LookupResource>().ReverseMap();
            CreateMap<LookupResource, Lookup>().ReverseMap();




        }
    }

}

