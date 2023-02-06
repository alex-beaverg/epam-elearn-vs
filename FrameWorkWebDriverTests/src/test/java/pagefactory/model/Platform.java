package pagefactory.model;

import java.util.Objects;

public class Platform {
    private String numberOfInstances;
    private String usingGpu;

    public Platform (String numberOfInstances, String usingGpu) {
        this.numberOfInstances = numberOfInstances;
        this.usingGpu = usingGpu;
    }

    public String getNumberOfInstances() {
        return numberOfInstances;
    }

    public void setNumberOfInstances(String numberOfInstances) {
        this.numberOfInstances = numberOfInstances;
    }

    public String getUsingGpu() {
        return usingGpu;
    }

    public void setUsingGpu(String usingGpu) {
        this.usingGpu = usingGpu;
    }

    @Override
    public String toString() {
        return "Platform{" +
                "numberOfInstances=" + numberOfInstances +
                ", usingGpu=" + usingGpu +
                "}";
    }

    @Override
    public boolean equals(Object o) {
        if (this == o) return true;
        if (!(o instanceof Platform)) return false;
        Platform platform = (Platform) o;
        return Objects.equals(getNumberOfInstances(),platform.getNumberOfInstances()) &&
                Objects.equals(getUsingGpu(),platform.getUsingGpu());

    }

    @Override
    public int hashCode() {
        return Objects.hash(getNumberOfInstances(), getUsingGpu());
    }
}
