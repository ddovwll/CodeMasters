using Application.Contracts;
using Application.Services;
using Core.Contracts;
using Infrastructure.Services;
using LikhodedDynamics.Sber.GigaChatSDK;
using Microsoft.EntityFrameworkCore;
using NewsAPI;
using Persistence;
using Persistence.Repositories;
using WebApp.Components;
using INewsService = Application.Contracts.INewsService;
using NewsService = Infrastructure.Services.NewsService;

var builder = WebApplication.CreateBuilder(args);


var dbContext = new DbContextOptionsBuilder<DbHelper>().UseNpgsql(builder.Configuration.GetConnectionString("Database"));
await using (var db = new DbHelper(dbContext.Options))
{
    await db.GenerateFamousAuthorsAsync();
}

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddScoped<NewsApiClient>(_ => 
    new NewsApiClient(builder.Configuration["NewsApiKey"]));
builder.Services.AddScoped<INewsService, NewsService>();
builder.Services.AddScoped<Core.Contracts.INewsService, Application.Services.NewsService>();
builder.Services.AddScoped<IAuthorRepository, AuthorRepository>();
builder.Services.AddScoped<IAuthorService, AuthorService>();
builder.Services.AddSingleton<IAiService, AiService>(_=>new AiService(builder.Configuration["ProxyApiKey"]));
builder.Services.AddScoped<IArticleService, ArticleService>();
builder.Services.AddScoped<ISavedArticleRepository, SavedArticleRepository>();
builder.Services.AddScoped<ISavedArticleService, SavedArticleService>();

builder.Services.AddDbContext<DbHelper>(optionsBuilder => 
    optionsBuilder.UseNpgsql(builder.Configuration.GetConnectionString("Database"))
    );


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();