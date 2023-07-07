using Microsoft.Playwright;

namespace PageObjects;

public class CommonPage
{
    private readonly IPage _page;
    public CommonPage(IPage page) => _page = page;
    const string URL = "https://commitquality.com/";

    // Header bannner locators
    public ILocator LinkProducts => _page.GetByTestId("navbar-products");
    public ILocator LinkAddProduct => _page.GetByTestId("navbar-addproduct");
    public ILocator LinkPractice => _page.GetByTestId("navbar-practice");
    public ILocator LinkLearn => _page.GetByTestId("navbar-learn");
    public ILocator LinkLogin => _page.GetByTestId("navbar-login");

    public async Task NavigateToHome()
    {
        await _page.GotoAsync(URL, new PageGotoOptions
        {
            WaitUntil = WaitUntilState.DOMContentLoaded
        });
        await _page.WaitForURLAsync("**/");
    }

    public async Task NavigateToProducts()
    {
        await LinkProducts.ClickAsync();
        await _page.WaitForURLAsync("**/");
    }

    public async Task NavigateToAddProduct()
    {
        await LinkAddProduct.ClickAsync();
        await _page.WaitForURLAsync("**/add-product");
    }

    public async Task NavigateToPractice()
    {
        await LinkPractice.ClickAsync();
        await _page.WaitForURLAsync("**/practice");
    }

    public async Task NavigateToLearn()
    {
        await _page.RunAndWaitForPopupAsync(async () =>
            await LinkLearn.ClickAsync()
        );
    }

    public async Task NavigateToLogin()
    {
        await LinkLogin.ClickAsync();
        await _page.WaitForURLAsync("**/login");
    }
}