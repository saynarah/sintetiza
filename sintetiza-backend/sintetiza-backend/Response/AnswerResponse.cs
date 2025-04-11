namespace sintetize.Models;

public record AnswerResponse(
    string id,
    string? questionPartitionKey,
    string[] words,
    string actor);