using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;

namespace PageObjects;

public class HomePage : PageTest
{
    private readonly IPage _page;
    public HomePage(IPage page) => _page = page;

    // Locators 
    public ILocator PageContainer => _page.Locator(".product-list-container");
    public ILocator FilterContainer => PageContainer.Locator(".filter-container");
    public ILocator TextBoxFilter => FilterContainer.GetByPlaceholder("Filter by product name");
    public ILocator ButtonFilter => FilterContainer.GetByTestId("filter-button");
    public ILocator ButtonReset => FilterContainer.GetByTestId("reset-filter-button");
    public ILocator ButtonShowMore => _page.GetByTestId("show-more-button");
    public ILocator TextNoResults => PageContainer.Locator(".add-product-message").GetByText("No products found");
    public ILocator Table => _page.Locator(".product-list-table");
    public ILocator TableHeaders => Table.Locator("thead");
    public ILocator TableRows => Table.Locator("tbody").Locator("tr");
    public ILocator TableNRow(int i) => TableRows.Nth(i);
    public ILocator TableProductName(int i) => TableRows.Nth(i).GetByTestId("name");

    // Actions
    // Filter
    public async Task SetFilter(string productName)
    {
        await TextBoxFilter.TypeAsync(productName);
    }

    public async Task ClearFilter()
    {
        await TextBoxFilter.ClearAsync();
    }

    public async Task ClickOnFilter()
    {
        await ButtonFilter.ClickAsync();
    }

    public async Task ClickOnReset()
    {
        await ButtonReset.ClickAsync();
    }

    public async Task<int> CountTableRows()
    {
        return await TableRows.CountAsync();
    }

    public async Task ClickOnShowMore()
    {
        await ButtonShowMore.ClickAsync();
        await Expect(ButtonShowMore).ToBeHiddenAsync();
    }
}