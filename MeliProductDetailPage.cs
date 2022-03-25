using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace meli.selenium.test
{
    public class MeliProductDetailPage
    {
        private IWebDriver _driver;
        public MeliProductDetailPage(IWebDriver driver)
        {
            _driver = driver;
        }

        #region Selectors
        private IWebElement searchElement => _driver.FindElement(By.XPath(".//*[@id='cb1-edit']"));
        private IWebElement submitButton => _driver.FindElement(By.XPath(".//*[@class='nav-search-btn']"));
        private IWebElement lnkFirstProduct => _driver.FindElement(By.XPath("//ol[@class='ui-search-layout ui-search-layout--stack']//li//a[@class='ui-search-link']"));
        private IWebElement lblTitleProduct => _driver.FindElement(By.XPath("//div[@class='ui-pdp-container ui-pdp-container--pdp']//h1"));

        #endregion


        public void OpenFirstProduct(int index)
        {
            lnkFirstProduct.Click();
        }

        public bool FindTextTitle(string vTextoBusqueda)
        {
            bool bExist = false;
            string sResult = "";

            sResult = lblTitleProduct.Text;
            bExist = (sResult.Contains(vTextoBusqueda)) ? true : false;

            return bExist;
        }


    }



}
