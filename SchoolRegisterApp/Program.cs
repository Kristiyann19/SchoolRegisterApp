using Microsoft.EntityFrameworkCore;
using SchoolRegisterApp.Models;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<SchoolRegisterDbContext>(options =>
options.UseNpgsql(connectionString));

AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(options => options
    .AllowAnyHeader()
    .AllowAnyOrigin()
    .AllowAnyMethod());

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
