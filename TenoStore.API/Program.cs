using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TenoStore.API.Extensions;
using TenoStore.API.Middleware;
using TexnoStore.Core.Entities;
using TexnoStore.Infrastructure.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApplicationServices(builder.Configuration);
builder.Services.AddSwaggerDoc();
builder.Services.AddCors(opt =>
{
    opt.AddPolicy("CorsPolicy", policy =>
    {
        policy.AllowAnyHeader().AllowAnyMethod().WithOrigins("http://localhost:4200");
    });
});


builder.Services.AddControllers();

var app = builder.Build();
app.UseMiddleware<ExceptionMiddleware>();
app.UseSwaggerDoc();
app.UseStatusCodePagesWithReExecute("/errors/{0}");


app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAuthorization();
app.UseAuthentication();
app.UseCors("CorsPolicy");
app.MapControllers();

using var scope = app.Services.CreateScope();
var services = scope.ServiceProvider;


var logger = services.GetRequiredService<ILogger<Program>>();

try
{
    var context = services.GetRequiredService<TexnoStoreContext>();
    var userManager = services.GetRequiredService<UserManager<AppUser>>();
    var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
    await context.Database.MigrateAsync();
    await TexnoStoreContextSeed.SeedAsync(context);
    await SeedIdentityUser.SeedUsersAsync(userManager,roleManager);
}
catch (Exception ex)
{
    logger.LogError(ex, "An error occured during migration");
}

app.Run();
