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
        logger.LogInformation("Creating new question...", data);
        return response;
    }

    [Function("GetQuestion")]
    public async Task<HttpResponseData> GetQuestion(
        [HttpTrigger(AuthorizationLevel.Function, "get", Route = "question")] HttpRequestData req)
    {
        logger.LogInformation("Get question...");
        var questions = await service.GetAllAsync();

        var response = req.CreateResponse(HttpStatusCode.OK);
        await response.WriteAsJsonAsync(questions);
        logger.LogInformation("Creating new question...", response);
        return response;
    }

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
