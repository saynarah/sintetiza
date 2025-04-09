using Azure;
using Azure.Data.Tables;
using sintetize.Models;

public class BaseEntity : ITableEntity
{
    public string PartitionKey { get; set; } = "aNS";
    public string RowKey { get; set; } = Guid.NewGuid().ToString();
    public DateTimeOffset? Timestamp { get; set; }
    public ETag ETag { get; set; }
}