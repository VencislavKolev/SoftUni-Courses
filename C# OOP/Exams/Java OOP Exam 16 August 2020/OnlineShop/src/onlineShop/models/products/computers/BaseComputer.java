package onlineShop.models.products.computers;

import onlineShop.models.products.BaseProduct;
import onlineShop.models.products.Product;
import onlineShop.models.products.components.Component;
import onlineShop.models.products.peripherals.Peripheral;

import java.util.ArrayList;
import java.util.Collections;
import java.util.List;

import static onlineShop.common.constants.ExceptionMessages.*;
import static onlineShop.common.constants.OutputMessages.COMPUTER_COMPONENTS_TO_STRING;
import static onlineShop.common.constants.OutputMessages.COMPUTER_PERIPHERALS_TO_STRING;

public abstract class BaseComputer extends BaseProduct implements Computer {
    private final List<Component> components;
    private final List<Peripheral> peripherals;

    public BaseComputer(int id, String manufacturer, String model, double price, double overallPerformance) {
        super(id, manufacturer, model, price, overallPerformance);
        this.components = new ArrayList<>();
        this.peripherals = new ArrayList<>();
    }

    @Override
    public List<Component> getComponents() {
        return Collections.unmodifiableList(this.components);
    }

    @Override
    public List<Peripheral> getPeripherals() {
        return Collections.unmodifiableList(this.peripherals);
    }

    @Override
    public void addComponent(Component component) {

        if (this.components.stream().anyMatch(x -> x.getClass() == component.getClass())) {
            throw new IllegalArgumentException(String.format(EXISTING_COMPONENT,
                    component.getClass().getSimpleName(),
                    this.getClass().getSimpleName(),
                    this.getId()));
        }

        this.components.add(component);
    }

    @Override
    public Component removeComponent(String componentType) {
        Component component = this.components.stream()
                .filter(x -> x.getClass().getSimpleName().equals(componentType))
                .findFirst()
                .orElse(null);

        if (component == null) {
            throw new IllegalArgumentException(String.format(NOT_EXISTING_COMPONENT,
                    componentType,
                    this.getClass().getSimpleName(),
                    this.getId()));
        }

        this.components.remove(component);
        return component;
    }

    @Override
    public void addPeripheral(Peripheral peripheral) {
        if (this.peripherals.stream().anyMatch(x -> x.getClass() == peripheral.getClass())) {
            throw new IllegalArgumentException(String.format(EXISTING_PERIPHERAL,
                    peripheral.getClass().getSimpleName(),
                    this.getClass().getSimpleName(),
                    this.getId()));
        }

        this.peripherals.add(peripheral);
    }

    @Override
    public Peripheral removePeripheral(String peripheralType) {
        Peripheral peripheral = this.peripherals.stream()
                .filter(x -> x.getClass().getSimpleName().equals(peripheralType))
                .findFirst()
                .orElse(null);

        if (peripheral == null) {
            throw new IllegalArgumentException(String.format(NOT_EXISTING_PERIPHERAL,
                    peripheralType,
                    this.getClass().getSimpleName(),
                    this.getId()));
        }

        this.peripherals.remove(peripheral);
        return peripheral;
    }

    @Override
    public String toString() {
        StringBuilder sb = new StringBuilder();
        sb.append(super.toString()).append(System.lineSeparator());

        sb.append(String.format(COMPUTER_COMPONENTS_TO_STRING, this.components.size()));
        sb.append(System.lineSeparator());
        for (Component component : components) {
            sb.append("  ")
                    .append(component.toString())
                    .append(System.lineSeparator());
        }

        sb.append(String.format(COMPUTER_PERIPHERALS_TO_STRING,
                this.peripherals.size(),
                this.peripherals.stream()
                        .mapToDouble(Peripheral::getOverallPerformance)
                        .average()
                        .orElse(0)));
        sb.append(System.lineSeparator());

        for (Peripheral peripheral : peripherals) {
            sb.append("  " + peripheral.toString())
                    .append(System.lineSeparator());
        }
        return sb.toString().trim();
    }

    @Override
    public double getOverallPerformance() {

        return this.components.isEmpty()
                ? super.getOverallPerformance()
                : super.getOverallPerformance() + (this.peripherals.stream()
                .mapToDouble(Product::getOverallPerformance)
                .average()
                .orElse(0));

    }

    @Override
    public double getPrice() {
        double computerPrice = super.getPrice();

        double componentsPrice = this.components.stream()
                .mapToDouble(Product::getPrice)
                .sum();

        double peripheralsPrice = this.peripherals.stream()
                .mapToDouble(Product::getPrice)
                .sum();

        return computerPrice + componentsPrice + peripheralsPrice;
    }
}
