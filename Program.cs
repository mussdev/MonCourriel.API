using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using MonCourriel.API.Data;

var builder = WebApplication.CreateBuilder(args);

// Ajouter IWebHostEnvironment dans le service
//builder.Services.AddSingleton<IWebHostEnvironment>(builder.Environment);

// Add services to the container.
builder.Services.AddControllers().AddNewtonsoftJson(options => {
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
});
/* .AddJsonOptions(options => {
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
}); */

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// service DbContext
var connectionString = builder.Configuration.GetConnectionString("MonCourrielConnectionString");
builder.Services.AddDbContext<MonCourrielDbContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(policy => policy.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());

app.UseAuthorization();

app.MapControllers();

app.Run();
