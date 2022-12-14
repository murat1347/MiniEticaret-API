using MiniEticaret.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniEticaret.Application.Abstractions.Token
{
    public interface ITokenHandler
    {
        Dtos.Token CreateAccessToken(int minute, AppUser appUser);
        string CreateRefreshToken();
    }
}
