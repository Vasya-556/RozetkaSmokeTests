using System.Text.RegularExpressions;
using Microsoft.Playwright;
using Microsoft.Playwright.Xunit;

namespace RozetkaSmokeTests.Tests;

public abstract class BasePage: PageTest
{
    protected static readonly string BaseUrl = "https://rozetka.com.ua/";

    public string ExpandLink(string str)
    {
        return BaseUrl + str;
    }

    [Fact]
    public async Task LoadTitle()
    {
        await Page.GotoAsync(BaseUrl);
        
        await Expect(Page)
            .ToHaveTitleAsync(new Regex("ROZETKA"));
    }

    [Fact]
    public async Task LoadNavigation()
    {
        await Page.GotoAsync(BaseUrl);
        
        await Expect(Page
            .GetByRole(AriaRole.Navigation))
            .ToBeVisibleAsync();
    }

    [Fact]
    public async Task LoadFooter()
    {
        await Page.GotoAsync(BaseUrl);
        
        await Expect(Page
            .Locator("rz-footer"))
            .ToBeVisibleAsync();
    }
}