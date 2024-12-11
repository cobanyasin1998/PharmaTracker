namespace Coban.Application.DataProtection.Abstractions;

public interface IDataProtectService
{
    String Encrypt(long originalId);
    long Decrypt(String encryptedText);
}
