using AutoMapper;
using FLASK_COFFEE_API.Areas.Client.Dtos.Auth;
using FLASK_COFFEE_API.Database.Models;

namespace FLASK_COFFEE_API.Areas.Client.Mappers
{
    public class AuthMapper : Profile
    {
        public AuthMapper()
        {

            CreateMap<RegisterDto, User>()
                .ForMember(d => d.Id, o => o.Ignore())
                .ForMember(d => d.UserActivation, o => o.Ignore())
                .ForMember(d => d.UserActivationId, o => o.Ignore());



            CreateMap<User, Basket>()
           .ForMember(d => d.User, o => o.MapFrom(u => u))
           .ForMember(d => d.Id, o => o.Ignore())
           .ForMember(d => d.CreatedAt, o => o.Ignore())
           .ForMember(d => d.UpdatedAt, o => o.Ignore())
           .ForMember(d => d.BasketProducts, o => o.Ignore());
        }
    }
}
