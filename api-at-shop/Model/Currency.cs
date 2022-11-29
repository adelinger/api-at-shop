using System;
using System.Text.Json.Serialization;

namespace api_at_shop.Model
{
	public class Currency
	{
        public int CurrencyID { get; set; }
        public DateTime TimeStamp { get; set; }

        public decimal USDValue { get; set; }

        public decimal EURValue { get; set; }
    }
}

