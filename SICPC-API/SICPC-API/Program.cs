using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using SICPC_API.Entities.Models;
using SicpcAPI.Entities.Models;
using SicpcAPI.Entities.Models.Seguridad;
using SicpcAPI.Helpers;
using System.Net;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
var connection = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<SicpcContext>(options =>
{
    options.UseSqlServer(connection);
});
// Add services to the container.
builder.Services.AddControllers().AddNewtonsoftJson(opt =>
{
    opt.SerializerSettings.PreserveReferencesHandling = PreserveReferencesHandling.None;
    opt.SerializerSettings.MetadataPropertyHandling = MetadataPropertyHandling.Ignore;
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// IoC  - Inyeccion de dependencias para los Repositorys y Services
builder.Services.Scan(scan => scan
    .FromAssemblyOf<Program>()
    .AddClasses(classes => classes.InNamespaces("SicpcAPI.Repositorys"))
    .AsSelf().WithTransientLifetime()
);

// Registrando servicios y sus interfaces
builder.Services.Scan(scan => scan
    .FromAssemblyOf<Program>()
    .AddClasses(classes => classes.InNamespaces("SICPC_API.Services"))
    .AsSelf().WithTransientLifetime()
);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseExceptionHandler(builder =>
{
    builder.Run(async context =>
    {
        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

        var error = context.Features.Get<IExceptionHandlerFeature>();
        if (error != null)
        {
            var exceptionType = error.GetType();

            var exceptionHandlerPathFeature =
                    context.Features.Get<IExceptionHandlerPathFeature>();

            if (exceptionHandlerPathFeature?.Error is SicpcException)
            {
                bool unathorized = exceptionHandlerPathFeature?.Error is UnauthorizedException;

                context.Response.StatusCode = unathorized ? 401 : 409;
                context.Response.AddApplicationError(((SicpcException)error.Error).ErrorMessage);
                await context.Response.WriteAsync(((SicpcException)error.Error).ErrorMessage);
            }
            else
            {
                string errorMessageDefault = "Ocurrió un error inesperado, favor de contactar al administrador del sistema";
                // Logger.WriteError(exceptionHandlerPathFeature.Error, app.Environment);

                context.Response.AddApplicationError(errorMessageDefault);
                await context.Response.WriteAsync(errorMessageDefault);
            }
        }
    });
});


app.UseRouting();
app.UseCors(builder =>
{
    builder.AllowAnyOrigin()
    .AllowAnyHeader()
    .WithMethods("GET", "POST", "PUT", "DELETE");
});
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});



if (!app.Environment.IsDevelopment())
{
    app.UseDefaultFiles();
    app.UseStaticFiles();

    app.UseEndpoints(endpoints =>
    {
        endpoints.MapControllers();
        // endpoints.MapFallbackToController("Index", "Fallback");
    });
}


app.Run();
