﻿using AaronTicket.TicketManagment.Api.Services;
using AaronTicket.TicketManagment.Application;
using AaronTicket.TicketManagment.Application.Contracts;
using AaronTicket.TicketManagment.Infrastructure;
using AaronTicket.TicketManagment.Presistence;
using Microsoft.EntityFrameworkCore;

namespace AaronTicket.TicketManagment.Api
{
    public static class StartUpExtensions
    {
        public static WebApplication ConfigureServices(this WebApplicationBuilder builder)
        {
            builder.Services.AddApplicationServices();
            builder.Services.AddInfrastructureServices(builder.Configuration);
            builder.Services.AddPersistenceServices(builder.Configuration);

            builder.Services.AddScoped<ILoggedInUserService, LoggedInUserService>();
            builder.Services.AddHttpContextAccessor();

            builder.Services.AddControllers();

            builder.Services.AddCors(
                options => options.AddPolicy(
                    "open",
                    policy => policy.WithOrigins([builder.Configuration["ApiUrl"] ??
                    "https://localhost:7020",
                    builder.Configuration["BlazorUrl"] ?? "https://localhost:7080"])
                    .AllowAnyMethod()
                    .SetIsOriginAllowed(pol => true)
                    .AllowAnyHeader()
                    .AllowCredentials()));

            builder.Services.AddSwaggerGen();

            return builder.Build();
        }

        public static WebApplication ConfigurePipeline(this WebApplication app)
        {
            app.UseCors("open");

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.MapControllers();

            return app;
        }

        public static async Task ResetDatabaseAsync(this WebApplication app)
        {
            using var scope = app.Services.CreateScope();

            try
            {
                var context = scope.ServiceProvider.GetService<AaronTicketDbContext>();
                if (context != null)
                {
                    await context.Database.EnsureDeletedAsync();
                    await context.Database.MigrateAsync();
                }
            }
            catch (Exception ex)
            {
                //Add logging here later on
            }
        }
    }
}
