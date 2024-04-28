using NUnit.Framework;
using Microsoft.Playwright;

namespace myPlaywrightPlaygroundV1 {
    public class LoginPage {
        private readonly IPage _page;
        private readonly ILocator _clickLoginButton;

        public LoginPage(IPage page) {
            _page = page;
            _clickLoginButton = page.Locator("a[href='/login']");
        }

        public async Task GoToAsync() {
            await _page.GotoAsync("https://automationexercise.com");
        }
 
        public async Task ClickLoginButtonAsync() {
            await _clickLoginButton.ClickAsync();
        }

        public async Task<bool> IsLoginHeadingDisplayedAsync()
        {
            var headingLocator = _page.Locator("h2:has-text('Login to your account')");
            return await headingLocator.IsVisibleAsync();
        }
    }
}