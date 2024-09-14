using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Pet.Application.IoC;
using Pet.Infra.Contexts;
using Pet.Infra.IoC;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Configuration
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true, reloadOnChange: true)
    .AddEnvironmentVariables()
    .Build();

builder.Services
    .AddServices()
    .AddInfra(builder.Configuration);

builder.Services.AddSwaggerGen(opt =>
{
    opt.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Tutor API",
        Description = ".NET7 Api to manipulate tutor data"
    });

    //var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    //var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    //opt.IncludeXmlComments(xmlPath);
});

var app = builder.Build();
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

//todo: fix read-only erros in this step
builder.Services.AddDbContext<PetContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("Default"));
});

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();

app.UseSwagger(opt =>
{
    opt.SerializeAsV2 = true;
});

app.UseSwaggerUI(opt =>
{
    opt.SwaggerEndpoint("/swagger/v1/swagger.json", "Pet API - v1");
    opt.RoutePrefix = string.Empty;
});

app.MapControllers();

app.Run();
