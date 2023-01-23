using System;
using System.Diagnostics.Contracts;
using api_at_shop.Model;
using api_at_shop.Model.Email;
using api_at_shop.Model.Shipping;

namespace api_at_shop.Services.common.EmailServices
{
    public interface IEmailService
	{
        public Task<Response> SendOrderConfirmEmail(IShippingInformation OrderInfo, string OrderID);
        public Task<Response> SendEmailAsync(GuestEmail EmailFrom, AdminEmail EmailTo);
        public Task<Response> SendEmailWIthAtachmentAsync(GuestEmail SendTo, string attachment);
    }
}

