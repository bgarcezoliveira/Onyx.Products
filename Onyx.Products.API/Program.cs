using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Onyx.Products.Application;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
    .AddJsonOptions(configure => configure.JsonSerializerOptions.PropertyNamingPolicy = null);

builder.Services.AddApplication(
    builder.Configuration["ConnectionStrings:ProductsDBConnectionString"]);
builder.Services.AddHttpContextAccessor();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddHealthChecks();

JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.Authority = "https://localhost:5001";
        options.Audience = "onyxproductsapi";
        options.TokenValidationParameters = new()
        {
            NameClaimType = "given_name",
            RoleClaimType = "role",
            ValidTypes = new[] { "at+jwt" },
        };
    });

builder.Services.AddAuthorization(configure =>
{
    configure.AddPolicy("CanGetAllProducts", policyBuilder =>
    {
        policyBuilder
            .RequireAuthenticatedUser()
            .RequireClaim("http://schemas.microsoft.com/ws/2008/06/identity/claims/role", "Admin");
    });
    configure.AddPolicy("CanFilterProductsByColour", policyBuilder =>
    {
        policyBuilder
            .RequireAuthenticatedUser()
            .RequireClaim("http://schemas.microsoft.com/ws/2008/06/identity/claims/role", "Admin", "PublicUser");
    });
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapHealthChecks("api/healthz");
app.MapControllers();



app.Run();

