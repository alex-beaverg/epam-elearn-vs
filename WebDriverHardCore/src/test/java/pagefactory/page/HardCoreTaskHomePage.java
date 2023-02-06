package pagefactory.page;

import org.openqa.selenium.WebDriver;
import org.openqa.selenium.WebElement;
import org.openqa.selenium.support.FindBy;
import org.openqa.selenium.support.PageFactory;
import waits.ExplicitCondition;

public class HardCoreTaskHomePage {
    private static final String HOMEPAGE_URL = "https://cloud.google.com/";
    private WebDriver driver;

    @FindBy(xpath = "//input[@name = 'q']")
    private WebElement searchInput;

    @FindBy(xpath = "//a[@class = 'gs-title' and contains(., 'Google Cloud Platform Pricing Calculator')]")
    private WebElement resultOfSearch;

    public HardCoreTaskHomePage(WebDriver driver) {
        this.driver = driver;
        PageFactory.initElements(driver, this);
    }

    public HardCoreTaskHomePage openPage() {
        driver.get(HOMEPAGE_URL);
        new ExplicitCondition(driver, searchInput);
        return this;
    }

    public HardCoreTaskHomePage searchForTerms(String term) {
        searchInput.sendKeys(term);
        searchInput.submit();
        return new HardCoreTaskHomePage(driver);
    }

    public HardCoreTaskCalculatorPage searchFromResults(String term) {
        new ExplicitCondition(driver, resultOfSearch);
        resultOfSearch.click();
        return new HardCoreTaskCalculatorPage(driver);
    }
}
