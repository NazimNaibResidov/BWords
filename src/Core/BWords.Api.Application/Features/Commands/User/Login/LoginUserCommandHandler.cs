using AutoMapper;
using BWords.Api.Application.Interfaces.Repostoryes;
using BWords.Common.Infrastructure;
using BWords.Common.Infrastructure.Exseptions;
using BWords.Common.Models.Quiers;
using BWords.Common.Models.RequestModel;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BWords.Api.Application.Features.Commands.User.Login
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, LoginUserViewModel>
    {
        private readonly IUserRepstory userRepstory;
        private readonly IMapper mapper;
        private readonly IConfiguration configuration;

        public LoginUserCommandHandler(IUserRepstory userRepstory, IMapper mapper, IConfiguration configuration)
        {
            this.userRepstory = userRepstory;
            this.mapper = mapper;
            this.configuration = configuration;
        }

        public async Task<LoginUserViewModel> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            var Dbuser = await userRepstory.GetSingleAsync(i => i.Email == request.EmailAdress);
            if (Dbuser == null)
                throw new DataBaseValidotorExeptions("User Not Found");
            // var pass = PasswordEncryption.Encrypt(request.Password);
            if (Dbuser.Password != request.Password)
                throw new DataBaseValidotorExeptions("Password Is Worng");
            //if (Dbuser.EmailConfirmed)
            //    throw new DataBaseValidotorExeptions("Email Confirmed is not");
            var result = mapper.Map<LoginUserViewModel>(Dbuser);
            var cliams = new Claim[]
            {
                new Claim(ClaimTypes.NameIdentifier,Dbuser.Id.ToString()),
                new Claim(ClaimTypes.Email,Dbuser.Email),
                new Claim(ClaimTypes.Name,Dbuser.UserName),
                new Claim(ClaimTypes.GivenName,Dbuser.FristName),
                new Claim(ClaimTypes.Surname,Dbuser.LastName),

            };
            result.Token = GenerateToken(cliams);
            return result;


        }
        private string GenerateToken(Claim[] claims)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Secret"]));
            var creads = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expries = DateTime.Now.AddDays(10);
            var toke = new JwtSecurityToken(claims: claims, expires: expries, signingCredentials: creads, notBefore: DateTime.Now);
            return new JwtSecurityTokenHandler().WriteToken(toke);
        }

    }
}
