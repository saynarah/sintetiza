namespace sintetiza_backend.Models;

public record AnswerEntity(
    string Id,
    IEnumerable<string> Words,
    string Actor);