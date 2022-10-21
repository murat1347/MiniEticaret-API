using Google.Apis.Auth;
using MediatR;
using Microsoft.AspNetCore.Identity;
using MiniEticaret.Application.Abstractions.Services;
using MiniEticaret.Application.Abstractions.Token;
using MiniEticaret.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniEticaret.Application.Features.Commands.AppUser.GoogleLogin
{
    public class GoogleLoginCommandHandler : IRequestHandler<GoogleLoginCommandRequest, GoogleLoginCommandResponse>
    {
        readonly IAuthService _authService;

        public GoogleLoginCommandHandler(IAuthService authService)
        {
            _authService = authService;
        }

        public async Task<GoogleLoginCommandResponse> Handle(GoogleLoginCommandRequest request, CancellationToken cancellationToken)
        {
            var token = await _authService.GoogleLoginAsync(request.IdToken, 15);
            return new()
            {
                Token = token
            };
        }
    }
}
