using Microsoft.Identity.Client;
using sintetize.Models;

namespace sintetiza_backend.Repository;

public class SintetizeConvert
{
    public QuestionResponse ConvertQuestionForResponse(QuestionEntity entity)
    {
        return new QuestionResponse(
            Id: entity.Id,
            RowKey: entity.RowKey,
            Description: entity.Description,
            Answers: entity.Answers?.Select(ConvertAnswerForResponse).ToList());
    }

    public AnswerResponse ConvertAnswerForResponse(AnswerEntity entity)
    {
        string[] words = [entity.Word1, entity.Word2, entity.Word3, entity.Word4, entity.Word5];

        return new AnswerResponse(
            Id: entity.Id,
            QuestionPartitionKey: entity.PartitionKey,
            Words: words,
            Actor: entity.Actor);
    }

    public QuestionEntity ConvertQuestionForEntity(QuestionResponse response)
    {
        var entity = new QuestionEntity(
            id: response.Id,
            description: response.Description);

        if (entity.Answers == null || !entity.Answers.Any()) return entity;

        entity.Answers = response.Answers.Select(x => ConvertAnswerForEntity(x, entity.RowKey));

        return entity;
    }

    public AnswerEntity ConvertAnswerForEntity(AnswerResponse response, string questionPartitionKey)
    {
        return new AnswerEntity(
            id: response.Id,
            partitionKey: questionPartitionKey,
            word1: response.Words[0],
            word2: response.Words[1],
            word3: response.Words[2],
            word4: response.Words[3],
            word5: response.Words[4],
            actor: response.Actor);
    }

    public AnswerEntity ConvertAnswerForEntity(AnswerResponse response)
    {
        return new AnswerEntity(
            id: response.Id,
            partitionKey: response.QuestionPartitionKey,
            word1: response.Words[0],
            word2: response.Words[1],
            word3: response.Words[2],
            word4: response.Words[3],
            word5: response.Words[4],
            actor: response.Actor);
    }
}