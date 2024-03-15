using Microsoft.EntityFrameworkCore;
using MindQuote.API;
using MindQuote.Core.Abstracts;
using MindQuote.Core.Entities;
using MindQuote.Infra.FakeData;
using MindQuote.Infra.Persistence;
using MindQuote.Infra.Repositories;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(
    AppDomain.CurrentDomain.GetAssemblies()));

builder.Services.AddScoped <IRepository<Quote>, QuoteRepository>();
builder.Services.AddScoped<IRepository<Author>, AuthorRepository>();
builder.Services.AddScoped<IRepository<Book>, BookRepository>();
builder.Services.AddScoped<IRepository<BookAuthorIntermediaryTable>, BookAuthorIntermediaryRepository>();

builder.Services.AddTransient<QuoteContext>();

builder.Services.AddDbContext<QuoteContext>(
    opt => opt.UseSqlServer(builder.Configuration.GetConnectionString(Settings.LocalQuoteDB)));

Log.Logger = new LoggerConfiguration().WriteTo.Console().CreateLogger();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();