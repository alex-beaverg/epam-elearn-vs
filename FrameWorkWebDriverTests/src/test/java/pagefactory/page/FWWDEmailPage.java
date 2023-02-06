package pagefactory.page;

import org.openqa.selenium.By;
import org.openqa.selenium.WebDriver;
import org.openqa.selenium.WebElement;
import org.openqa.selenium.WindowType;
import org.openqa.selenium.support.FindBy;
import org.openqa.selenium.support.PageFactory;
import waits.ExplicitCondition;
import waits.WaitEmailCondition;
import org.apache.logging.log4j.Logger;
import org.apache.logging.log4j.LogManager;

public class FWWDEmailPage extends AbstractPage {

    private static final String HOMEPAGE_URL = "https://yopmail.com/ru/";
    String sendEmailPageWindowHandle;
    private final Logger logger = LogManager.getRootLogger();

    @FindBy(xpath = "//*[@id=\"listeliens\"]/a[1]")
    private WebElement generateEmailLink;

    @FindBy(xpath = "//*[@id=\"geny\"]")
    private WebElement generatedEmail;

    @FindBy(xpath = "//span[text() = \"Проверить почту\"]")
    private WebElement checkEmailButton;

    @FindBy(xpath = "//h3[contains (., \"USD\")]")
    private WebElement totalEstimateFromEmail;
    private By totalEstimateFromEmailBy = By.xpath("//h3[contains (., \"USD\")]");

    @FindBy(xpath = "//*[@id=\"refresh\"]")
    private WebElement refreshPageButton;

    public FWWDEmailPage(WebDriver driver) {
        super(driver);
        PageFactory.initElements(driver, this);
    }

    @Override
    public FWWDEmailPage openPage() {
        driver.switchTo().newWindow(WindowType.TAB);
        sendEmailPageWindowHandle = driver.getWindowHandle();
        driver.get(HOMEPAGE_URL);
        new ExplicitCondition(driver, generateEmailLink);
        logger.info("Opened email page with URL: [" + HOMEPAGE_URL + "]");
        return new FWWDEmailPage(driver);
    }

    public String generateEmail() {
        generateEmailLink.click();
        logger.info("Generated new email with address: [" + generatedEmail.getText() + "]");
        return generatedEmail.getText();
    }

    public String checkEmail() {
        driver.switchTo().window(sendEmailPageWindowHandle);
        checkEmailButton.click();
        new WaitEmailCondition(driver, refreshPageButton, totalEstimateFromEmailBy);
        return totalEstimateFromEmail.getText();
    }
}
