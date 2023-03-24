using FLASK_COFFEE_API.Contracts.File;
using FLASK_COFFEE_API.Services.Concretes;

namespace FLASK_COFFEE_API.Services.Services
{
    public class FileService : IFileService
    {
        private readonly ILogger<FileService>? _logger;

        public FileService(ILogger<FileService>? logger)
        {
            _logger = logger;
        }
        public async Task<string> UploadAsync(IFormFile formFile, UploadDirectory uploadDirectory)
        {
            string directoryPath = GetUploadDirectory(uploadDirectory);

            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }

            var imageNameInSystem = GenerateUniqueFileName(formFile.FileName);
            var filePath = Path.Combine(directoryPath, imageNameInSystem);

            try
            {
                using FileStream fileStream = new FileStream(filePath, FileMode.Create);
                await formFile.CopyToAsync(fileStream);
            }
            catch (Exception e)
            {
                _logger!.LogError(e, "Error occured in file service");

                throw;
            }

            return imageNameInSystem;
        }

        public async Task DeleteAsync(string? fileName, UploadDirectory uploadDirectory)
        {
            ArgumentNullException.ThrowIfNull(fileName);
            var deletePath = Path.Combine(GetUploadDirectory(uploadDirectory), fileName!);

            await Task.Run(() => File.Delete(deletePath));
        }

        private string GetUploadDirectory(UploadDirectory uploadDirectory)
        {
            string startPath = Path.Combine("wwwroot", "client", "custom-files");

            switch (uploadDirectory)
            {
                case UploadDirectory.WelcomeSlider:
                    return Path.Combine(startPath, "Welcomesliders");
                case UploadDirectory.OurHistory:
                    return Path.Combine(startPath, "OurHistory");
                case UploadDirectory.Paymentbenefits:
                    return Path.Combine(startPath, "Paymentbenefits");
                case UploadDirectory.Food:
                    return Path.Combine(startPath, "Foods");
                case UploadDirectory.FeedBack:
                    return Path.Combine(startPath, "FeedBacks");
                case UploadDirectory.Brand:
                    return Path.Combine(startPath, "Brands");
                case UploadDirectory.BlogImage:
                    return Path.Combine(startPath, "BlogImages");
                case UploadDirectory.BlogVideo:
                    return Path.Combine(startPath, "BlogVideos");
                case UploadDirectory.FoodImage:
                    return Path.Combine(startPath, "FoodImages");
                case UploadDirectory.DrinkImage:
                    return Path.Combine(startPath, "DrinkImages");
                case UploadDirectory.DiscoverMenuImage:
                    return Path.Combine(startPath, "DiscoverMenuImages");
                default:
                    throw new Exception("Something went wrong");
            }
        }

        private string GenerateUniqueFileName(string fileName)
        {
            return $"{Guid.NewGuid()}{Path.GetExtension(fileName)}";
        }

        public string GetFileUrl(string? fileName, UploadDirectory uploadDirectory)
        {
            string initialSegment = "client/custom-files/";

            switch (uploadDirectory)
            {
                case UploadDirectory.WelcomeSlider:
                    return $"{initialSegment}/Welcomesliders/{fileName}";
                case UploadDirectory.OurHistory:
                    return $"{initialSegment}/OurHistory/{fileName}";
                case UploadDirectory.Paymentbenefits:
                    return $"{initialSegment}/Paymentbenefits/{fileName}";
                case UploadDirectory.Food:
                    return $"{initialSegment}/Foods/{fileName}";
                case UploadDirectory.FeedBack:
                    return $"{initialSegment}/FeedBacks/{fileName}";
                case UploadDirectory.Brand:
                    return $"{initialSegment}/Brands/{fileName}";
                case UploadDirectory.BlogImage:
                    return $"{initialSegment}/BlogImages/{fileName}";
                case UploadDirectory.BlogVideo:
                    return $"{initialSegment}/BlogVideos/{fileName}";
                case UploadDirectory.FoodImage:
                    return $"{initialSegment}/FoodImages/{fileName}";
                case UploadDirectory.DrinkImage:
                    return $"{initialSegment}/DrinkImages/{fileName}";
                case UploadDirectory.DiscoverMenuImage:
                    return $"{initialSegment}/DiscoverMenuImages/{fileName}";
                default:
                    throw new Exception("Something went wrong");
            }
        }
    }
}
