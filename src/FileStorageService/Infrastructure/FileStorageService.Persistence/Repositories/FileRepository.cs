using FileStorageService.Application.Abstracts;
using FileStorageService.Domain.Entities;
using MongoDB.Bson;
using MongoDB.Driver;

namespace FileStorageService.Persistence.Repositories;

public class FileRepository : IFileRepository
{
    private readonly IMongoCollection<FileRecordEntity> _fileCollection;

    public FileRepository(IMongoDatabase mongoDatabase)
    {
        _fileCollection = mongoDatabase.GetCollection<FileRecordEntity>("FileStorageTable");
    }

    public async Task<FileRecordEntity> AddFileAsync(FileRecordEntity fileRecord)
    {
        var entity = new FileRecordEntity
        {
            FileUniqueCode = fileRecord.FileUniqueCode,
            FileName = fileRecord.FileName,
            FilePath = fileRecord.FilePath,
            FileSize = fileRecord.FileSize,
            FileType = fileRecord.FileType,
            StorageType = fileRecord.StorageType
        };
        await _fileCollection.InsertOneAsync(entity);
        return fileRecord;
    }

    public async Task<Stream> GetFileStreamAsync(string fileUniqueCode)
    {
        var filter = Builders<FileRecordEntity>.Filter.Eq(f => f.FileUniqueCode, fileUniqueCode);
        var fileEntity = await _fileCollection.Find(filter).FirstOrDefaultAsync();
        if (fileEntity == null)
            throw new FileNotFoundException($"File with code {fileUniqueCode} not found.");

        // Retrieve file stream from storage based on file path
        return new FileStream(fileEntity.FilePath, FileMode.Open, FileAccess.Read);
    }

    public async Task DeleteFileAsync(string fileUniqueCode)
    {
        var filter = Builders<FileRecordEntity>.Filter.Eq(f => f.FileUniqueCode, fileUniqueCode);
        await _fileCollection.DeleteOneAsync(filter);
    }

    public async Task<List<FileRecordEntity>> GetAllFilesAsync()
    {
        var entities = await _fileCollection.Find(_ => true).ToListAsync();
        return entities.Select(entity => new FileRecordEntity
        {
            Id = entity.Id,
            FileUniqueCode = entity.FileUniqueCode,
            FileName = entity.FileName,
            FilePath = entity.FilePath,
            FileSize = entity.FileSize,
            FileType = entity.FileType,
            StorageType = entity.StorageType
        }).ToList();
    }
}
