using Microsoft.AspNetCore.Authentication.JwtBearer;
using Users.API.Extensions;
using Users.API.Extensions.Builder;
using Users.API.Extensions.Builder.Common;
using Users.Application.Options;

var builder = WebApplication.CreateBuilder(args);

builder.AddPostgresDatabase();
builder.Services.AddControllers();
builder.Services
    .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearerAuthentication(builder.Configuration);

builder.AddRepositories();
builder.AddAutoMapper();
builder.AddMediatr();
builder.AddNormalizeRoute();
builder.AddSwagger();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();
app.Run();