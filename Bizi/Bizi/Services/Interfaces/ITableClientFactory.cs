using Azure.Data.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bizi.Services.Interfaces
{
    public interface ITableClientFactory
    {
        TableClient Create();
    }
}
