using Azure.Data.Tables;
using Microsoft.Extensions.Configuration;

namespace sintetiza_backend.Repository;

public class SintetizeService 
{
    private readonly TableClient _tableClient;

    public SintetizeService(IConfiguration configuration)
    {
        var connection = configuration["StorageConnectionString"];
        _tableClient = new TableClient(connection, "Questions");
        _tableClient.CreateIfNotExists();
    }
}
