using System;
namespace api_at_shop.Model.Email
{
	public class AdminEmail
	{
        public string ContactID { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string SMTPHost { get; set; }
        public int SMTPPort { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}

