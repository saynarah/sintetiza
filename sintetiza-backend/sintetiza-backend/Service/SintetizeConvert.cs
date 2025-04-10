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
            Date: entity.Date,
            Answers: entity.Answers.Select(ConvertAnswerForesponse));
    }

    public AnswerResponse ConvertAnswerForResponse(AnswerEntity entity)
    {
        return new AnswerResponse(
            Id: entity.Id,
            QuestionPartitionKey: entity.PartitionKey,
            Words: entity.Words,
            Actor: entity.Actor);
    }

    public QuestionEntity ConvertQuestionForEntity(QuestionResponse response)
    {
        var entity = new QuestionEntity(
            id: response.Id,
            description: response.Description,
            date: response.Date);

        entity.Answers = response.Answers.Select(x => ConvertAnswerForEntity(x, entity.RowKey));

        return entity;
    }

    public AnswerEntity ConvertAnswerForEntity(AnswerResponse response, string questionPartitionKey)
    {
        return new AnswerEntity(
            id: response.Id,
            partitionKey: questionPartitionKey,
            words: response.Words,
            actor: response.Actor);
    }

    public AnswerEntity ConvertAnswerForEntity(AnswerResponse response)
    {
        return new AnswerEntity(
            id: response.Id,
            partitionKey: response.QuestionPartitionKey,
            words: response.Words,
            actor: response.Actor);
    }
}