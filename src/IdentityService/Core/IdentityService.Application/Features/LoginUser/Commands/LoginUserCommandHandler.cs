using Coban.Application.Responses.Base.Abstractions;
using Coban.Application.Responses.Base.Concretes;
using Coban.GeneralDto;
using Coban.Identity.Entities.Base;
using Coban.Identity.Hashing;
using Coban.Identity.Services.Abstractions;
using IdentityService.Application.Abstractions.UnitOfWork;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace IdentityService.Application.Features.LoginUser.Commands;

public class LoginUserCommandHandler(ITokenService _tokenService, IUnitOfWork _unitOfWork) : IRequestHandler<LoginUserCommandRequest, IResponse<LoginUserCommandResponse, GeneralErrorDto>>
{
    public async Task<IResponse<LoginUserCommandResponse, GeneralErrorDto>> Handle(LoginUserCommandRequest request, CancellationToken cancellationToken)
    {
        UserEntity? user = await _unitOfWork.UserReadRepository.GetWhere(y => y.Username == request.UsernameOrEmail || y.Email == request.UsernameOrEmail).FirstOrDefaultAsync(cancellationToken: cancellationToken);

        if (user is null || ! HashingHelper.VerifyPasswordHash(request.Password, user.PasswordHash, user.PasswordSalt))
            throw new UnauthorizedAccessException("Invalid username or password");

        string? accessToken = _tokenService.GenerateAccessToken(user);
        string? refreshToken = _tokenService.GenerateRefreshToken();

        
        return Response<LoginUserCommandResponse, GeneralErrorDto>
      .CreateSuccess(new LoginUserCommandResponse() { AccessToken = accessToken,RefreshToken = refreshToken }, "Login successful");
    }
}
