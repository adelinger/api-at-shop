using System;
using api_at_shop.Model.Auth;
using api_at_shop.Services.AuthServices.Common;
using Microsoft.Extensions.Configuration;

namespace api_at_shop.Services.AuthServices
{
    public class BasicAuthService : IBasicAuthService
    {
        private readonly IConfiguration Configuration;
        public BasicAuthService(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public async Task<BasicAuthUser> AuthUser(string username, string password)
        {
            try
            {
                var api_pw = Configuration.GetSection("AppSettings").GetSection("InvoicesApiPassword").Value;

                var authenticatedUser = new List<BasicAuthUser>
            {
                new BasicAuthUser{Username = "autotoni", Password = api_pw, ID=3},
            };

                var user = authenticatedUser.Where(user => user.Username == username && user.Password == password).SingleOrDefault();

                return user;
            }
            catch (Exception ex)
            {
                return null;
            }
           
        }
    }
}

