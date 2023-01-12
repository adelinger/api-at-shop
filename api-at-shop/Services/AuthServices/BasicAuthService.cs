using System;
using api_at_shop.Model.Auth;
using api_at_shop.Services.AuthServices.Common;

namespace api_at_shop.Services.AuthServices
{
    public class BasicAuthService : IBasicAuthService
    {
        public async Task<BasicAuthUser> AuthUser(string username, string password)
        {
            try
            {
                var authenticatedUser = new List<BasicAuthUser>
            {
                new BasicAuthUser{Username = "admin", Password= "admin", ID=1},
                new BasicAuthUser{Username = "antun", Password = "antun", ID=2},
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

