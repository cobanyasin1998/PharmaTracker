using Coban.Application.DataProtection.Abstractions;
using Coban.GeneralDto;
using MediatR;
using System.Reflection;

namespace Coban.Application.Mediatr.Pipelines;

public class DecryptGetByIdBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IGetByIdRequest
{
    private readonly IDataProtectService _dataProtectService;

    public DecryptGetByIdBehavior(IDataProtectService dataProtectService)
    {
        _dataProtectService = dataProtectService;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        PropertyInfo[] properties = request.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);
        foreach (PropertyInfo property in properties)
        {
            if (property.Name.Equals("EncId", StringComparison.OrdinalIgnoreCase) && property.PropertyType == typeof(string))
            {
                string? currentValue = property.GetValue(request) as string;
                if (!string.IsNullOrEmpty(currentValue))
                {
                    long decryptedValue = _dataProtectService.Decrypt(currentValue);

                    PropertyInfo? decryptedIdProperty = request.GetType()
                        .GetProperty("Id");

                    if (decryptedIdProperty is not null && decryptedIdProperty.PropertyType == typeof(long))
                    {
                        decryptedIdProperty.SetValue(request, decryptedValue);
                    }
                    else
                    {
                        Console.WriteLine("DecryptedId property bulunamadı. BindingFlags kontrol edin.");
                    }
                }
            }
        }

        return await next();
    }

}
