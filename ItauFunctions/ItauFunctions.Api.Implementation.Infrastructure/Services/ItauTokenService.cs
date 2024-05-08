using ItauFunctions.Api.Implementation.Domain.Models;
using ItauFunctions.Api.Implementation.Infrastructure.Repositories;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItauFunctions.Api.Implementation.Infrastructure.Services
{
    public class ItauTokenService
    {
        private readonly IConfiguration _configuration;
        private readonly ItauClientRepository _itauClientRepository;

        public ItauTokenService(IConfiguration configuration, ItauClientRepository itauClientRepository)
        {
            _configuration = configuration;
            _itauClientRepository = itauClientRepository;
        }

        public async Task<Token> AuthorizationToken(string? clientId, string? clientSecret)
        {
            try
            {
                clientId ??= _configuration["Authentication:ClientId"];
                clientSecret ??= _configuration["Authentication:ClientSecret"];

                if (clientId == null || clientSecret == null)
                {
                    throw new Exception("Campos obrigatórios não preenchidos.");
                }

                return await _itauClientRepository.AuthorizationToken(clientId, clientSecret);
            }
            catch
            {
                throw;
            }
        }
    }
}
