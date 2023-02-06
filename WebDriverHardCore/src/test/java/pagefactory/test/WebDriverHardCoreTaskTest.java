package pagefactory.test;

import org.openqa.selenium.WebDriver;
import org.openqa.selenium.chrome.ChromeDriver;
import org.testng.Assert;
import org.testng.annotations.AfterMethod;
import org.testng.annotations.BeforeMethod;
import org.testng.annotations.Test;
import pagefactory.page.HardCoreTaskCalculatorPage;
import pagefactory.page.HardCoreTaskEmailPage;
import pagefactory.page.HardCoreTaskHomePage;

public class WebDriverHardCoreTaskTest {

    private WebDriver driver;

    @BeforeMethod (alwaysRun = true)
    public void browseSetUp() {
        driver = new ChromeDriver();
        driver.manage().window().maximize();
    }

    @Test (description = "Just hardcore test")
    public void commonSearchCloudCalcAndCheckEstimate() {

        String searchTerm = "Google Cloud Platform Pricing Calculator";
        HardCoreTaskCalculatorPage calculatorPage = new HardCoreTaskHomePage(driver)
                .openPage()
                .searchForTerms(searchTerm)
                .searchFromResults(searchTerm)
                .addComputerToEstimate();

        HardCoreTaskEmailPage emailPage = new HardCoreTaskEmailPage(driver);
        String email = emailPage
                .openPage()
                .generateEmail();

        String total = calculatorPage.sendEstimateToEmail(email);
        String totalFromEmail = emailPage.checkEmail();

        Assert.assertTrue (total.equals(totalFromEmail), "Total estimates aren't equals!");
    }

    @AfterMethod (alwaysRun = true)
    public void browserExit() {

        driver.quit();
        driver = null;
    }
}
