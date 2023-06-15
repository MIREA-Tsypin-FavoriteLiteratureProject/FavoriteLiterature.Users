using Microsoft.AspNetCore.Authentication.JwtBearer;
using Users.API.Extensions;
using Users.API.Extensions.Builder;
using Users.API.Extensions.Builder.Common;
using Users.API.Middlewares;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddJsonFile("appsettings.Local.json", optional: true);

builder.AddPostgresDatabase();
builder.Services.AddControllers();
builder.Services
    .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearerAuthentication(builder.Configuration);

builder.AddRolePolicy();
builder.AddRepositories();
builder.AddAutoMapper();
builder.AddCustomMiddlewares();
builder.AddMediatr();
builder.AddNormalizeRoute();
builder.AddSwagger();

var app = builder.Build();
app.UseMiddleware<ExceptionHandlingMiddleware>();
app.SeedDatabase();

app.UseSwagger();
app.UseSwaggerUI();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.Run();