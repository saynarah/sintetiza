using Azure.Data.Tables;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using sintetiza_backend.Repository;
using sintetize.Models;
using System.Net;
using System.Text.Json;

namespace sintetize;

public class SintetizeFunction(SintetizeService service)
{
    [Function("GetAllQuestion")]
    public async Task<HttpResponseData> GetAllQuestion(
    [HttpTrigger(AuthorizationLevel.Anonymous, "get")] HttpRequestData request)
    {
        var questions = await service.GetAllQuestionAsync();

        var response = request.CreateResponse(HttpStatusCode.OK);
        await response.WriteAsJsonAsync(questions);

        return response;
    }

    [Function("GetQuestion")]
    public async Task<HttpResponseData> GetQuestion(
    [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "GetQuestion/{id}")] HttpRequestData request, string id)
    {
        var questions = await service.GetQuestionAsync(id);

        var response = request.CreateResponse(HttpStatusCode.OK);
        await response.WriteAsJsonAsync(questions);

        return response;
    }

    [Function("CreateQuestion")]
    public async Task<HttpResponseData> CreateQuestionAsync([HttpTrigger(AuthorizationLevel.Anonymous, "post")] HttpRequestData request)
    {
        var data = await JsonSerializer.DeserializeAsync<QuestionResponse>(request.Body);
        await service.CreateAync(data);

        var response = request.CreateResponse(HttpStatusCode.Created);
        await response.WriteAsJsonAsync(data);

        return response;
    }

    [Function("CreateAnswer")]
    public async Task<HttpResponseData> CreateAnswerAsync([HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "CreateAnswer")] HttpRequestData request)
    {
        var data = await JsonSerializer.DeserializeAsync<AnswerResponse>(request.Body);
        await service.CreateAnswerAync(data);

        var response = request.CreateResponse(HttpStatusCode.Created);
        await response.WriteAsJsonAsync(data);

        return response;
    }

    [Function("DeleteQuestion")]
    public async Task<HttpResponseData> DeleteQuestionAsync([HttpTrigger(AuthorizationLevel.Anonymous, "delete", Route = "DeleteQuestion/{partitionKey}/{rowKey}")] HttpRequestData request,
        string partitionKey,
        string rowKey)
    {

        await service.DeleteQuestionAsync(partitionKey, rowKey);
        var response = request.CreateResponse(HttpStatusCode.NoContent);

        return response;

    }
}
