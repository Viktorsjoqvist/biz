using Azure;
using Azure.Data.Tables;
using System;

namespace Bizi.DAL.Product
{
    public class ProductItemEntity : ITableEntity
    {
        public ProductItemEntity(string category, string id)
        {
            PartitionKey = category;
            RowKey = id;
        }
        public ProductItemEntity() { }

        public string Id { get; set; }
        public string Category { get; set; }
        public string Title { get; set; }
        public int Quantity { get; set; }
        public string PartitionKey { get; set; }
        public string RowKey { get; set; }
        public DateTimeOffset? Timestamp { get; set; }
        public ETag ETag { get; set; }
    }
}
