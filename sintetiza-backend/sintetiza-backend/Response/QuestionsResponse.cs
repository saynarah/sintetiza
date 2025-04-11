using sintetize.Models;

public record QuestionResponse(
    string Id,
    string RowKey,
    string Description,
    IEnumerable<AnswerResponse> Answers);