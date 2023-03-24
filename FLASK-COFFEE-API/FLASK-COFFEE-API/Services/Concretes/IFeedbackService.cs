using FLASK_COFFEE_API.Areas.Admin.Dtos.FeedBack;

namespace FLASK_COFFEE_API.Services.Concretes
{
    public interface IFeedbackService
    {
        Task<FeedBackListItemDto> AddAsync(FeedBackCreateDto model);
        Task<FeedBackListItemDto> UpdateAsync(int id, FeedBackUpdateDto dto);
    }
}
