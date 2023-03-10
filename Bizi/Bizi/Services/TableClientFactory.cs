using Azure.Data.Tables;
using Bizi.Constants;
using Bizi.Services.Interfaces;

namespace Bizi.Services
{
    public class TableClientFactory : ITableClientFactory
    {
        public TableClientFactory()
        {
        }

        public TableClient Create()
        {
            return new TableClient("DefaultEndpointsProtocol=https;AccountName=sjoqvistbiz;AccountKey=6crMSW/S5E++yJyBfRVhnpz02oR9+HznUhANqJLUqIqfpOftNsM/6XMS0xmAEjqiGyrBjpTXF2ZY+AStQYp0wA==;EndpointSuffix=core.windows.net", 
                BiziConstants.TableProducts);
        }
    }
}
