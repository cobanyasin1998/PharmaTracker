namespace Coban.Application.DataProtection.Abstractions;

public interface IDataProtectService
{
    string Encrypt(long originalId);
    long Decrypt(string encryptedText);
}
