﻿using IkProject.Domain.Identities;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace IkProject.Application.Abstractions
{
    public interface ITokenServices
    {
        Task<JwtSecurityToken> CreateToken(AppUser user,IList<string> roles);
        ClaimsPrincipal? GetClaimsPrincipalFromExpiredToken(string token);
    }
}
