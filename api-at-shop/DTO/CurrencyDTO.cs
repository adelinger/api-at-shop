using System;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace api_at_shop.Model
{
	public class CurrencyDTO
	{

        [JsonPropertyName("datum_primjene")]
        public string Date { get; set; }

        [JsonPropertyName("drzava")]
        public string Country { get; set; }

        [JsonPropertyName("sifra_valute")]
        public string CurrencyID { get; set; }

        [JsonPropertyName("valuta")]
        public string Currency { get; set; }


        [JsonPropertyName("srednji_tecaj")]
        public string MiddleEchangeRate { get; set; }


    }
}

