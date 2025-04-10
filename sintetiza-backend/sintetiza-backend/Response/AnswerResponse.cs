namespace sintetize.Models;

public record AnswerResponse(
    string Id,
    string? QuestionPartitionKey,
    IEnumerable<string> Words,
    string Actor);