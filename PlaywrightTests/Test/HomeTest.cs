using Microsoft.Playwright.NUnit;
using NUnit.Framework;
using PageObjects;

namespace PlaywrightTests
{
    [Parallelizable(ParallelScope.Self)]
    [TestFixture]
    public class HomeTest : PageTest
    {
        private CommonPage commonPage;
        private HomeAssert homePage;

        [SetUp]
        public async Task SetUp()
        {
            commonPage = new CommonPage(Page);
            homePage = new HomeAssert(Page);
            await commonPage.NavigateToHome();
        }

        // Navigation tests
        [Test]
        public async Task VerifyNavigationToProducts()
        {
            await commonPage.NavigateToProducts();
        }

        [Test]
        public async Task VerifyNavigationToAddProduct()
        {
            await commonPage.NavigateToAddProduct();
        }

        [Test]
        public async Task VerifyNavigationToPractice()
        {
            await commonPage.NavigateToPractice();
        }

        [Test]
        public async Task VerifyNavigationToLearn()
        {
            await commonPage.NavigateToLearn();
        }

        [Test]
        public async Task VerifyNavigationToLogin()
        {
            await commonPage.NavigateToLogin();
        }

        // Filter testing
        [Test]
        public async Task VerifyUserIsAbleToFilterWithMatches()
        {
            string productName = "Product 1";
            await homePage.SetFilter(productName);
            await homePage.ClickOnFilter();
            await homePage.VerifyTableFilteredResults(productName, await homePage.CountTableRows());
        }

        [Test]
        public async Task VerifyUserIsAbleToFilterWithoutMatches()
        {
            string productName = "Non-existing-Product";
            await homePage.SetFilter(productName);
            await homePage.ClickOnFilter();
            await homePage.VerifyTableNoResults();
        }

        [Test]
        public async Task VerifyUseOfResetButtonWithFilter()
        {
            string productName = "Check Reset Button";
            await homePage.CheckTextNotInFilter(productName);
            await homePage.SetFilter(productName);
            await homePage.CheckTextInFilter(productName);
            await homePage.ClickOnFilter();
            await homePage.CheckTextInFilter(productName);
            await homePage.ClickOnReset();
            await homePage.CheckTextNotInFilter(productName);
        }

        [Test]
        public async Task VerifyUseOfResetButtonWithoutFilter()
        {
            string productName = "Check Reset Button";
            await homePage.CheckTextNotInFilter(productName);
            await homePage.SetFilter(productName);
            await homePage.CheckTextInFilter(productName);
            await homePage.ClickOnReset();
            await homePage.CheckTextNotInFilter(productName);
        }

        [Test]
        public async Task VerifyShowMoreFunctionality()
        {
            await homePage.CheckShowMoreFunction();
        }
    }
}