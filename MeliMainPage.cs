using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


namespace meli.selenium.test
{
    public class MeliMainPage
    {
        private IWebDriver _driver;

        public MeliMainPage(IWebDriver driver)
        {
            _driver = driver;
        }

        #region Selectors
        private IWebElement searchElement => _driver.FindElement(By.XPath(".//*[@id='cb1-edit']"));
        private IWebElement submitButton => _driver.FindElement(By.XPath(".//*[@class='nav-search-btn']"));
        private IWebElement lblCant => _driver.FindElement(By.XPath("//*[@id='root-app']/div/div[1]/aside/div[2]/span"));
        private IWebElement lnkFirstProduct => _driver.FindElement(By.XPath("//ol[@class='ui-search-layout ui-search-layout--stack']//li//a[@class='ui-search-link']"));
        private IWebElement lblTitleProduct => _driver.FindElement(By.XPath("//div[@class='ui-pdp-container ui-pdp-container--pdp']//h1"));
        #endregion


        public void Search(string vText)
        {
            searchElement.Clear();
            searchElement.SendKeys(vText);
            submitButton.Click();
        }


        public int CantProduct()
        {
            string iCant = "";
            
            Match m = Regex.Match(lblCant.Text.Replace(".", ""), "(\\d+)");
            string num = string.Empty;

            if (m.Success)
            {
                iCant = m.Value;
            }
            return int.Parse(iCant);
        }
        
    }
}
