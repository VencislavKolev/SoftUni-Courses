package onlineShop.models.products.computers;

public class DesktopComputer extends BaseComputer{

    private static final int DEF_DESKTOP_PERFORMANCE = 15;
    public DesktopComputer(int id, String manufacturer, String model, double price) {
        super(id, manufacturer, model, price, DEF_DESKTOP_PERFORMANCE);
    }
}
