using Microsoft.Extensions.Configuration;
using sintetize.Models;

namespace sintetiza_backend.Repository;

public class AnswerService
{
    private readonly TableStorageRepository<AnswerEntity> _repository;

    public AnswerService(IConfiguration configuration)
    {
        _repository = new TableStorageRepository<AnswerEntity>(configuration, "Answers");
    }

    public async Task<List<AnswerEntity>> GetAllAsync()
    {
        return await _repository.GetAllAsync();
    }

    public async Task CreateAync(AnswerEntity entity)
    {
        await _repository.AddAsync(entity);
    }
}