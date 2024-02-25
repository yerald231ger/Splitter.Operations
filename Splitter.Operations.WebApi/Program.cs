using Splitter.Operations;
using Splitter.Operations.Data.SqlServer;
using Splitter.Operations.Interface;
using Splitter.Operations.WebApi;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCommandBuilder();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCommensalityService()
    .AddData()
        .AddInMemory();

builder.Services.AddLogging(builder => builder.AddConsole());

builder.Services.AddCors(builder =>
{
    builder.AddPolicy("SplitterFront", policy =>
    {
        policy.WithOrigins("http://localhost:4321")
            .AllowAnyHeader()
            .AllowAnyMethod();

        policy.WithOrigins("https://spliter-eight.vercel.app")
            .AllowAnyHeader()
            .AllowAnyMethod();
    });

});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("SplitterFront");
app.MapCommensalityOperationsRoute();
app.MapCommensalityRoutes();
app.MapOrderRoutes();
app.MapProductRoutes();
app.MapVoucherRoutes();
app.MapGet("/", () => "Hello World, Gerardo..!");
app.Run();