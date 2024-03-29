﻿using Limq.Api.Hubs;
using Limq.Application;
using Limq.Infastructure;
using Limq.Persistence;


var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins, policy =>
                  {
                      policy.WithOrigins("https://localhost:7068", "https://localhost:7157")
                      .AllowAnyHeader()
                      .AllowAnyMethod()
                      .AllowCredentials();
                  });
});

builder.Services.AddSignalR();

builder.Services.AddApplicationServices();
builder.Services.AddInfastructureServices();
builder.Services.AddPersistenceServices(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseCors(MyAllowSpecificOrigins);

app.UseRouting();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapHub<ChatHub>($"/{nameof(ChatHub)}");
    endpoints.MapHub<SquadHub>($"/{nameof(SquadHub)}");
});



app.MapControllers();

app.Run();
