using Microsoft.OpenApi.Models;
using TestApplication.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddTransient<FileService>();
builder.Services.AddTransient<PersistenceService>();
builder.Services.AddControllers();
builder.Services.AddSwaggerGen(c => { c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" }); });


var app = builder.Build();
app.UseRouting();
app.MapControllers();
app.UseSwagger();
app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "API"); });


app.Run();