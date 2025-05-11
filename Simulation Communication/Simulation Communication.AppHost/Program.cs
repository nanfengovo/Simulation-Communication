var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.Simulation Communication>("simulation communication");

builder.Build().Run();
