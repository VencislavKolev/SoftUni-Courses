package onlineShop.models.products.components;

public class VideoCard extends BaseComponent {
    private final static double VIDEOCARD_MULTIPLIER = 1.15;

    public VideoCard(int id, String manufacturer, String model, double price, double overallPerformance, int generation) {
        super(id, manufacturer, model, price, overallPerformance * VIDEOCARD_MULTIPLIER, generation);
    }
}
