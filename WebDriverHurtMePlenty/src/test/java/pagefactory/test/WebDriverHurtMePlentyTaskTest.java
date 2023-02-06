package pagefactory.test;

import org.openqa.selenium.WebDriver;
import org.openqa.selenium.chrome.ChromeDriver;
import org.testng.Assert;
import org.testng.annotations.AfterMethod;
import org.testng.annotations.BeforeMethod;
import org.testng.annotations.Test;
import pagefactory.page.HurtMePlentyTaskCalculatorPage;
import pagefactory.page.HurtMePlentyTaskHomePage;

public class WebDriverHurtMePlentyTaskTest {

    private WebDriver driver;

    @BeforeMethod (alwaysRun = true)
    public void browseSetUp() {
        driver = new ChromeDriver();
        driver.manage().window().maximize();
    }

    @Test (description = "Just Hurt Me Plenty test")
    public void commonCheckEstimate() {

        String searchTerm = "Google Cloud Platform Pricing Calculator";
        Boolean checkEstimate = new HurtMePlentyTaskHomePage(driver)
                .openPage()
                .searchForTerms(searchTerm)
                .searchFromResults(searchTerm)
                .addComputerToEstimate()
                .checkData("Provisioning model: Regular",
                        "Instance type: n1-standard-8",
                        "Region: Frankfurt",
                        "Local SSD: 2x375 GiB",
                        "Commitment term: 1 Year",
                        "4,024.56");

        Assert.assertTrue (checkEstimate, "Total estimate isn't equals!");
    }

    @AfterMethod (alwaysRun = true)
    public void browserExit() {
        driver.quit();
        driver = null;
    }
}
