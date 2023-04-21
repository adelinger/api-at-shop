using System;
using System.Net.Mail;
using api_at_shop.Model;
using api_at_shop.Model.Email;
using api_at_shop.Model.Shipping;
using api_at_shop.Services.common.EmailServices;
using Microsoft.Extensions.Configuration;
using SendGrid;
using SendGrid.Helpers.Mail;
using Response = api_at_shop.Model.Response;

namespace api_at_shop.Services.EmailServices
{
	public class EmailService :IEmailService
	{
        private readonly IConfiguration Configuration;

        public EmailService(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public async Task<Response> SendEmailAsync(GuestEmail EmailFrom, AdminEmail EmailTo)
        {
            throw new NotImplementedException();
        }

        public Task<Response> SendEmailWIthAtachmentAsync(GuestEmail SendTo, string attachment)
        {
            throw new NotImplementedException();
        }

        public async Task<Response> SendOrderConfirmEmail(IShippingInformation OrderInfo, string OrderID)
        {
            var TaskResult = new Response();
            try
            {

                var apiKey = Configuration.GetSection("AppSettings").GetSection("SendGridApiKey").Value;
                var client = new SendGridClient(apiKey);
                var from = new EmailAddress("info@autotoni.hr", "AT Classics Shop");
                var subject = "Order confirmation.";
                var to = new EmailAddress(OrderInfo.address_to.email, OrderInfo.address_to.first_name + " " +OrderInfo.address_to.last_name);
                var plainTextContent =  OrderInfo.address_to.first_name + ", thank you for your order. Your order number is: #" +OrderID;
                string htmlFilePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/html/Email.html");
                string emailContent = File.ReadAllText(htmlFilePath);
                var htmlContent = emailContent;
                htmlContent = htmlContent.Replace("{orderNumber}", OrderID);
                htmlContent = htmlContent.Replace("{orderDate}", DateTime.UtcNow.AddHours(1).ToShortDateString());

                var productsTable = "";
                foreach (var product in OrderInfo.line_items)
                {
                    productsTable += $"<tr><td>{product.Title}</td><td>{product.Quantity}</td><td>{product.Price}</td></tr>";
                }
                productsTable += $"<tr><td>Shipping</td><td>1</td><td>{OrderInfo.shipping_price}</td></tr>";
                htmlContent = htmlContent.Replace("{productsTable}", productsTable);
                htmlContent = htmlContent.Replace("{totalPrice}", OrderInfo.totalPrice);
                var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
                var response = await client.SendEmailAsync(msg);

                TaskResult.Success = response.IsSuccessStatusCode;
            }
            catch (Exception e)
            {
                TaskResult.Success = false;
                TaskResult.Message = e.Message;
            }
            return TaskResult;
        }
    }
}

