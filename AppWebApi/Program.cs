using Configuration;
using DbContext;
using Microsoft.EntityFrameworkCore;
using Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

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

/*1. Retrieve the connection string from your configuration
var connectionString = csAppConfig.DbSetActive.DbLogins.Find(
    i => i.DbServer == "SQLServer" && i.DbUserLogin == "sysadmin").DbConnectionString;

builder.Services.AddDbContext<csMainDbContext>(options =>
    options.UseSqlServer(connectionString)
);
*/

builder.Services.AddDbContext<csMainDbContext.SqlServerDbContext>();

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
