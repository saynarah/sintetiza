using sintetize.Models;

public record QuestionResponse(
    string Id,
    string RowKey,
    string Description,
    DateTime Date,
    IEnumerable<AnswerResponse> Answers);