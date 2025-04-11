using Microsoft.Extensions.Configuration;
using sintetize.Models;
using static Grpc.Core.Metadata;

namespace sintetiza_backend.Repository;

public class SintetizeService 
{
    private readonly TableStorageRepository<QuestionEntity> _questionRepository;
    private readonly TableStorageRepository<AnswerEntity> _answeRepository;
    private readonly SintetizeConvert _convert;

    public SintetizeService(IConfiguration configuration, SintetizeConvert convert)
    {
        _questionRepository = new TableStorageRepository<QuestionEntity>(configuration, "QuestionSintetize");
        _answeRepository = new TableStorageRepository<AnswerEntity>(configuration, "AnswerSintetize");
        _convert = convert;
    }

    public async Task<List<QuestionResponse>> GetAllQuestionAsync()
    {
        var entities = await _questionRepository.GetAllAsync();

        return entities.Select(_convert.ConvertQuestionForResponse).ToList();
    }

    public async Task<QuestionResponse> GetQuestionAsync(string questionId)
    {
        var entity = new QuestionEntity();

        if(questionId == null || String.IsNullOrWhiteSpace(questionId) || questionId == "1")
        {
            var entities = await _questionRepository.GetAllAsync();
            entity = entities.FirstOrDefault();
        }
        else
        {
            entity = await _questionRepository.GetAsync("aNS", questionId);
        }

        var list = await _answeRepository.GetAllAsync();
        entity.Answers = list.Where(x => x.PartitionKey == entity.RowKey).ToList();

        return _convert.ConvertQuestionForResponse(entity);
    }

    public async Task CreateAync(QuestionResponse response)
    {
        var questionEntity = _convert.ConvertQuestionForEntity(response);
        await _questionRepository.AddAsync(questionEntity);

        if (questionEntity.Answers == null || !questionEntity.Answers.Any()) return;

        questionEntity.Answers.Select(_answeRepository.AddAsync);
    }

    public async Task CreateAnswerAync(AnswerResponse response)
    {
        var entity = _convert.ConvertAnswerForEntity(response);
        await _answeRepository.AddAsync(entity);
    }

    public async Task DeleteQuestionAsync(string partitionKey, string rowKey)
    {
        await _questionRepository.DeleteAsync(partitionKey, rowKey);
    }

}
