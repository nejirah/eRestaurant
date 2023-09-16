using System.IdentityModel.Tokens.Jwt;
using System;
using System.Linq;
using System.Net.Http.Json;
using System.Text.Json.Serialization;
using eRestaurant.Authentication.Models;
using eRestaurant.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Text.Json;

namespace FIT_Api_Examples.Helper.AutentifikacijaAutorizacija
{
    public static class MyAuthTokenExtension
    {
        public class LoginInformacije
        {
            public LoginInformacije(AuthenticationToken? autentifikacijaToken)
            {
                this.autentifikacijaToken = autentifikacijaToken;
            }

            [JsonIgnore]
            public KorisnickiNalog? korisnickiNalog => autentifikacijaToken?.korisnickiNalog;
            public AuthenticationToken? autentifikacijaToken { get; set; }
            
            public bool isLogiran => korisnickiNalog != null;
         
        }


        public static LoginInformacije GetLoginInfo(this HttpContext httpContext)
        {
            var token = httpContext.GetAuthToken();

            return new LoginInformacije(token);
        }

        public static AuthenticationToken? GetAuthToken(this HttpContext httpContext)
        {
            string token = httpContext.GetMyAuthToken();
            ApplicationDbContext? db = httpContext.RequestServices.GetService<ApplicationDbContext>();

            AuthenticationToken? korisnickiNalog = db?.AutentikacijaToken
                .Include(s => s.korisnickiNalog)
                .SingleOrDefault(x => x.vrijednost == token);

            return korisnickiNalog;
        }


        public static string GetMyAuthToken(this HttpContext httpContext)
        {
            string token = httpContext.Request.Headers["autentifikacija-token"];
            return token;
        }

    }
}
