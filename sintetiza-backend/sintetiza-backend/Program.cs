using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using sintetiza_backend.Repository;

var host = new HostBuilder()
    .ConfigureFunctionsWebApplication()
    .ConfigureServices(services =>
    {
        services.AddApplicationInsightsTelemetryWorkerService();
        services.ConfigureFunctionsApplicationInsights();
        services.AddSingleton<SintetizeService>();
        services.AddSingleton<sintetiza_backend.Repository.SintetizeConvert>();
        services.AddSingleton<TableStorageRepository<QuestionEntity>>();
    })
    .Build();

host.Run();
