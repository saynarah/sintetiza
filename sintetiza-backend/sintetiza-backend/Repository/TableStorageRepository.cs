using Azure;
using Azure.Data.Tables;
using Microsoft.Extensions.Configuration;

namespace sintetiza_backend.Repository;

public class TableStorageRepository<T> where T : class, ITableEntity
{
    private readonly TableClient _tableClient;

    public TableStorageRepository(IConfiguration configuration, string tableName)
    {
        var connection = configuration["StorageConnectionString"];
        _tableClient = new TableClient(connection, tableName);
        _tableClient.CreateIfNotExists();
    }

    public async Task AddAsync(T entity)
    {
        await _tableClient.AddEntityAsync(entity);
    }

    public async Task<List<T>> GetAllAsync()
    {
        return _tableClient.Query<T>().ToList();
    }

    public async Task<T?> GetAsync(string partitionKey, string rowKey)
    {
        try
        {
            var response = await _tableClient.GetEntityAsync<T>(partitionKey, rowKey);
            return response.Value;
        }
        catch (RequestFailedException ex) when (ex.Status == 404)
        {
            return null;
        }
    }

    public async Task UpdateAsync(T entity)
    {
        await _tableClient.UpdateEntityAsync(entity, entity.ETag, TableUpdateMode.Replace);
    }

    public async Task DeleteAsync(string partitionKey, string rowKey)
    {
        await _tableClient.DeleteEntityAsync(partitionKey, rowKey);
    }

}
