using Microsoft.EntityFrameworkCore;
using BudgetApprovedApi.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using BudgetApprovedApi.Services; 

var builder = WebApplication.CreateBuilder(args);

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.AllowAnyOrigin() 
                                .AllowAnyHeader()
                                .AllowAnyMethod();
                      });
});

// --- END: CONFIGURARE CORS ---

var connectionString = builder.Configuration.GetConnectionString("ConnectionString");

if (string.IsNullOrEmpty(connectionString))
{
    throw new InvalidOperationException("Connection string 'ConnectionString' not found or is empty in configuration.");
}

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddDbContext<DatabaseService>(options =>
    options.UseSqlServer(connectionString),
    ServiceLifetime.Scoped);

builder.Services.AddTransient<IUserService, UserService>(); 


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors(MyAllowSpecificOrigins);
app.MapControllers();

app.Run();
