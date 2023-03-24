using AutoMapper;
using FLASK_COFFEE_API.Areas.Admin.Dtos.FeedBack;
using FLASK_COFFEE_API.Contracts.File;
using FLASK_COFFEE_API.Database;
using FLASK_COFFEE_API.Database.Models;
using FLASK_COFFEE_API.Services.Concretes;
using Microsoft.EntityFrameworkCore;

namespace FLASK_COFFEE_API.Services.Services
{
    public class FeedbackService : IFeedbackService
    {
        private readonly DataContext _dataContext;
        private readonly IFileService _fileService;
        private readonly IFeedbackService _feedbackService;
        private readonly IMapper _mapper;
        public FeedbackService
            (DataContext dataContext,
            IFileService fileService,
            IMapper mapper,
            IFeedbackService feedbackService)
        {
            _dataContext = dataContext;
            _fileService = fileService;
            _mapper = mapper;
            _feedbackService = feedbackService;
        }
        public async Task<FeedBackListItemDto> AddAsync(FeedBackCreateDto model)
        {
            var feedBack = _mapper.Map<FeedBack>(model);

            feedBack.ImageNameInFileSystem =
                 await _fileService.UploadAsync(model.ProfilePhoto, UploadDirectory.FeedBack);

            await _dataContext.FeedBacks.AddAsync(feedBack);

            await _dataContext.SaveChangesAsync();

            return  _mapper.Map<FeedBackListItemDto>(feedBack);
        }
        public async Task<FeedBackListItemDto> UpdateAsync(int id, FeedBackUpdateDto dto)
        {

            var feedBack = await _dataContext.FeedBacks
                .AsNoTracking()
                .FirstOrDefaultAsync(fb => fb.Id == id);


            if (feedBack is null) return NotFound();


            string feedBackPpImageNameInFileSystem = null!;
            if (dto.ProfilePhoto is not null)
            {
                await _fileService.DeleteAsync
                    (feedBack.ImageNameInFileSystem, UploadDirectory.FeedBack);

                feedBackPpImageNameInFileSystem = await _fileService.UploadAsync
                    (dto.ProfilePhoto, UploadDirectory.FeedBack);
            }


            _mapper.Map(dto, feedBack);

            feedBack.ImageNameInFileSystem = feedBackPpImageNameInFileSystem ?? feedBack.ImageNameInFileSystem;
            await _dataContext.SaveChangesAsync();

            return _mapper.Map<FeedBackListItemDto>(feedBack);
        }
    }
}
