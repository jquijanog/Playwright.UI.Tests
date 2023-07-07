using Microsoft.Playwright;
using NUnit.Framework;

namespace PageObjects
{
    public class HomeAssert : HomePage
    {
        private readonly IPage _page;
        public HomeAssert(IPage page) : base(page) => _page = page;

        public async Task VerifyTableFilteredResults(string productName, int productNameCount)
        {
            await Expect(Table).ToBeVisibleAsync();
            for (int i = 0; i < productNameCount; i++)
            {
                await Expect(TableProductName(i)).ToContainTextAsync(productName);
            }
        }

        public async Task VerifyTableNoResults()
        {
            await Expect(Table).ToBeHiddenAsync();
            await Expect(TextNoResults).ToBeVisibleAsync();
        }

        public async Task CheckTextInFilter(string text)
        {
            await Expect(TextBoxFilter).ToHaveAttributeAsync("value", text);
        }

        public async Task CheckTextNotInFilter(string text)
        {
            await Expect(TextBoxFilter).Not.ToHaveAttributeAsync("value", text);
            await Expect(TextBoxFilter).ToBeEmptyAsync();
        }

        public async Task CheckShowMoreFunction()
        {
            int initialRows = await CountTableRows();
            await ClickOnShowMore();
            int currentRows = await CountTableRows();
            if (initialRows >= currentRows)
            {
                Assert.Fail($"initialRows ({initialRows}) >= currentRows ({currentRows}).");
            }
        }
    }
}