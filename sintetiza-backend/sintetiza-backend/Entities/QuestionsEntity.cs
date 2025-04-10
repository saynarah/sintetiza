using sintetize.Models;

public class QuestionEntity : BaseEntity
{

    public string Id { get; set; }
    public string Description { get; set; }
    public DateTime Date { get; set; } = DateTime.Now;
    public IEnumerable<AnswerEntity> Answers { get; set; }
    public QuestionEntity(
        string id, 
        string description, 
        DateTime date)
    {
        Id = id;
        Description = description;
        Date = date;
    }
}