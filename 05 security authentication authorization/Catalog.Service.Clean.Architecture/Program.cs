using Infrastructure.Persistence;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddDbContext<CatalogServiceDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
        {
            options.Authority = "https://localhost:12345";
            options.Audience = "catalogapi";

            options.TokenValidationParameters.ValidTypes = new[] { "at+jwt" };
        }
        );

builder.Services.AddAuthorization((options) =>
{
    options.AddPolicy("manager", policybuilder =>
    {
        policybuilder.RequireAuthenticatedUser();
        policybuilder.RequireClaim("client_access", "read");
        policybuilder.RequireClaim("client_access", "create");
        policybuilder.RequireClaim("client_access", "delete");
        policybuilder.RequireClaim("client_access", "update");
    });
    options.AddPolicy("buyer", policybuilder =>
    {
        policybuilder.RequireAuthenticatedUser();
        policybuilder.RequireClaim("client_access", "read");
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();