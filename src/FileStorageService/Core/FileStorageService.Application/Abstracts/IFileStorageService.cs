using FileStorageService.Domain.Entities;

namespace FileStorageService.Application.Abstracts;

public interface IFileStorageService
{
    Task<FileRecordEntity> UploadFileAsync(FileRecordEntity fileRecord, Stream fileStream);
    Task<Stream> DownloadFileAsync(string fileUniqueCode);
    Task DeleteFileAsync(string fileUniqueCode);
    Task<List<FileRecordEntity>> GetAllFilesAsync();
}
