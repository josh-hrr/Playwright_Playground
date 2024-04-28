using NUnit.Framework;
using Microsoft.Playwright;

namespace PlaywrightDemo;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public async Task Test1()
    {   
        // Launch a new browser instance
            using var playwright = await Playwright.CreateAsync();
            await using var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Headless = false // Set to true if you want to run in headless mode
            });

            // Create a new browser context
            var context = await browser.NewContextAsync();

            // Create a new page within the context
            var page = await context.NewPageAsync();

            // Navigate to a webpage
            await page.GotoAsync("https://automationexercise.com");

            // Wait for 5 seconds
            await Task.Delay(5000);

            // Click a button (replace "buttonSelector" with the actual selector of the button)
            await page.ClickAsync("a[href='/login']");

            // Wait for 5 seconds
            await Task.Delay(5000);
            
            // Close the browser
            await browser.CloseAsync();
            //Assert.Pass();
    }
}
