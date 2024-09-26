using Application.Services;
using Infrastructure.Services;
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
        
    }
}