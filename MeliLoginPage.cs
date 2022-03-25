using OpenQA.Selenium;
using Newtonsoft.Json;

namespace meli.selenium.test
{
    public class MeliLoginPage
    {
        private IWebDriver _driver;
        public MeliLoginPage(IWebDriver driver)
        {
            _driver = driver;
        }

        /*
        public class Pass
        {
            public string Password { get; }

        }
        */

        #region Selectors
        private IWebElement lnkLogin => _driver.FindElement(By.XPath("//*[@id='nav-header-menu']/a[2]"));
        private IWebElement inUser => _driver.FindElement(By.Id("user_id"));
        private IWebElement inPass => _driver.FindElement(By.XPath("//*[@id='password']"));
        private IWebElement btnNext => _driver.FindElement(By.Id("login_user_form"));
        private IWebElement btnLogin => _driver.FindElement(By.Id("action-complete"));
        #endregion


        public void OpenLinkLogin()
        {
            lnkLogin.Click();
        }

        public void LoginAction(string vUser, string vPass)
        {
            inUser.Clear();
            inUser.SendKeys(vUser);
            //_driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(20);
            btnNext.Click();

            inPass.Clear();
            inPass.SendKeys(vPass);
            btnLogin.Click();
        }
    }
}
