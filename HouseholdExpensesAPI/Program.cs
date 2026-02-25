using Microsoft.EntityFrameworkCore;
using HouseholdExpenses.Infrastructure.Data;
using HouseholdExpenses.Application.Interfaces;
using HouseholdExpenses.Application.Services;

var builder = WebApplication.CreateBuilder(args);

// Configurar SQLite
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite("Data Source=household_expenses.db"));

// Registrar Serviços
builder.Services.AddScoped<ITransactionService, TransactionService>();
builder.Services.AddScoped<IPersonService, PersonService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configurar CORS
builder.Services.AddCors(options => {
    options.AddPolicy("AllowReactApp",
        policy => policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowReactApp");
app.UseAuthorization();
app.MapControllers();

app.Run();