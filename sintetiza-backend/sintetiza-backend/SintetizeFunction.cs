using Microsoft.AspNetCore.Http;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using sintetiza_backend.Repository;
using System.Net;
using System.Text.Json;

namespace sintetize;

public class SintetizeFunction(
    ILogger<SintetizeFunction> logger,
    QuestionService service)
{

    [Function("CreateQuestion")]
    public async Task<HttpResponseData> CreateAsync([HttpTrigger(AuthorizationLevel.Function, "post")] HttpRequestData req)
    {
        var data = await JsonSerializer.DeserializeAsync<QuestionEntity>(req.Body);
        await service.CreateAync(data);

        var response = req.CreateResponse(HttpStatusCode.Created);
        await response.WriteAsJsonAsync(data);
        return response;
    }

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
