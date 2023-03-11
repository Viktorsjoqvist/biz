using Azure.Data.Tables;

namespace Bizi.Services.Interfaces
{
    public interface ITableClientFactory
    {
        TableClient Create();
    }
}
