using System;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace api_at_shop.Model
{
	public class CurrencyDTO
	{

        [JsonPropertyName("Datum primjene")]
        public string Date { get; set; }

        [JsonPropertyName("Država")]
        public string Country { get; set; }

        [JsonPropertyName("Šifra valute")]
        public string CurrencyID { get; set; }

        [JsonPropertyName("Valuta")]
        public string Currency { get; set; }


        [JsonPropertyName("Srednji za devize")]
        public string MiddleEchangeRate { get; set; }


    }
}

