using System.Collections.Generic;
using Newtonsoft.Json;

namespace APIAutomation
{
    public class Place
    {
        [JsonProperty("place name")]
        public string PlaceName { get; set; }
        public string longitude { get; set; }

        [JsonProperty("post code")]
        public string PostCode { get; set; }
        public string latitude { get; set; }
    }

    public class Root
    {
        [JsonProperty("country abbreviation")]
        public string CountryAbbreviation { get; set; }
        public List<Place> places { get; set; }
        public string country { get; set; }

        [JsonProperty("place name")]
        public string PlaceName { get; set; }
        public string state { get; set; }

        [JsonProperty("state abbreviation")]
        public string StateAbbreviation { get; set; }
    }
}
