using Coban.Application.Services.Abstractions;
using Coban.Application.Services.Exceptions;
using Microsoft.AspNetCore.DataProtection;


namespace Coban.Application.Services.Concretes;

public class DataProtectService : IDataProtectService
{
    private readonly IDataProtector _dataProtector;

    public DataProtectService(IDataProtector dataProtector)
    {
        _dataProtector = dataProtector;
    }
    public long Decrypt(string encryptedText)
    {
        if (string.IsNullOrWhiteSpace(encryptedText))
        {
            throw new DataProtectKeyException("Geçersiz Key");
        }
        string key = _dataProtector.Unprotect(encryptedText);

        if (!long.TryParse(key, out long result))
        {
            throw new DataProtectKeyException("Geçersiz Key");

        }
        return result;
    }

    public string Encrypt(long plainText)
        => _dataProtector.Protect(plainText.ToString());

}
