using Azure;
using Azure.Data.Tables;

namespace sintetize.Models;

public class AnswerEntity: ITableEntity
{
    public string PartitionKey { get; set; } = "Question";
    public string RowKey { get; set; } = Guid.NewGuid().ToString();
    public DateTimeOffset? Timestamp {  get; set; }
    public ETag ETag { get; set; }
    
    
    public string Id { get; set; }
    public IEnumerable<string> Words { get; set; }
    public string Actor { get; set; }
}