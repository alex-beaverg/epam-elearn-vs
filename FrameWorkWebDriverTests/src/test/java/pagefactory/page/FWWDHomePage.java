package pagefactory.page;

import org.openqa.selenium.WebDriver;
import org.openqa.selenium.WebElement;
import org.openqa.selenium.support.FindBy;
import org.openqa.selenium.support.PageFactory;
import waits.ExplicitCondition;
import org.apache.logging.log4j.Logger;
import org.apache.logging.log4j.LogManager;

public class FWWDHomePage extends AbstractPage {

    private static final String HOMEPAGE_URL = "https://cloud.google.com/";
    private final Logger logger = LogManager.getRootLogger();

    @FindBy(xpath = "//input[@name = 'q']")
    private WebElement searchInput;

    @FindBy(xpath = "//a[@class = 'gs-title' and contains(., 'Google Cloud Pricing Calculator')]")
    private WebElement resultOfSearch;

    public FWWDHomePage(WebDriver driver) {
        super(driver);
        PageFactory.initElements(driver, this);
    }

    @Override
    public FWWDHomePage openPage() {
        driver.get(HOMEPAGE_URL);
        new ExplicitCondition(driver, searchInput);
        logger.info("Opened home page with URL: [" + HOMEPAGE_URL + "]");
        return this;
    }

    public FWWDHomePage searchForTerms(String term) {
        searchInput.sendKeys(term);
        searchInput.submit();
        logger.info("Found term on home page with text: [" + term + "]");
        return new FWWDHomePage(driver);
    }

    public FWWDCalculatorPage searchFromResults() {
        new ExplicitCondition(driver, resultOfSearch);
        resultOfSearch.click();
        return new FWWDCalculatorPage(driver);
    }
}
