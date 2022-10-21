using MediatR;
using Microsoft.AspNetCore.Identity;
using MiniEticaret.Application.Abstractions.Services;
using MiniEticaret.Application.Abstractions.Token;
using MiniEticaret.Application.Dtos;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniEticaret.Application.Features.Commands.AppUser.FacebookLogin
{
    public class FacebookLoginCommandHandler : IRequestHandler<FacebookLoginCommandRequest, FacebookLoginCommandResponse>
    {
        readonly IAuthService _authService;

        public FacebookLoginCommandHandler(IAuthService authService)
        {
            _authService = authService;
        }

        public async Task<FacebookLoginCommandResponse> Handle(FacebookLoginCommandRequest request, CancellationToken cancellationToken)
        {
            var token = await _authService.FacebookLoginAsync(request.AuthToken, 15);
            return new()
            {
                Token = token
            };
        }
    }
}