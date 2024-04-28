using NUnit.Framework;
using Microsoft.Playwright; 

namespace myPlaywrightPlaygroundV1
{
    [TestFixture]
    public class Tests
    {
        private IPlaywright _playwright;
        private IBrowser _browser;
        private IPage _page;
        private LoginPage _loginPage;

        [SetUp]
        public async Task Setup()
        {
            // Launch a new browser instance
            _playwright = await Playwright.CreateAsync();
            _browser = await _playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Headless = false // Set to true if you want to run in headless mode
            });

            // Create a new browser context
            var context = await _browser.NewContextAsync();

            // Create a new page within the context
            _page = await context.NewPageAsync();

            // Initialize the LoginPage with the page
            _loginPage = new LoginPage(_page);
        }

        [Test]
        public async Task TestLoginButton()
        {
            // Use the LoginPage to navigate and interact with the page
            await _loginPage.GoToAsync();

            // Wait for the page to load
            await Task.Delay(4000);

            // Click the login button
            await _loginPage.ClickLoginButtonAsync();

            // Wait for the page to load or for any necessary actions
            await Task.Delay(4000);

            // Add assertion or further actions here
            // Assert if the login heading is displayed
            Assert.IsTrue(await _loginPage.IsLoginHeadingDisplayedAsync(), "Login heading is not displayed");
        }

        [TearDown]
        public async Task TearDown()
        {
            // Close the browser
            await _browser.CloseAsync();
        }
    }
}
