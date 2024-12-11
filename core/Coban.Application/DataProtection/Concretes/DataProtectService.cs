using Coban.Application.DataProtection.Abstractions;
using Coban.Consts;
using Coban.Infrastructure.Exceptions.ExceptionTypes;
using Microsoft.AspNetCore.DataProtection;

namespace Coban.Application.DataProtection.Concretes;

public class DataProtectService(IDataProtector _dataProtector) : IDataProtectService
{
    public long Decrypt(String encryptedText)
    {
        if (String.IsNullOrWhiteSpace(encryptedText))
            throw new DataProtectKeyException(DataProtectionConsts.NoValidKey);

        String key = _dataProtector.Unprotect(encryptedText);

        if (!long.TryParse(key, out long result))
            throw new DataProtectKeyException(DataProtectionConsts.NoValidKey);

        return result;
    }

    public String Encrypt(long originalId)
        => _dataProtector.Protect(originalId.ToString());

}
