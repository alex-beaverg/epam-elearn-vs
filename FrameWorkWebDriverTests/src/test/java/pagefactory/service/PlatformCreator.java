package pagefactory.service;

import pagefactory.model.Platform;

public class PlatformCreator {
    public final static String TESTDATA_NUMBER_OF_INSTANCES = "testdata.platform.numberOfInstances";
    public final static String TESTDATA_USING_GPU = "testdata.platform.usingGpu";

    public static Platform withCredentialsFromProperty() {
        return new Platform(TestDataReader.getTestData(TESTDATA_NUMBER_OF_INSTANCES),
                TestDataReader.getTestData(TESTDATA_USING_GPU));
    }
}
