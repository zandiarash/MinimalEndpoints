using MinimalEndpoints.Extensions;
using Scalar.AspNetCore;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();

WebApplication app = builder.Build();

app.MapEndpoints();

// if (app.Environment.IsDevelopment())
// {
app.MapOpenApi();
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/openapi/v1.json", "Rahkaran Transfer");
});
app.MapScalarApiReference(options =>
{
    options
    .WithTitle("Rahkaran Transfer")
    .WithTheme(ScalarTheme.Mars)
    .WithDefaultHttpClient(ScalarTarget.CSharp, ScalarClient.HttpClient);
});
// }

app.Run();
