package pagefactory.test;

import org.testng.Assert;
import org.testng.annotations.Test;
import pagefactory.model.Platform;
import pagefactory.page.FWWDCalculatorPage;
import pagefactory.page.FWWDEmailPage;
import pagefactory.page.FWWDHomePage;
import pagefactory.service.PlatformCreator;

public class FWWDMainTest extends CommonConditions {
    @Test (description = "Main test")
    public void commonSearchCloudCalcAndCheckEstimate() {

        String searchTerm = "Google Cloud Platform Pricing Calculator";
        Platform testPlatform = PlatformCreator.withCredentialsFromProperty();
        FWWDCalculatorPage calculatorPage = new FWWDHomePage(driver)
                .openPage()
                .searchForTerms(searchTerm)
                .searchFromResults()
                .addComputerToEstimate(testPlatform);

        FWWDEmailPage emailPage = new FWWDEmailPage(driver);
        String email = emailPage
                .openPage()
                .generateEmail();

        String total = calculatorPage.sendEstimateToEmail(email);
        String totalFromEmail = emailPage.checkEmail();

        Assert.assertTrue (total.equals(totalFromEmail), "Total estimates aren't equals!");
    }
}
