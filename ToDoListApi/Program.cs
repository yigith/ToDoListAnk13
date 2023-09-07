using Microsoft.EntityFrameworkCore;
using ToDoListApi.Data;

// https://learn.microsoft.com/en-us/aspnet/core/security/cors?view=aspnetcore-7.0
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCors(s => s.AddDefaultPolicy(p => 
    p.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin()    
));
var cs = builder.Configuration.GetConnectionString("ApplicationDbContext");
builder.Services.AddDbContext<ApplicationDbContext>(o => o.UseSqlServer(cs));
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

app.UseHttpsRedirection();

app.UseCors();

app.UseAuthorization();

app.MapControllers();

app.Run();
