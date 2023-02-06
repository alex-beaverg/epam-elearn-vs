package pagefactory.test;

import org.openqa.selenium.WebDriver;
import org.openqa.selenium.chrome.ChromeDriver;
import org.testng.Assert;
import org.testng.annotations.AfterMethod;
import org.testng.annotations.BeforeMethod;
import org.testng.annotations.Test;
import pagefactory.page.PasteBinHomePagePF;

public class PasteBinTestPF {

    private WebDriver driver;

    @BeforeMethod (alwaysRun = true)
    public void browseSetUp() {
        driver = new ChromeDriver();
        driver.manage().window().maximize();
    }

    @Test (description = "Just second test: Bring It On")
    public void commonCreatePasteBinOK() {
        String newPasteCode = "git config --global user.name  \"New Sheriff in Town\"\n" +
                "git reset $(git commit-tree HEAD^{tree} -m \"Legacy code\")\n" +
                "git push origin master --force";
        String newPasteTitle = "how to gain dominance among developers";

        Boolean trueOrFalse = new PasteBinHomePagePF(driver)
                .openPage()
                .createNewPaste(newPasteCode, newPasteTitle)
                .checkElements(newPasteTitle, newPasteCode);

        Assert.assertTrue (trueOrFalse, "New Paste is not equals data!");
    }

    @AfterMethod (alwaysRun = true)
    public void browserExit() {
        //driver.quit();
        //driver = null;
    }
}
