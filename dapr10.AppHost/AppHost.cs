using CommunityToolkit.Aspire.Hosting.Dapr;

var builder = DistributedApplication.CreateBuilder(args);

DaprSidecarOptions CreateSidecarOptions(int metricsPort) => new()
{
    LogLevel = "Debug",
    EnableApiLogging = true,
    MetricsPort = metricsPort,
    Config = "../config.yaml"
};

var apiService = builder.AddProject<Projects.dapr10_ApiService>("apiservice")
    .WithDaprSidecar(CreateSidecarOptions(9091))
    .WithHttpHealthCheck("/health");

builder.AddProject<Projects.dapr10_Web>("webfrontend")
    .WithDaprSidecar(CreateSidecarOptions(9092))
    //.WithExternalHttpEndpoints()
    .WithHttpHealthCheck("/health")
    .WithReference(apiService)
    .WaitFor(apiService);

builder.Build().Run();
