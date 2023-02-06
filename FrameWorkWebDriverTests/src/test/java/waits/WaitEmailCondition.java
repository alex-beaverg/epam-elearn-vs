package waits;

import org.openqa.selenium.By;
import org.openqa.selenium.TimeoutException;
import org.openqa.selenium.WebDriver;
import org.openqa.selenium.WebElement;
import org.openqa.selenium.support.ui.ExpectedConditions;
import org.openqa.selenium.support.ui.WebDriverWait;

import java.time.Duration;

public class WaitEmailCondition {
    public WaitEmailCondition(WebDriver driver, WebElement element, By by) {
        String sendEmailPageWindowHandle = driver.getWindowHandle();
        while (true) {
            try {
                driver.switchTo().frame("ifmail");
                new WebDriverWait(driver, Duration.ofSeconds(3))
                        .until(ExpectedConditions.presenceOfElementLocated(by));
                break;
            }
            catch(TimeoutException e) {
                driver.switchTo().window(sendEmailPageWindowHandle);
                element.click();
            }
        }
    }
}
