using System.Text.RegularExpressions;
using Microsoft.Playwright;
using Microsoft.Playwright.Xunit;

namespace RozetkaSmokeTests.Tests;

public class ProductPage: BasePage
{
    const string product = "ua/583050706/p583050706/";

    [Fact]
    public async Task LoadImage()
    {
        await Page.GotoAsync(ExpandLink(product));
        
        var productImage = Page.Locator("img[srcset*='https://content.rozetka.com.ua/goods/images/']");

        await Expect(productImage)
            .ToBeVisibleAsync();

        await Expect(productImage)
            .ToHaveCountAsync(1);
        await Expect(productImage)
            .ToBeVisibleAsync();

        await Expect(productImage)
            .ToHaveJSPropertyAsync("complete", true);
    }

    [Fact]
    public async Task LoadTabs()
    {
        await Page.GotoAsync(ExpandLink(product));
        
        await Expect(Page
            .Locator("rz-tabs"))
            .ToBeVisibleAsync();
    }

    [Fact]
    public async Task LoadBuyButton()
    {     
        await Page.GotoAsync(ExpandLink(product));
        
        await Expect(Page
            .GetByRole(AriaRole.Button, new() { Name = "Купити" }))
            .ToBeVisibleAsync();
        
        await Expect(Page
            .GetByRole(AriaRole.Button, new() { Name = "Купити" }))
            .ToBeEnabledAsync();
    }
}