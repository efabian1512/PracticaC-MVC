using AutenticacionGoogle.Models;
using System;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Google.Authenticator;

namespace AutenticacionGoogle
{
    public class GoogleAuthenticatorTokenProvider : IUserTokenProvider<ApplicationUser, string>
    {
        public Task<string> GenerateAsync(string purpose, UserManager<ApplicationUser, string> manager, ApplicationUser user)
        {
            return Task.FromResult("");
        }

        public Task<bool> IsValidProviderForUserAsync(UserManager<ApplicationUser, string> manager, ApplicationUser user)
        {
            return Task.FromResult(user.UsarGoogleAuthenticator);
            
        }

        public Task NotifyAsync(string token, UserManager<ApplicationUser, string> manager, ApplicationUser user)
        {
            return Task.FromResult(0);
        }

        public Task<bool> ValidateAsync(string purpose, string token, UserManager<ApplicationUser, string> manager, ApplicationUser user)
        {
            TwoFactorAuthenticator autenticador = new TwoFactorAuthenticator();
            var resultado =autenticador.ValidateTwoFactorPIN(user.Id, token);
            return Task.FromResult(resultado);

        }
    }
}