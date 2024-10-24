using FileStorageService.Application.Abstracts;
using FileStorageService.Domain.Entities;

namespace FileStorageService.Application.Services;

public class FileStorageService : IFileStorageService
{
    private readonly IFileRepository _fileRepository;

    public FileStorageService(IFileRepository fileRepository)
    {
        _fileRepository = fileRepository;
    }

    public async Task<FileRecordEntity> UploadFileAsync(FileRecordEntity fileRecord, Stream fileStream)
    {
        return await _fileRepository.AddFileAsync(fileRecord);
    }

    public async Task<Stream> DownloadFileAsync(string fileUniqueCode)
    {
        return await _fileRepository.GetFileStreamAsync(fileUniqueCode);
    }

    public async Task DeleteFileAsync(string fileUniqueCode)
    {
        await _fileRepository.DeleteFileAsync(fileUniqueCode);
    }

    public async Task<List<FileRecordEntity>> GetAllFilesAsync()
    {
        return await _fileRepository.GetAllFilesAsync();
    }
}
