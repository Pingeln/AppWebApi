using Configuration;
using DbContext;
using DbRepos;
using Microsoft.EntityFrameworkCore;
using Services;
using DbContext;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

#region Insert standard WebApi services
// NOTE: global cors policy needed for JS and React frontends
builder.Services.AddCors();

// Add services to the container.
builder.Services.AddControllers().AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();
#endregion

// Retrieve the connection string named "DefaultConnection" from the application's configuration
var connectionString = csAppConfig.ConfigurationRoot.GetConnectionString("DefaultConnection");

// Register csMainDbContext as a service in the DI container
builder.Services.AddDbContext<csMainDbContext>(options =>
    options.UseSqlServer(connectionString)
);

var app = builder.Build();

#region Configure the HTTP request pipeline
//In this example always use Swagger 
//if (app.Environment.IsDevelopment())
//{

app.UseSwagger();
app.UseSwaggerUI();

//}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
#endregion
