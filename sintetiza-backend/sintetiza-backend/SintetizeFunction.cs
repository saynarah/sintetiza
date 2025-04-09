using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using System.ComponentModel.DataAnnotations.Schema;

namespace sintetize;

public class SintetizeFunction
{
    private readonly ILogger<SintetizeFunction> _logger;

    public SintetizeFunction(ILogger<SintetizeFunction> logger)
    {
        _logger = logger;
    }

    //[Function("GetQuestions")]
    //public async Task<IActionResult> GetQuestions(
    //    [HttpTrigger(AuthorizationLevel.Function, "get", Route = "question")] HttpRequest req,
    //    [Table("Questions", Connection = "AzureWebJobsStorage")] CloudTable questionTable)
    //{
    //    _logger.LogInformation("Getting all questions...");

    //    var query = new TableQuery<IQuestionEntity>().Where(TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.Equal, "question"));
    //    var segment = await questionTable.ExecuteQuerySegmentedAsync(query, null);
    //    var results = segment.Results.Select(q => new IQuestion
    //    {
    //        Id = q.RowKey,
    //        Pergunta = q.Pergunta,
    //        DataCriacao = q.DataCriacao
    //    });

    //    return new OkObjectResult(results);
    //}

    //[Function("CreateQuestion")]
    //public async Task<IActionResult> CreateQuestion(
    //    [HttpTrigger(AuthorizationLevel.Function, "post", Route = "question")] HttpRequest req,
    //    [Table("Questions", Connection = "AzureWebJobsStorage")] IAsyncCollector<IQuestionEntity> outputTable)
    //{
    //    _logger.LogInformation("Creating new question...");

    //    string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
    //    var data = JsonConvert.DeserializeObject<IQuestion>(requestBody);

    //    if (string.IsNullOrWhiteSpace(data.Pergunta))
    //        return new BadRequestObjectResult("Pergunta é obrigatória.");

    //    var entity = new IQuestionEntity(Guid.NewGuid().ToString(), data.Pergunta);
    //    await outputTable.AddAsync(entity);

    //    return new OkObjectResult("Pergunta adicionada com sucesso.");
    //}

    //[Function("DeleteQuestion")]
    //public async Task<IActionResult> DeleteQuestion(
    //    [HttpTrigger(AuthorizationLevel.Function, "delete", Route = "question/{id}")] HttpRequest req,
    //    [Table("Questions", "question", "{id}", Connection = "AzureWebJobsStorage")] IQuestionEntity entity,
    //    [Table("Questions", Connection = "AzureWebJobsStorage")] CloudTable questionTable,
    //    string id)
    //{
    //    if (entity == null)
    //        return new NotFoundObjectResult("Pergunta não encontrada.");

    //    var deleteOperation = TableOperation.Delete(entity);
    //    await questionTable.ExecuteAsync(deleteOperation);

    //    return new OkObjectResult("Pergunta deletada.");
    //}
}
