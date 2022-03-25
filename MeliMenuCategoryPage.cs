using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace meli.selenium.test
{
    public class MeliMenuCategoryPage
    {
        private IWebDriver _driver;
        public MeliMenuCategoryPage(IWebDriver driver)
        {
            _driver = driver;
        }

        #region Selectors
        private IWebElement searchElement => _driver.FindElement(By.XPath(".//*[@id='cb1-edit']"));
        private IWebElement submitButton => _driver.FindElement(By.XPath(".//*[@class='nav-search-btn']"));
        private IWebElement lnkMenuCategory => _driver.FindElement(By.XPath("/html/body/header/div/div[2]/ul/li[5]"));
        #endregion
        //"/html/body/header/div/div[2]/ul/li[5]"

        public void OpenMenuCateogory(string text)
        {
            lnkMenuCategory.Click();
        }
        


    }



}
