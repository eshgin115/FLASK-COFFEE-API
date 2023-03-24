using AutoMapper;
using FLASK_COFFEE_API.Areas.Admin.Dtos.FeedBack;
using FLASK_COFFEE_API.Database.Models;

namespace FLASK_COFFEE_API.Areas.Admin.Mappers
{
    public class FeedBackMapper : Profile
    {
        public FeedBackMapper()
        {
            CreateMap<FeedBack, FeedBackListItemDto>()
                .ForMember(d => d.RoleName, o => o.MapFrom(s => s.Role!.Name))
                .ForMember(d => d.FullName, o => o.MapFrom(s => s.Name))
                .ForMember(d => d.ProfilePhotoUrl, o => o.MapFrom(s => s.ImageNameInFileSystem));

            CreateMap<FeedBackCreateDto, FeedBack>()
             .ForMember(d => d.ImageName, o => o.MapFrom(s => s.ProfilePhoto != null ? s.ProfilePhoto.FileName : null))
              .ForMember(d => d.Id, o => o.Ignore());



            CreateMap<FeedBackUpdateDto, FeedBack>()
               .ForMember(d => d.ImageName, o => o.MapFrom((s, d) => s.ProfilePhoto != null
               ? s.ProfilePhoto.FileName :
               d.ImageName))
               .ForMember(d => d.ImageNameInFileSystem, o => o.Ignore())
               .ForMember(d => d.Id, o => o.Ignore());
        }
    }
}
