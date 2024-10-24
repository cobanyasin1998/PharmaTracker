using FileStorageService.Domain.Entities.Common;
using FileStorageService.Domain.Enums;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace FileStorageService.Domain.Entities;

public class FileRecordEntity : BaseEntity
{
    [BsonElement("fileUniqueCode")]
    public string FileUniqueCode { get; set; }

    [BsonElement("fileName")]
    public string FileName { get; set; }

    [BsonElement("filePath")]
    public string FilePath { get; set; }

    [BsonElement("fileSize")]
    public long FileSize { get; set; }

    [BsonElement("fileType")]
    public EFileType FileType { get; set; }

    [BsonElement("storageType")]
    public EStorageType StorageType { get; set; }

  
}
