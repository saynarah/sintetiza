namespace sintetize.Models;

public class AnswerEntity: BaseEntity
{

    public string Id { get; set; }
    public string Word1 { get; set; }
    public string Word2 { get; set; }
    public string Word3 { get; set; }
    public string Word4 { get; set; }
    public string Word5 { get; set; }
    public string Actor { get; set; } = "anonymous";
    public AnswerEntity()
    {
    }
    public AnswerEntity(
        string id,
        string partitionKey,
        string actor,
        string word1, 
        string word2,
        string word3,
        string word4,
        string word5)
    {
        Id = id;
        PartitionKey = partitionKey;
        Actor = actor;
        Word1= word1;
        Word2 = word2;
        Word3 = word3;
        Word4 = word4;
        Word5 = word5;
    }

}