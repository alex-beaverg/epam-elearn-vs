package pagefactory.page;

import org.openqa.selenium.By;
import org.openqa.selenium.WebDriver;
import org.openqa.selenium.WebElement;
import org.openqa.selenium.WindowType;
import org.openqa.selenium.support.FindBy;
import org.openqa.selenium.support.PageFactory;
import waits.ExplicitCondition;
import waits.WaitEmailCondition;

public class HardCoreTaskEmailPage {
    private static final String HOMEPAGE_URL = "https://yopmail.com/ru/";
    private WebDriver driver;
    String sendEmailPageWindowHandle;

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

    public HardCoreTaskEmailPage(WebDriver driver) {
        this.driver = driver;
        PageFactory.initElements(driver, this);
    }

    public HardCoreTaskEmailPage openPage() {
        driver.switchTo().newWindow(WindowType.TAB);
        sendEmailPageWindowHandle = driver.getWindowHandle();
        driver.get(HOMEPAGE_URL);
        new ExplicitCondition(driver, generateEmailLink);
        return new HardCoreTaskEmailPage(driver);
    }

    public String generateEmail() {
        generateEmailLink.click();
        return generatedEmail.getText();
    }

    public String checkEmail() {
        driver.switchTo().window(sendEmailPageWindowHandle);
        checkEmailButton.click();
        new WaitEmailCondition(driver, refreshPageButton, totalEstimateFromEmailBy);
        return totalEstimateFromEmail.getText();
    }
}
