using sintetiza_backend.Models;

public record Question(
    string Id,
    string Description,
    DateTime Date,
    IEnumerable<AnswerEntity> Answers);