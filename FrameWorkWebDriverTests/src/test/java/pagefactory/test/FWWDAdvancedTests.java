package pagefactory.test;

import org.testng.Assert;
import org.testng.annotations.Test;
import pagefactory.page.FWWDHomePage;

public class FWWDAdvancedTests extends CommonConditions {
    @Test (description = "Advanced test 1")
    public void commonSearchCloudCalc() {
        String searchTerm = "Google Cloud Platform Pricing Calculator";
        new FWWDHomePage(driver)
                .openPage()
                .searchForTerms(searchTerm)
                .searchFromResults();

        Assert.assertTrue (driver.getCurrentUrl()
                .equals("https://cloud.google.com/products/calculator"), "URLs aren't equals!");
    }

    @Test (description = "Advanced test 2")
    public void commonSearchCloudCalcWithAnotherRequest() {
        String searchTerm = "Google Cloud Pricing Calculator";
        new FWWDHomePage(driver)
                .openPage()
                .searchForTerms(searchTerm)
                .searchFromResults();

        Assert.assertTrue (driver.getCurrentUrl()
                .equals("https://cloud.google.com/products/calculator"), "URLs aren't equals!");
    }
}
