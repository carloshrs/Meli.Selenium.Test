using System;
using Meli.Selenium.Test.Security;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace meli.selenium.test
{
    [TestClass]
    public class MeliSearchTest
    {
        [TestMethod]
        public void SearchZapatillas()
        {
            //Arrange
            string vTextoBusquedaEj1 = "Zapatillas";
            ChromeDriver driver = new ChromeDriver();
            
            //Act
            driver.Url = "https://www.mercadolibre.com.ar/";
            driver.Manage().Window.Maximize();

            MeliMainPage oMeliPage = new MeliMainPage(driver);
            oMeliPage.Search(vTextoBusquedaEj1);
            int vCantidad = oMeliPage.CantProduct();

            driver.Close();

            //Assert
            Assert.IsTrue(vCantidad > 0, "Es mayor a 0.");

        }

        [TestMethod]
        public void SearchFirstTablet()
        {
            //Arrange
            string vTextoBusqueda = "Tablet";
            ChromeDriver driver = new ChromeDriver();

            //Act
            driver.Url = "https://www.mercadolibre.com.ar/";
            driver.Manage().Window.Maximize();

            MeliMainPage oMeliMainPage = new MeliMainPage(driver);
            MeliProductDetailPage oMeliProductDetailPage = new MeliProductDetailPage(driver);

            oMeliMainPage.Search(vTextoBusqueda);
            oMeliProductDetailPage.OpenFirstProduct(0);
            bool vResult = oMeliProductDetailPage.FindTextTitle(vTextoBusqueda);
            string vEstado = (vResult) ? "si" : "no";

            driver.Close();

            //Assert
            Assert.IsTrue(vResult, "El titulo "+ vEstado +" contiene la palabra " + vTextoBusqueda + ".");

        }
        

        [TestMethod]
        public void SearchCategory()
        {
            //Arrange
            string vTextoBusquedaEj1 = "Supermercado";
            ChromeDriver driver = new ChromeDriver();

            //Act
            driver.Url = "https://www.mercadolibre.com.ar/";
            driver.Manage().Window.Maximize();

            MeliMenuCategoryPage oMeliMenuCategoryPage = new MeliMenuCategoryPage(driver);
            oMeliMenuCategoryPage.OpenMenuCateogory(vTextoBusquedaEj1);

            driver.Close();

            //Assert
            //Assert.IsTrue(vCantidad > 0, "Es mayor a 0.");

        }

        [TestMethod]
        public void LoginMeli()
        {
            //Arrange
            string vUser = "carloshrs@gmail.com";
            string vPass = "YwA0AHIAbAAwAHMAaAByAHMA";
            ChromeDriver driver = new ChromeDriver();


            //Act
            driver.Url = "https://www.mercadolibre.com.ar/";
            driver.Manage().Window.Maximize();

            MeliLoginPage oMeliLoginPage = new MeliLoginPage(driver);
            oMeliLoginPage.OpenLinkLogin();
            oMeliLoginPage.LoginAction(vUser, Security.Decrypt(vPass));

            driver.Close();

            //Assert
        }
    }
}
