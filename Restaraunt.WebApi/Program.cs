using Restaraunt.Application;
using Restaraunt.Application.Common.Mappings;
using Restaraunt.Application.Interfaces;
using Restaraunt.Persistence;
using Restaraunt.WebApi.Middleware;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(cfg =>
{
	cfg.AddProfile(new AssemblyMappingProfile(Assembly.GetExecutingAssembly()));
	cfg.AddProfile(new AssemblyMappingProfile(typeof(IProductDbContext).Assembly));
});

builder.Services.AddApplication();
builder.Services.AddPersistence(builder.Configuration);
builder.Services.AddHealthChecks();
builder.Services.AddControllers();

builder.Services.AddCors(options =>
{
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
app.UseHttpsRedirection();
app.UseCors("AllowAll");

app.MapControllers();
app.MapHealthChecks("/_health");

app.Run();