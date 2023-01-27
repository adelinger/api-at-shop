using System;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace api_at_shop.Utils.Data
{
	public static class CarTypes
	{
        public static List<string> CarTypesList { get; } = new List<string>() {
        "Alfa Classics", "BMW Classics", "Citroen Classics", "Mercedes Classics", "Volkswagen Classics"
    };
    
}
}

