package pagefactory.page;

import org.openqa.selenium.JavascriptExecutor;
import org.openqa.selenium.WebDriver;
import org.openqa.selenium.WebElement;
import org.openqa.selenium.support.FindBy;
import org.openqa.selenium.support.PageFactory;
import org.openqa.selenium.support.ui.WebDriverWait;
import waits.CustomConditions;

import java.time.Duration;


public class PasteBinHomePagePF {
    private static final String HOMEPAGE_URL = "https://pastebin.com/";
    private WebDriver driver;

    @FindBy(id = "postform-text")
    private WebElement pasteBinCodeField;

    @FindBy(id = "postform-name")
    private WebElement pasteBinNameField;

    @FindBy(xpath = "//option[@data-language = 'bash']")
    private WebElement pasteBinFormatSelectValue;

    @FindBy(xpath = "//option[@value = '10M']")
    private WebElement pasteBinExpirationSelectValue;

    @FindBy(xpath ="//button[text() = 'Create New Paste']")
    private WebElement pasteBinCreateButton;

    @FindBy(xpath = "//title")
    private WebElement titleOfPage;
    @FindBy(xpath = "//ol[@class = \"bash\"]")
    private WebElement codeOfPage;
    @FindBy(xpath = "//a[@href = \"/archive/bash\" and contains(., \"Bash\")]")
    private WebElement bashInPage;

    public PasteBinHomePagePF(WebDriver driver) {
        this.driver = driver;
        PageFactory.initElements(driver, this);
    }

    public PasteBinHomePagePF openPage() {
        driver.get(HOMEPAGE_URL);
        new WebDriverWait(driver, Duration.ofSeconds(10))
                .until(CustomConditions.jQueryAJAXsComplited());
        ((JavascriptExecutor)driver).executeScript("return document.getElementById('postform-expiration')" +
                ".style.visibility = 'visible'");
        ((JavascriptExecutor)driver).executeScript("return document.getElementById('postform-format')" +
                ".style.visibility = 'visible'");
        return this;
    }

    public PasteBinHomePagePF createNewPaste(String code, String name) {
        pasteBinCodeField.sendKeys(code);
        pasteBinNameField.sendKeys(name);
        pasteBinExpirationSelectValue.click();
        pasteBinFormatSelectValue.click();
        pasteBinCreateButton.click();
        return new PasteBinHomePagePF(driver);
    }

    public Boolean checkElements(String title, String code) {

        System.out.println(codeOfPage.getAttribute("innerText" ));
        System.out.println(code);

        if (titleOfPage.getAttribute("innerText").startsWith(title)
        && codeOfPage.getAttribute("innerText" ).contains(code.substring(0, 20))
        && bashInPage.getAttribute("innerText").equals("Bash")) return true;
        return false;
    }
}
