using Application.Contracts;
using Application.Services;
using Core.Contracts;
using Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using NewsAPI;
using Persistence;
using Persistence.Repositories;
using WebApp.Components;
using INewsService = Application.Contracts.INewsService;
using NewsService = Infrastructure.Services.NewsService;

var builder = WebApplication.CreateBuilder(args);


var dbContext = new DbContextOptionsBuilder<DbHelper>().UseInMemoryDatabase("Database");
await using (var db = new DbHelper(dbContext.Options))
{
    await db.GenerateFamousAuthorsAsync();
}

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
//Регистрация зависимостей
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
builder.Services.AddSingleton<IAnalyticsService, AnalyticsService>();

//Регистрация контекста inMemory БД
builder.Services.AddDbContext<DbHelper>(optionsBuilder => 
    //optionsBuilder.UseNpgsql(builder.Configuration.GetConnectionString("Database"))
    optionsBuilder.UseInMemoryDatabase("Database")
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