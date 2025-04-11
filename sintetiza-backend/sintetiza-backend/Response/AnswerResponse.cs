namespace sintetize.Models;

public record AnswerResponse(
    string Id,
    string? QuestionPartitionKey,
    string[] Words,
    string Actor);