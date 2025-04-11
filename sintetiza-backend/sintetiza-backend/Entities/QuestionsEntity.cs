using sintetize.Models;

public class QuestionEntity : BaseEntity
{

    public string Id { get; set; }
    public string Description { get; set; }
    public IEnumerable<AnswerEntity> Answers { get; set; }
    public QuestionEntity()
    {
    }
    public QuestionEntity(
        string id, 
        string description)
    {
        Id = id;
        Description = description;
    }

}