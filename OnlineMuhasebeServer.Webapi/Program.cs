using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Persistence.Context;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer"));
});
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen( setup =>
{
    var jwtSecurityScheme = new OpenApiSecurityScheme
    {
        BearerFormat = "JWT",
        Name = "JWT Authencation",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Scheme = JwtBearerDefaults.AuthenticationScheme,
        Description = "Put **_ONLY_** your JWT Bearer Token on textbox below",
        Reference = new OpenApiReference
        {
            Id=JwtBearerDefaults.AuthenticationScheme,
            Type = ReferenceType.SecurityScheme
        }
        
    };
    setup.AddSecurityDefinition(jwtSecurityScheme.Reference.Id, jwtSecurityScheme);
    setup.AddSecurityRequirement(new OpenApiSecurityRequirement {
        {jwtSecurityScheme,Array.Empty<string>() }
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();

