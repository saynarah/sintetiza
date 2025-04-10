namespace sintetize.Models;

public class AnswerEntity: BaseEntity
{

    public string Id { get; set; }
    public IEnumerable<string> Words { get; set; }
    public string Actor { get; set; } = "anonymous";
    public AnswerEntity()
    {
    }
    public AnswerEntity(
        string id,
        string partitionKey,
        IEnumerable<string> words, 
        string actor)
    {
        Id = id;
        PartitionKey = partitionKey;
        Words = words;
        Actor = actor;
    }

}