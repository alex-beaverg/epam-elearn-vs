using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Linq;
using System.Threading;

// Webdriver

namespace Selenium
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Log in the first mail server
            ChromeDriver driver = new ChromeDriver();
            FirstLoginPage firstPage = new FirstLoginPage(driver);
            firstPage.loginAs("alexmailfrom@rambler.ru", "SimplePass0000");

            // Send mail from first mail to second mail
            SendMailFromFirstLoginPage mail = new SendMailFromFirstLoginPage(driver);
            mail.sendMail("fromramblerto@mail.ru", "Webdriver", "Test Message");

            // Log in the second mail server
            SecondLoginPage secondPage = new SecondLoginPage(driver);
            secondPage.loginAs("fromramblerto@mail.ru", "SimplePass0000");

            // Send returm mail from first server to second server
            SendReturnMail returnMail = new SendReturnMail(driver);
            returnMail.SendMail();

            // Return to first server and rename account name
            FirstLoginPage firstPageAgain = new FirstLoginPage(driver);            
            RenameAccount rename = new RenameAccount(driver);
            rename.rename();

            // Webserver exit            
            driver.Close();
            driver.Quit();
        }
    }
    // Class for log in the first mail server
    public class FirstLoginPage
    {
        // Fields with paths
        By firstUsernameLocator = By.Id("login");
        By firstPasswordLocator = By.Id("password");        

        private WebDriver driver;

        // Constructor
        public FirstLoginPage(WebDriver c_driver)
        {
            driver = c_driver;
            driver.Manage().Window.Maximize();
            driver.Url = "https://mail.rambler.ru";         
        }
        // Method for Username
        private FirstLoginPage typeUsername(String username)
        {            
            new Waiters(driver).waitForElementLocatedBySwitchToFrame(firstUsernameLocator, 0);
            driver.FindElement(firstUsernameLocator).SendKeys(username);
            return this;
        }
        // Method for Password
        private FirstLoginPage typePassword(String password)
        {
            driver.FindElement(firstPasswordLocator).SendKeys(password);
            return this;
        }
        // Method for Submit
        private void submitLogin()
        {
            driver.FindElement(firstPasswordLocator).Submit();
        }
        // Finish method to Log In
        public void loginAs(String username, String password)
        {
            String myWindowHandle = driver.CurrentWindowHandle;
            typeUsername(username);
            typePassword(password);
            submitLogin();
            driver.SwitchTo().Window(myWindowHandle);
        }
    }

    // Class for send mail from first server to second server
    public class SendMailFromFirstLoginPage
    {
        // Fields with paths
        By createNewMail = By.XPath("//button[@data-list-view='newletter']");
        By recieverPath = By.Id("receivers");
        By subjectPath = By.Id("subject");
        By messagePath = By.XPath("//*[@id='tinymce']/div[1]");
        By sendPath = By.XPath("//button[contains(@data-compose-button, 'top-send')]");
        By afterSend = By.XPath("//*[@class='ComposeProgress-closeIcon-i6']");
        By afterSendText = By.XPath("//div[text()='Письмо отправлено']");

        private WebDriver driver;

        // Constructor
        public SendMailFromFirstLoginPage(WebDriver c_driver)
        {
            driver = c_driver;
        }
        // Method for new window 'New Mail'
        private void writeMail()
        {
            new Waiters(driver).waitForElementLocatedBy(createNewMail);
            driver.FindElement(createNewMail).Click();
        }
        // Method for 'Reciever' in new mail
        private SendMailFromFirstLoginPage typeReciever(String reciever)
        {
            driver.FindElement(recieverPath).SendKeys(reciever);
            return this;
        }
        // Method for 'Subject' in new mail
        private SendMailFromFirstLoginPage typeSubject(String subject)
        {
            driver.FindElement(subjectPath).SendKeys(subject);
            return this;
        }
        // Method for 'Message' in new mail
        private SendMailFromFirstLoginPage typeMessage(String message)
        {
            String myWindowHandle = driver.CurrentWindowHandle;
            new Waiters(driver).waitForElementLocatedBySwitchToFrame(messagePath, 0);
            driver.FindElement(messagePath).SendKeys(message);
            driver.SwitchTo().Window(myWindowHandle);
            return this;
        }
        // Method for 'Send' new mail
        private void send()
        {            
            driver.FindElement(sendPath).Click();
            new Waiters(driver).waitCustomCondition(afterSendText);            
            driver.FindElement(afterSend).Click();
        }
        // Finish method for Send Mail
        public void sendMail(String reciever, String subject, String message)
        {
            writeMail();
            typeReciever(reciever);
            typeSubject(subject);            
            typeMessage(message);            
            send();            
        }
    }

    // Class for log in the second server
    public class SecondLoginPage
    {
        // Fields with pathes
        By maleFramePath = By.XPath("//button[@data-testid=\"enter-mail-primary\"]");
        By secondUsernameLocator = By.Name("username");
        By secondPasswordLocator = By.Name("password");        

        private WebDriver driver;

        // Constructor
        public SecondLoginPage(WebDriver c_driver)
        {
            driver = c_driver;
            driver.Manage().Window.Maximize();
            driver.Url = "https://mail.ru/";
        }
        // Method for Username
        private SecondLoginPage typeUsername(String username)
        {
            new Waiters(driver).waitForElementLocatedBy(maleFramePath);
            driver.FindElement(maleFramePath).Click();
            String myWindowHandle = driver.CurrentWindowHandle;
            // Find frame
            for (int i = 0; i < driver.FindElements(By.TagName("iframe")).Count; i++)
            {
                try
                {
                    driver.SwitchTo().Frame(i).FindElement(secondUsernameLocator).SendKeys(username);                    
                    break;
                }
                catch (NoSuchElementException)
                {                                       
                    driver.SwitchTo().Window(myWindowHandle);
                }                                
            }            
            return this;
        }        
        // Method for Password
        private SecondLoginPage typePassword(String password)
        {            
            new Waiters(driver).waitCustomCondition(secondPasswordLocator);              
            driver.FindElement(secondPasswordLocator).SendKeys(password);
            return this;
        }
        // Method for Submit
        private void submitLogin(By by)
        {
            driver.FindElement(by).Submit();
        }
        // Finish method for Log In
        public void loginAs(String username, String password)
        {
            String myWindowHandle = driver.CurrentWindowHandle;
            typeUsername(username);
            submitLogin(secondUsernameLocator);
            typePassword(password);
            submitLogin(secondPasswordLocator);
            driver.SwitchTo().Window(myWindowHandle);
        }
    }

    // Class for send return mail
    public class SendReturnMail
    {
        // Fields with pathes
        By checkNewMailPath = By
            .XPath("//*[@id=\"app-canvas\"]/div/div[1]/div[1]/div/div[2]/span/div[2]/div/div/div/div/div[1]/div/div/div/div[1]/div/div/a/div[4]/div/div[1]/span");
        By checkMessagePath = By
            .XPath("/html/body/div[5]/div/div[1]/div[1]/div/div[2]/span/div[2]/div/div/div/div/div/div/div[2]/div[1]/div[4]/div[2]/div/div/div/div/div/div/div/div/div/div/div");
        By returnMailPath = By
            .XPath("/html/body/div[5]/div/div[1]/div[1]/div/div[2]/span/div[2]/div/div/div/div/div/div/div[2]/div[1]/div[5]/div/div[1]/div[1]/div[1]/span/span[2]/div");
        By returnMassagePath = By.XPath("/html/body/div[1]/div/div[2]/div/div/div/div[2]/div[3]/div[5]/div/div/div[2]/div[1]/div[1]");
        By sendMailPath = By.XPath("/html/body/div[1]/div/div[2]/div/div/div/div[3]/div[1]/div[1]/div[1]/button/span[1]/span");
        By afterSend = By.XPath("//*[@class='ico ico_16-close ico_size_s']");

        private WebDriver driver;

        // Constructor
        public SendReturnMail(WebDriver c_driver)
        {
            driver = c_driver;
        }
        // Method for check New Mail with Author
        private Boolean checkNewMail()
        {
            new Waiters(driver).waitForElementLocatedBy(checkNewMailPath);
            String weight = driver.FindElement(checkNewMailPath).GetCssValue("font-weight");
            String author = driver.FindElement(checkNewMailPath).Text;
            if (Int32.Parse(weight) > 400 && author == "Alex B") return true;
            else return false;
        }
        // Method for check Message
        private Boolean checkMessage()
        {
            driver.FindElement(checkNewMailPath).Click();
            new Waiters(driver).waitForElementLocatedBy(checkMessagePath);
            if (driver.FindElement(checkMessagePath).Text == "Test Message") return true;
            else return false;
        }
        // Method for write New Message
        private void returnMessage()
        {
            new Waiters(driver).waitForElementLocatedBy(returnMailPath);
            driver.FindElement(returnMailPath).Click();
            new Waiters(driver).waitForElementLocatedBy(returnMassagePath);
            driver.FindElement(returnMassagePath).SendKeys("Back Message");
        }
        // Method for Send Mail
        private void send()
        {
            new Waiters(driver).waitForElementLocatedBy(sendMailPath);
            driver.FindElement(sendMailPath).Click();
        }
        // Finish method for Send Mail
        public void SendMail()
        {
            if (checkNewMail() && checkMessage())
            {                
                returnMessage();
                send();
                new Waiters(driver).waitForElementLocatedBy(afterSend);
                driver.FindElement(afterSend).Click();                
            }
        }
    }

    // Class for rename account name in the first mail server
    public class RenameAccount
    {
        // Fields with pathes
        By readMail = By.XPath("//div[@class='ListItem-sender-2L']/span");               
        By editAccountName = By.XPath("//*[@id=\"root\"]/div/div[2]/div/div/section[2]/div[2]/section[1]/div/span/button");
        By firstName = By.XPath("//*[@id=\"firstname\"]");
        By lastName = By.XPath("//*[@id=\"lastname\"]");
        By submitChanges = By.XPath("//*[@id=\"root\"]/div/div[2]/div/div/section[2]/div[2]/form/span[1]/button");

        private WebDriver driver;
        //private String myWindowHandle;

        // Constructor
        public RenameAccount(WebDriver c_driver)
        {
            driver = c_driver;
            //myWindowHandle = driver.CurrentWindowHandle;
        }
        // Method for read name from mail
        private String readName()
        {            
            new Waiters(driver).waitForElementLocatedBy(readMail);
            return driver.FindElement(readMail).Text;
        }
        // Finish method for rename account Name
        public void rename()
        {
            String newName = readName();
            driver.FindElement(readMail).Click();
            driver.Url = "https://id.rambler.ru/account/profile";            
            new Waiters(driver).waitForElementLocatedBy(editAccountName);
            driver.FindElement(editAccountName).Click();
            driver.FindElement(firstName).Clear();
            driver.FindElement(firstName).SendKeys(newName.Substring(0, 5));
            driver.FindElement(lastName).Clear();
            driver.FindElement(lastName).SendKeys(newName.Substring(5));
            driver.FindElement(submitChanges).Click();            
        }
    }

    // Class for explicity waiters
    public class Waiters
    {
        private WebDriver driver;
        // Constructor
        public Waiters(WebDriver c_driver)
        {
            driver = c_driver;
        }
        // Method for wait
        public void waitForElementLocatedBy (By by)
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(100)).Until(d => d.FindElement(by));
        }
        public void waitForElementLocatedBySwitchToFrame(By by, int number)
        {
            new WebDriverWait(driver.SwitchTo().Frame(number), TimeSpan.FromSeconds(100)).Until(d => d.FindElement(by));
        }
        public void waitForElementLocatedBySwitchToWindow(By by, String handle)
        {
            new WebDriverWait(driver.SwitchTo().Window(handle), TimeSpan.FromSeconds(100)).Until(d => d.FindElement(by));
        }
        public void waitCustomCondition(By by)
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(100))
                .Until<IWebElement>((d) =>
                {
                    IWebElement element = d.FindElement(by);
                    if (element.Displayed &&
                        element.Enabled)
                    {
                        return element;
                    }

                    return null;
                });
        }
    }
}
