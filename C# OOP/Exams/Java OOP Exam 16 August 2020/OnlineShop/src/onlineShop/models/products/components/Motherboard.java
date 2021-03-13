package onlineShop.models.products.components;

public class Motherboard extends BaseComponent{
    private final static double MOTHERBOARD_MULTIPLIER = 1.25;
    public Motherboard(int id, String manufacturer, String model, double price, double overallPerformance, int generation) {
        super(id, manufacturer, model, price, overallPerformance * MOTHERBOARD_MULTIPLIER, generation);
    }
}
