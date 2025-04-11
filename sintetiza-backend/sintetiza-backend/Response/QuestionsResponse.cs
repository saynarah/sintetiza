using sintetize.Models;

public record QuestionResponse(
    string id,
    string rowKey,
    string description,
    IEnumerable<AnswerResponse> anwers);