using Splitter.BCMenu;
using Splitter.Commensality.Data.SqlServer;
using Splitter.BCMenu.WebApi;
using Splitter.Extensions;
using Splitter.BCMenu.Data.SqlServer;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCommandBuilder();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMenu()
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
    var d = app.Services.CreateScope().ServiceProvider.GetRequiredService<MenuDbContext>();
    d.Database.EnsureCreated();
}

app.UseHttpsRedirection();
app.UseCors("SplitterFront");
app.MapMenuRoutes();

app.MapGet("/", () => "Hello menu..!");
app.Run();
public partial class Program { }