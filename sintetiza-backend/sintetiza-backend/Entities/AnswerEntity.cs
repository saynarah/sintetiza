namespace sintetize.Models;

public class AnswerEntity: BaseEntity
{
    public string Id { get; set; }
    public IEnumerable<string> Words { get; set; }
    public string Actor { get; set; }
}