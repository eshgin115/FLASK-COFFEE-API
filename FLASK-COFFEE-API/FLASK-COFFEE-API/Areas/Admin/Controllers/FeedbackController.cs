using AutoMapper;
using FLASK_COFFEE_API.Areas.Admin.Dtos.FeedBack;
using FLASK_COFFEE_API.Contracts.File;
using FLASK_COFFEE_API.Database;
using FLASK_COFFEE_API.Database.Models;
using FLASK_COFFEE_API.Services.Concretes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FLASK_COFFEE_API.Areas.Admin.Controllers;

[ApiController]
[Authorize]
public class FeedbackController : ControllerBase
{
    private readonly DataContext _dataContext;
    private readonly IFileService _fileService;
    private readonly IFeedbackService _feedbackService;
    private readonly IMapper _mapper;
    public FeedbackController
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
    #region List
    [HttpGet("list", Name = "admin-feedback-list")]
    public async Task<IActionResult> ListAsync()
    {
        var feedBacks = await _dataContext.FeedBacks.Include(f => f.Role).ToListAsync();
        var feedBacksDto = _mapper.Map<List<FeedBackListItemDto>>(feedBacks);

        feedBacksDto.ForEach(fbm => fbm.ProfilePhotoUrl = fbm.ProfilePhotoUrl != null
        ? _fileService.GetFileUrl(fbm.ProfilePhotoUrl, UploadDirectory.FeedBack)
        : null!);
        return Ok(feedBacksDto);
    }

    #endregion

    #region Add

    [HttpPost("add", Name = "admin-feedback-add")]
    public async Task<IActionResult> AddAsync([FromForm] FeedBackCreateDto dto)
    {
        return Created(string.Empty, await _feedbackService.AddAsync(dto));
    }
    #endregion



    #region Update

    [HttpPut("update/{id}", Name = "admin-feedback-update")]
    public async Task<IActionResult> UpdateAsync([FromRoute] int id, [FromForm] FeedBackUpdateDto dto)
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

        return Ok(_mapper.Map<FeedBackListItemDto>(feedBack));

    }
    #endregion
    #region Delete
    [HttpDelete("delete/{id}", Name = "admin-feedback-delete")]
    public async Task<IActionResult> DeleteAsync([FromRoute] int id)
    {
        var feedBack = await _dataContext.FeedBacks.FirstOrDefaultAsync(fb => fb.Id == id);

        if (feedBack is null) return NotFound();


        if (feedBack.ImageNameInFileSystem is not null)
            await _fileService.DeleteAsync(feedBack.ImageNameInFileSystem, UploadDirectory.FeedBack);


        _dataContext.FeedBacks.Remove(feedBack);

        await _dataContext.SaveChangesAsync();

        return NoContent();

    }

    #endregion
}
