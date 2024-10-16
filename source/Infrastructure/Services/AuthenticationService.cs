using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Application.Interfaces;
using Application.Models.Request;
using Domain.Classes;
using Domain.Exceptions;
using Domain.Interfaces;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Infrastructure.Services
{
    public class AuthenticationService : IAuthenticateService
    {
        private readonly IPassengerRepository _passengerRepository;
        private readonly AutenticacionServiceOptions _options;

        public AuthenticationService(IPassengerRepository passengerRepository, IOptions<AutenticacionServiceOptions> options)
        {
            _passengerRepository = passengerRepository;
            _options = options.Value;
        }

        public string Autenticar(AuthenticationRequest authenticationRequest)
        {

            var user = ValidateUser(authenticationRequest);

            if (user == null)
            {
                throw new NotAllowedException("User authentication failed");
            }



            var securityPassword = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_options.SecretForKey));

            var credentials = new SigningCredentials(securityPassword, SecurityAlgorithms.HmacSha256);


            var claimsForToken = new List<Claim>();
            claimsForToken.Add(new Claim("sub", user.Id.ToString()));
            claimsForToken.Add(new Claim("Name", user.Name));

            var jwtSecurityToken = new JwtSecurityToken(
              _options.Issuer,
              _options.Audience,
              claimsForToken,
              DateTime.UtcNow,
              DateTime.UtcNow.AddHours(1),
              credentials);

            var tokenToReturn = new JwtSecurityTokenHandler()
                .WriteToken(jwtSecurityToken);

            return tokenToReturn.ToString();
        }

        private Passenger? ValidateUser(AuthenticationRequest authenticationRequest)
        {
            if (string.IsNullOrEmpty(authenticationRequest.Email) || string.IsNullOrEmpty(authenticationRequest.Password))
                return null;

            var user = _passengerRepository.GetByEmail(authenticationRequest.Email);

            if (user == null) return null;


            if (user.Password == authenticationRequest.Password) return user;


            return null;

        }

        public class AutenticacionServiceOptions
        {
            public const string AutenticacionService = "AutenticacionService";

            public string Issuer { get; set; }
            public string Audience { get; set; }
            public string SecretForKey { get; set; }
        }
    }
}
