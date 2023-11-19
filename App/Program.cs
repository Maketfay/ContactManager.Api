using Microsoft.EntityFrameworkCore;
using Repositories;
using Infrastucture.Repositories;
using Infrastucture.Entity;
using Entity;
using Contact.Validators;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c => c.MapType<DateTime>(() => new OpenApiSchema { Type = "string", Format = "date" }));


ConfigureDataProvider();
ConfigureRepositories();
ConfigureEntities();
ConfigureValidators();

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

void ConfigureValidators()
{
    builder.Services.AddScoped<ContactValidator>();
}

