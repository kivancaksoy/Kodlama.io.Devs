using Application.Features.Auths.Dtos;
using Application.Features.Auths.Rules;
using Application.Services.AuthService;
using Application.Services.Repositories;
using Core.Security.Dtos;
using Core.Security.Entities;
using Core.Security.JWT;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Auths.Queries.Login
{
    public class LoginQuery : IRequest<LoginedDto>
    {
        public UserForLoginDto UserForLoginDto { get; set; }
        public string ipAddress { get; set; }

        public class LoginQueryHandler : IRequestHandler<LoginQuery, LoginedDto>
        {
            private AuthBusinessRules _authBusinessRules;
            private IUserRepository _userRepository;
            private IAuthService _authService;

            public LoginQueryHandler(AuthBusinessRules authBusinessRules, IUserRepository userRepository, IAuthService authService)
            {
                _authBusinessRules = authBusinessRules;
                _userRepository = userRepository;
                _authService = authService;
            }

            public async Task<LoginedDto> Handle(LoginQuery request, CancellationToken cancellationToken)
            {
                User? user = await _userRepository.GetAsync(u => u.Email == request.UserForLoginDto.Email);

                _authBusinessRules.IsEmailOrPasswordRegistered(user, request.UserForLoginDto);

                AccessToken accessToken = await _authService.CreateAccessToken(user);
                RefreshToken createdRefreshToken = await _authService.CreateRefreshToken(user, request.ipAddress);
                RefreshToken addedRefreshToken = await _authService.AddRefreshToken(createdRefreshToken);

                LoginedDto loginedDto = new()
                {
                    AccessToken = accessToken,
                    RefreshToken = addedRefreshToken
                };
                return loginedDto;
            }
        }
    }
}
