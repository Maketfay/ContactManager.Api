using Microsoft.EntityFrameworkCore;
using Repositories;
using Infrastucture.Repositories;
using Infrastucture.Entity;
using Entity;
using Contact.Validators;
using Microsoft.OpenApi.Models;
using Core;
using Infrastucture.Core;
using Infrastucture.Services;
using Services;
using Contact.ModelBuilders;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c => c.MapType<DateTime>(() => new OpenApiSchema { Type = "string", Format = "date" }));


ConfigureDataProvider();
ConfigureRepositories();
ConfigureEntities();
ConfigureValidators();
ConfigurePagination();
ConfigureModelBuilders();
ConfigureServices();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();


app.UseAuthorization();

app.MapControllers();

app.UseCors(builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod().SetPreflightMaxAge(TimeSpan.MaxValue));

app.Run();

void ConfigureDataProvider()
{
    var connectionString = builder.Configuration.GetConnectionString("Contact");

    builder.Services.AddDbContext<ApplicationDbContext>(options =>
    {
        options.UseSqlServer(connectionString);
    });
}

void ConfigureRepositories()
{
    builder.Services.AddScoped<IContactRepository, ContactRepository>();
}

void ConfigureEntities()
{
    builder.Services.AddTransient<IContact, ContactEntity>();

}
void ConfigureServices() 
{
    builder.Services.AddScoped<IContactService, ContactService>();
}

void ConfigureValidators()
{
    builder.Services.AddScoped<ContactValidator>();
}

void ConfigureModelBuilders()
{
    builder.Services.AddScoped<ContactModelBuilder>();
}

void ConfigurePagination()
{
    builder.Services.AddTransient(typeof(IPagedList<>), typeof(PagedList<>));
}

