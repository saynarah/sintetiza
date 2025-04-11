using Microsoft.Identity.Client;
using sintetize.Models;

namespace sintetiza_backend.Repository;

public class SintetizeConvert
{
    public QuestionResponse ConvertQuestionForResponse(QuestionEntity entity)
    {
        return new QuestionResponse(
            id: entity.Id,
            rowKey: entity.RowKey,
            description: entity.Description,
            anwers: entity.Answers?.Select(ConvertAnswerForResponse).ToList());
    }

    public AnswerResponse ConvertAnswerForResponse(AnswerEntity entity)
    {
        string[] words = [entity.Word1, entity.Word2, entity.Word3, entity.Word4, entity.Word5];

        return new AnswerResponse(
            id: entity.Id,
            questionPartitionKey: entity.PartitionKey,
            words: words,
            actor: entity.Actor);
    }

    public QuestionEntity ConvertQuestionForEntity(QuestionResponse response)
    {
        var entity = new QuestionEntity(
            id: response.id,
            description: response.description);

        if (entity.Answers == null || !entity.Answers.Any()) return entity;

        entity.Answers = response.anwers.Select(x => ConvertAnswerForEntity(x, entity.RowKey));

        return entity;
    }

    public AnswerEntity ConvertAnswerForEntity(AnswerResponse response, string questionPartitionKey)
    {
        return new AnswerEntity(
            id: response.id,
            partitionKey: questionPartitionKey,
            word1: response.words[0],
            word2: response.words[1],
            word3: response.words[2],
            word4: response.words[3],
            word5: response.words[4],
            actor: response.actor);
    }

    public AnswerEntity ConvertAnswerForEntity(AnswerResponse response)
    {
        return new AnswerEntity(
            id: response.id,
            partitionKey: response.questionPartitionKey,
            word1: response.words[0],
            word2: response.words[1],
            word3: response.words[2],
            word4: response.words[3],
            word5: response.words[4],
            actor: response.actor);
    }
}