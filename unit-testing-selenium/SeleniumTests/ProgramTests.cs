using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;
using System;

namespace Selenium.Tests
{
    [TestClass()]
    public class ProgramTests
    {
        [TestMethod()]        
        [DataRow("alexmailfrom@rambler.ru", "SimplePass0000", true)]
        [DataRow("blablabla@mail.ru", "blablabla", false)]        
        [DataRow("", "", false)]
        public void MainTest(string user, string pass, Boolean result)
        {            
            FirstLoginPage FirstLoginPage = new FirstLoginPage(new ChromeDriver());
            FirstLoginPage.loginAs(user, pass);            
            if (user != "alexmailfrom@rambler.ru" || pass != "SimplePass0000")
            {
                Assert.AreEqual(result, false);
            }
            else
            {
                Assert.AreEqual(result, true);
            }            
        }

    }
}