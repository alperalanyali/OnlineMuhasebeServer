

using Domain.AppEntities.Identity;
using Microsoft.AspNetCore.Identity;
using OnlineMuhasebeServer.Webapi.Configurations;
using OnlineMuhasebeServer.Webapi.Middleware;
var builder = WebApplication.CreateBuilder(args);

builder.Services.InstallServices(builder.Configuration,typeof(IServiceInstaller).Assembly);
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}




app.UseCors();
app.UseExceptionMiddleware();

app.MapControllers();


//using (var scoped = app.Services.CreateScope())
//{
//    var userManager = scoped.ServiceProvider.GetRequiredService<UserManager<AppUser>>();
//    if (!userManager.Users.Any())
//    {
//        userManager.CreateAsync(new AppUser
//        {
//            UserName = "aalanyali",
//            Email = "alanyalialper@gmail.com",
//            Id = Guid.NewGuid().ToString(),
//            FullName= "Taner Saydam"
//        }, "Password12*").Wait();
//    }
//}

app.Run();

