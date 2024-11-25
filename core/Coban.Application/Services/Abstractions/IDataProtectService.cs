namespace Coban.Application.Services.Abstractions;

public interface IDataProtectService
{
    string Encrypt(long plainText);
    long Decrypt(string encryptedText);
}
