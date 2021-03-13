package onlineShop.models.products;

import onlineShop.common.constants.ExceptionMessages;

import static onlineShop.common.constants.OutputMessages.PRODUCT_TO_STRING;

public abstract class BaseProduct implements Product {
    private int id;
    private String manufacturer;
    private String model;
    private double price;
    private double overallPerformance;

    public BaseProduct(int id, String manufacturer, String model, double price, double overallPerformance) {
        this.setId(id);
        this.setManufacturer(manufacturer);
        this.setModel(model);
        this.setPrice(price);
        this.setOverallPerformance(overallPerformance);
    }

    @Override
    public int getId() {
        return id;
    }

    protected void setId(int id) {
        if (id <= 0) {
            throw new IllegalArgumentException(ExceptionMessages.INVALID_PRODUCT_ID);
        }
        this.id = id;
    }

    @Override
    public String getManufacturer() {
        return manufacturer;
    }

    protected void setManufacturer(String manufacturer) {
        if (manufacturer == null || manufacturer.trim().isEmpty()) {
            throw new IllegalArgumentException(ExceptionMessages.INVALID_MANUFACTURER);
        }
        this.manufacturer = manufacturer;
    }

    @Override
    public String getModel() {
        return model;
    }

    protected void setModel(String model) {
        if (model == null || manufacturer.trim().isEmpty()) {
            throw new IllegalArgumentException(ExceptionMessages.INVALID_MODEL);
        }
        this.model = model;
    }

    @Override
    public double getPrice() {
        return price;
    }

    protected void setPrice(double price) {
        if (price <= 0) {
            throw new IllegalArgumentException(ExceptionMessages.INVALID_PRICE);
        }
        this.price = price;
    }

    @Override
    public double getOverallPerformance() {
        return overallPerformance;
    }

    protected void setOverallPerformance(double overallPerformance) {
        if (overallPerformance <= 0) {
            throw new IllegalArgumentException(ExceptionMessages.INVALID_OVERALL_PERFORMANCE);
        }
        this.overallPerformance = overallPerformance;
    }

    @Override
    public String toString() {
        return String.format(PRODUCT_TO_STRING,
                this.getOverallPerformance(),
                this.getPrice(),
                this.getClass().getSimpleName(),
                this.getManufacturer(),
                this.getModel(),
                this.getId());
    }
}
