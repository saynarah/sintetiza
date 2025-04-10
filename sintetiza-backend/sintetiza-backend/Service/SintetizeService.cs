using Microsoft.Extensions.Configuration;
using sintetize.Models;

namespace sintetiza_backend.Repository;

public class SintetizeService 
{
    private readonly TableStorageRepository<QuestionEntity> _questionRepository;
    private readonly TableStorageRepository<AnswerEntity> _answeRepository;
    private readonly SintetizeConvert _convert;

    public SintetizeService(IConfiguration configuration, SintetizeConvert convert)
    {
        _questionRepository = new TableStorageRepository<QuestionEntity>(configuration, "Questions");
        _answeRepository = new TableStorageRepository<AnswerEntity>(configuration, "Answers");
        _convert = convert;
    }

    public async Task<List<QuestionResponse>> GetAllQuestionAsync()
    {
        var entities = await _questionRepository.GetAllAsync();

        return entities.Select(_convert.ConvertQuestionForResponse).ToList();
    }

    public async Task<QuestionResponse> GetQuestionAsync(string questionId)
    {
        var entitie = await _questionRepository.GetAsync("aNS", questionId);

        return _convert.ConvertQuestionForResponse(entitie);
    }

    public async Task CreateAync(QuestionResponse response)
    {
        var questionEntity = _convert.ConvertQuestionForEntity(response);
        await _questionRepository.AddAsync(questionEntity);

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
