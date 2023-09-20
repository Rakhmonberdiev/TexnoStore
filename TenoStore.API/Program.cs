using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using TenoStore.API.Errors;
using TenoStore.API.Extensions;
using TenoStore.API.Helpers;
using TenoStore.API.Middleware;
using TexnoStore.Core.Interfaces;
using TexnoStore.Infrastructure.Data;
using TexnoStore.Infrastructure.Data.Implementation;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApplicationServices(builder.Configuration);
builder.Services.AddSwaggerDoc();


builder.Services.AddControllers();

var app = builder.Build();
app.UseMiddleware<ExceptionMiddleware>();
app.UseSwaggerDoc();
app.UseStatusCodePagesWithReExecute("/errors/{0}");


app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAuthorization();

app.MapControllers();

using var scope = app.Services.CreateScope();
var services = scope.ServiceProvider;

var context = services.GetRequiredService<TexnoStoreContext>();
var logger = services.GetRequiredService<ILogger<Program>>();
try
{
    await context.Database.MigrateAsync();
    await TexnoStoreContextSeed.SeedAsync(context);

}
catch (Exception ex)
{
    logger.LogError(ex, "An error occured during migration");
}

app.Run();
