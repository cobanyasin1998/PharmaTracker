using FileStorageService.Application.Abstracts;
using FileStorageService.Domain.Entities;
using FileStorageService.Domain.Enums;
using Microsoft.AspNetCore.Mvc;

namespace FileStorageService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileStorageController : ControllerBase
    {
        private readonly IFileStorageService _fileStorageService;

        public FileStorageController(IFileStorageService fileStorageService)
        {
            _fileStorageService = fileStorageService;
        }

        [HttpPost("Upload")]
        public async Task<IActionResult> UploadFile(IFormFile file)
        {
            var fileRecord = new FileRecordEntity
            {
                FileUniqueCode = Guid.NewGuid().ToString(),
                FileName = file.FileName,
                FileSize = file.Length,
                FilePath = $"path/to/storage/{file.FileName}",
                FileType = EFileType.PDF, // Example
                StorageType = EStorageType.Local
            };

            using var stream = file.OpenReadStream();
            var result = await _fileStorageService.UploadFileAsync(fileRecord, stream);
            return Ok(result);
        }

        [HttpGet("Download/{fileUniqueCode}")]
        public async Task<IActionResult> DownloadFile(string fileUniqueCode)
        {
            var fileStream = await _fileStorageService.DownloadFileAsync(fileUniqueCode);
            return File(fileStream, "application/octet-stream");
        }

        [HttpDelete("Delete/{fileUniqueCode}")]
        public async Task<IActionResult> DeleteFile(string fileUniqueCode)
        {
            await _fileStorageService.DeleteFileAsync(fileUniqueCode);
            return NoContent();
        }

        [HttpGet("All")]
        public async Task<IActionResult> GetAllFiles()
        {
            var files = await _fileStorageService.GetAllFilesAsync();
            return Ok(files);
        }
    }
}
