using System;
using api_at_shop.Model.Auth;

namespace api_at_shop.Services.AuthServices.Common
{
	public interface IBasicAuthService
	{
		public Task<BasicAuthUser> AuthUser(string username, string password);
	}
}

