// PIZZA API

using Microsoft.EntityFrameworkCore;
using Pizza.API.Persistence;
using Steeltoe.Discovery.Client;
using Steeltoe.Discovery.Consul;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddServiceDiscovery(options =>
    options.UseConsul());

//var connectionString = builder.Configuration
//    .GetConnectionString("PizzaDb");

builder.Services.AddDbContext<PizzaDbContext>(options =>
    options.UseInMemoryDatabase("pizza"));
//options.UseSqlite(connectionString));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<PizzaRepository>();
builder.Services.AddScoped<EstoqueRepository>();

builder.Services.AddProblemDetails();

builder.Services.AddHealthChecks();

var app = builder.Build();

app.UseHealthChecks("/health");

app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.UseExceptionHandler("/error");


//using (var Scope = app.Services.CreateScope())
//{
//    var dbContext = Scope.ServiceProvider.GetRequiredService<PizzaDbContext>();
//    dbContext.Database.EnsureCreated(); // Cria o banco de dados se não existir
//    dbContext.Database.Migrate();
//}

app.Run();
