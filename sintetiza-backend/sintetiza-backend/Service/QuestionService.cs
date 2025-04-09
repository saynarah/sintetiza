using Microsoft.Extensions.Configuration;

namespace sintetiza_backend.Repository;

public class QuestionService 
{
    private readonly TableStorageRepository<QuestionEntity> _repository;

    public QuestionService(IConfiguration configuration)
    {
        _repository = new TableStorageRepository<QuestionEntity>(configuration, "Questions");
    }

    public async Task<List<QuestionEntity>> GetAllAsync()
    {
        return await _repository.GetAllAsync();
    }

    public async Task CreateAync(QuestionEntity entity)
    {
        await _repository.AddAsync(entity);
    }
}
