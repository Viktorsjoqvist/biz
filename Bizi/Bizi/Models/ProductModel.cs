using Newtonsoft.Json;

namespace Bizi.Models
{
    public class ProductModel
    {
        [JsonProperty("sku")]
        public string Sku { get; set; }

        [JsonProperty("category")]
        public string Category { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("amount")]
        public int Quantity { get; set; }
    }
}
