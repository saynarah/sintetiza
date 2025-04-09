using Azure;
using Azure.Data.Tables;
using sintetize.Models;

public class QuestionEntity : ITableEntity
{
    public string PartitionKey { get; set; } = "aNS";
    public string RowKey { get; set; } = Guid.NewGuid().ToString();
    public DateTimeOffset? Timestamp { get; set; }
    public ETag ETag { get; set; }


    public string Id { get; set; }
    public string Description { get; set; }
    public DateTime Date { get; set; }
    public IEnumerable<AnswerEntity> Answers { get; set; }
}