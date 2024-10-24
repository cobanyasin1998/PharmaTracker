using FileStorageService.Domain.Entities;

namespace FileStorageService.Application.Abstracts;

public interface IFileRepository
{
    Task<FileRecordEntity> AddFileAsync(FileRecordEntity fileRecord);
    Task<Stream> GetFileStreamAsync(string fileUniqueCode);
    Task DeleteFileAsync(string fileUniqueCode);
    Task<List<FileRecordEntity>> GetAllFilesAsync();
}
