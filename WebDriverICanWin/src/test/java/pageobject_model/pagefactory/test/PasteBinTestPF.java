package pageobject_model.pagefactory.test;

import org.openqa.selenium.By;
import org.openqa.selenium.WebDriver;
import org.openqa.selenium.chrome.ChromeDriver;
import org.testng.Assert;
import org.testng.annotations.AfterMethod;
import org.testng.annotations.BeforeMethod;
import org.testng.annotations.Test;
import pageobject_model.pagefactory.page.PasteBinHomePagePF;

public class PasteBinTestPF {

    private WebDriver driver;

    @BeforeMethod (alwaysRun = true)
    public void browseSetUp() {
        driver = new ChromeDriver();
        driver.manage().window().maximize();
    }

    @Test (description = "Just second test: I can win")
    public void commonCreatePasteBinOK() {
        new PasteBinHomePagePF(driver)
                .openPage()
                .createNewPaste("Hello from Webdriver", "helloweb");

        String result = driver.findElement(By.xpath("//div[@class = 'de1']")).getText();

        Assert.assertTrue (result.equals("Hello from Webdriver"), "New Paste wasn't created!!!");
    }

    @AfterMethod (alwaysRun = true)
    public void browserExit() {
        driver.quit();
        driver = null;
    }
}
