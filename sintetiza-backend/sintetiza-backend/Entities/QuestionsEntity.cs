using sintetize.Models;

public class QuestionEntity : BaseEntity
{
    public string Id { get; set; }
    public string Description { get; set; }
    //public DateTime Date { get; set; }
    public IEnumerable<AnswerEntity> Answers { get; set; }
}