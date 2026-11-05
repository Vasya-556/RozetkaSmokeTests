using System.Text.RegularExpressions;
using Microsoft.Playwright;
using Microsoft.Playwright.Xunit;

namespace RozetkaSmokeTests.Tests;

public class AboutPage: BasePage
{
    const string about = "ua/pages/about/";

    [Fact]
    public async Task LoadText()
    {
        await Page.GotoAsync(ExpandLink(about));

        var matchingText = Page
            .GetByText(new Regex("Маленькі мрії та грандіозні плани", RegexOptions.IgnoreCase))
            .Filter(new() { Visible = true });
        
        await Expect(matchingText.First).ToBeVisibleAsync();
    }

    [Fact]
    public async Task LoadPickupPointsLinks()
    {
        await Page.GotoAsync(ExpandLink(about));

        await Expect(Page
            .GetByRole(AriaRole.Link, new() { Name = "Пункти самовивозу та повернення" }))
            .ToBeVisibleAsync();
    }
}