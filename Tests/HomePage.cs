using System.Text.RegularExpressions;
using Microsoft.Playwright;
using Microsoft.Playwright.Xunit;

namespace RozetkaSmokeTests.Tests;

public class HomePage: BasePage
{
    [Fact]
    public async Task LoadSearchBar()
    {
        await Page.GotoAsync(BaseUrl);
        
        var searchInput = Page.GetByTestId("search-suggest-input");
        var testProduct = "Test";

        await searchInput.ClickAsync();
        await searchInput.FillAsync(testProduct);
        await searchInput.PressAsync("Enter");

        await Expect(Page)
            .ToHaveURLAsync(new Regex($@"[?](text|search)={testProduct}"));
    }

    [Fact]
    public async Task LoadSideBar()
    {
        await Page.GotoAsync(BaseUrl);
        
        await Page
            .GetByTestId("fat_menu_btn")
            .ClickAsync();

        await Expect(Page
            .Locator("ul[rzfatmenucategories]"))
            .ToBeVisibleAsync();
    }
}