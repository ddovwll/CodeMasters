using Application.Services;
using Infrastructure.Services;
using LikhodedDynamics.Sber.GigaChatSDK;
using NewsAPI;
using Xunit.Abstractions;
using NewsService = Application.Services.NewsService;

namespace Tests;

public class UnitTest1
{
    private readonly ITestOutputHelper _testOutputHelper;

    public UnitTest1(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
    }

    [Fact]
    public async Task Test1()
    {
        /*var article = new ArticleService(new AiService("sk-v5iCClSFvc0KL7hepbqIxsFcAzI5pbzO"));
        _testOutputHelper.WriteLine(await article.GetArticleAsync("апельсины"));*/

        var ser = new NewsService(
            new Infrastructure.Services.NewsService(new NewsApiClient("92ede1b3aaf44a81b66da170f6bb2a93")));
        var news = await ser.GetNewsAsync("новости");
    }
}