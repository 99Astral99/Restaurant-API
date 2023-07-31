using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Restaraunt.Application;
using Restaraunt.Application.Common.Mappings;
using Restaraunt.Application.Interfaces;
using Restaraunt.Application.Services;
using Restaraunt.Domain.Entities.Identity;
using Restaraunt.Persistence;
using Restaraunt.WebApi.Middleware;
using System.Reflection;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(option =>
{
	option.SwaggerDoc("v1", new OpenApiInfo { Title = "Book Store", Version = "v1" });
	option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
	{
		In = ParameterLocation.Header,
		Description = "Please enter a valid token",
		Name = "Authorization",
		Type = SecuritySchemeType.Http,
		BearerFormat = "JWT",
		Scheme = "Bearer"
	});
	option.AddSecurityRequirement(new OpenApiSecurityRequirement
	{
		{
			new OpenApiSecurityScheme
			{
				Reference = new OpenApiReference
				{
					Type = ReferenceType.SecurityScheme,
					Id = "Bearer"
				}
			},
			new string[]{}
		}
	});
});

builder.Services.AddScoped<ITokenService, TokenService>();

builder.Services.AddAutoMapper(cfg =>
{
	cfg.AddProfile(new AssemblyMappingProfile(Assembly.GetExecutingAssembly()));
	cfg.AddProfile(new AssemblyMappingProfile(typeof(IProductDbContext).Assembly));
});

builder.Services.AddApplication();
builder.Services.AddPersistence(builder.Configuration);
builder.Services.AddHealthChecks();
builder.Services.AddControllers();

builder.Services.AddAuthentication(opt =>
{
	opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
	opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
	.AddJwtBearer(options =>
	{
		options.TokenValidationParameters = new TokenValidationParameters
		{
			ValidateIssuer = false,
			ValidateAudience = false,
			ValidateLifetime = true,
			ValidateIssuerSigningKey = true,
			ValidIssuer = builder.Configuration["Jwt:Issuer"]!,
			ValidAudience = builder.Configuration["Jwt:Audience"]!,
			IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Secret"]!))
		};
	});

builder.Services.AddAuthorization(options => options.DefaultPolicy =
	new AuthorizationPolicyBuilder
			(JwtBearerDefaults.AuthenticationScheme)
		.RequireAuthenticatedUser()
		.Build());

builder.Services.AddIdentity<User, IdentityRole<Guid>>(opt =>
{
	opt.User.RequireUniqueEmail = true;
	opt.User.AllowedUserNameCharacters =
	"abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ123456789";

	opt.Password.RequireDigit = false;
	opt.Password.RequireNonAlphanumeric = false;
	opt.Password.RequireUppercase = true;
	opt.Password.RequiredLength = 8;

	opt.Lockout = new LockoutOptions
	{
		AllowedForNewUsers = true,
		DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5),
		MaxFailedAccessAttempts = 5
	};
})
	.AddEntityFrameworkStores<ProductDbContext>()
	.AddUserManager<UserManager<User>>()
	.AddSignInManager<SignInManager<User>>();

builder.Services.AddCors(options =>
{
	options.AddPolicy("Safe", policy =>
	{
		policy.AllowAnyHeader();
		policy.AllowCredentials();
		policy.AllowAnyMethod();
		policy.WithOrigins(builder.Configuration.GetSection("CORS:Urls").Get<string[]>()!);
	});
	options.AddPolicy("AllowAll", policy =>
	{
		policy.AllowAnyHeader();
		policy.AllowAnyMethod();
		policy.AllowAnyOrigin();
	});
});

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
	var serviceProvider = scope.ServiceProvider;
	try
	{
		var context = serviceProvider.GetRequiredService<ProductDbContext>();
		DbInitializer.Initialize(context);
	}
	catch (Exception)
	{
		throw;
	}
}

if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}
app.UseCustomExceptionHandler();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.UseHttpsRedirection();
app.UseCors("AllowAll");

app.MapControllers();
app.MapHealthChecks("/_health");

app.Run();