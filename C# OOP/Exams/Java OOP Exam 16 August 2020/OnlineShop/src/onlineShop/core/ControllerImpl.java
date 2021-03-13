package onlineShop.core;

import onlineShop.core.interfaces.Controller;
import onlineShop.models.products.components.*;
import onlineShop.models.products.computers.Computer;
import onlineShop.models.products.computers.DesktopComputer;
import onlineShop.models.products.computers.Laptop;
import onlineShop.models.products.peripherals.*;

import java.util.Comparator;
import java.util.HashMap;
import java.util.IllegalFormatCodePointException;
import java.util.Map;

import static onlineShop.common.constants.ExceptionMessages.*;
import static onlineShop.common.constants.OutputMessages.*;

public class ControllerImpl implements Controller {

    private final Map<Integer, Computer> computers;
    private final Map<Integer, Peripheral> peripherals;
    private final Map<Integer, Component> components;

    public ControllerImpl() {
        this.computers = new HashMap<>();
        this.peripherals = new HashMap<>();
        this.components = new HashMap<>();
    }

    @Override
    public String addComputer(String computerType, int id, String manufacturer, String model, double price) {
        if (this.computers.containsKey(id)) {
            throw new IllegalArgumentException(EXISTING_COMPUTER_ID);
        }

        Computer computer;
        switch (computerType) {
            case "DesktopComputer":
                computer = new DesktopComputer(id, manufacturer, model, price);
                break;
            case "Laptop":
                computer = new Laptop(id, manufacturer, model, price);
                break;
            default:
                throw new IllegalArgumentException(INVALID_COMPUTER_TYPE);
        }

        this.computers.put(id, computer);
        return String.format(ADDED_COMPUTER, id);
    }

    @Override
    public String addPeripheral(int computerId, int id, String peripheralType, String manufacturer, String model, double price, double overallPerformance, String connectionType) {
        this.validateComputerExists(id);

        if (this.peripherals.containsKey(id)) {
            throw new IllegalArgumentException(EXISTING_PERIPHERAL_ID);
        }

        Peripheral peripheral = CreateValidPeripheral(id, peripheralType, manufacturer, model, price, overallPerformance, connectionType);
        this.peripherals.put(id, peripheral);

        Computer computer = this.computers.get(computerId);
        computer.addPeripheral(peripheral);

        return String.format(ADDED_PERIPHERAL,
                peripheralType, id, computerId);
    }

    @Override
    public String removePeripheral(String peripheralType, int computerId) {
        this.validateComputerExists(computerId);

        Computer computer = this.computers.get(computerId);
        Peripheral peripheral = computer.removePeripheral(peripheralType);

        this.peripherals.remove(peripheral.getId());

        return String.format(REMOVED_PERIPHERAL,
                peripheralType, peripheral.getId());

    }

    @Override
    public String addComponent(int computerId, int id, String componentType, String manufacturer, String model, double price, double overallPerformance, int generation) {
        this.validateComputerExists(computerId);

        if (this.components.containsKey(id)) {
            throw new IllegalArgumentException(EXISTING_COMPONENT_ID);
        }

        Component component = CreateComponent(id, componentType, manufacturer, model, price, overallPerformance, generation);
        this.components.put(id, component);

        Computer computer = this.computers.get(computerId);
        computer.addComponent(component);

        return String.format(ADDED_COMPONENT,
                componentType, id, computerId);
    }

    @Override
    public String removeComponent(String componentType, int computerId) {
        this.validateComputerExists(computerId);

        Computer computer = this.computers.get(computerId);
        Component component = computer.removeComponent(componentType);

        this.components.remove(component.getId());

        return String.format(REMOVED_COMPONENT,
                componentType, component.getId());
    }

    @Override
    public String buyComputer(int id) {
        this.validateComputerExists(id);

        Computer computer = this.computers.get(id);
        this.computers.remove(id);

        return computer.toString();
    }

    @Override
    public String BuyBestComputer(double budget) {

        Computer computer = this.computers.values().stream()
                .filter(x -> x.getPrice() <= budget)
                .sorted(Comparator.comparing(Computer::getOverallPerformance).reversed())
                .findFirst()
                .orElse(null);

        if (computer == null) {
            throw new IllegalArgumentException(String.format(CAN_NOT_BUY_COMPUTER, budget));
        }
        return computer.toString();
    }

    @Override
    public String getComputerData(int id) {
        this.validateComputerExists(id);

        Computer computer = this.computers.get(id);

        return computer.toString();
    }

    private static Peripheral CreateValidPeripheral(int id, String peripheralType, String manufacturer, String model, double price, double overallPerformance, String connectionType) {
        Peripheral peripheral;

        switch (peripheralType) {
            case "Headset":
                peripheral = new Headset(id, manufacturer, model, price, overallPerformance, connectionType);
                break;
            case "Keyboard":
                peripheral = new Keyboard(id, manufacturer, model, price, overallPerformance, connectionType);
                break;
            case "Monitor":
                peripheral = new Monitor(id, manufacturer, model, price, overallPerformance, connectionType);
                break;
            case "Mouse":
                peripheral = new Mouse(id, manufacturer, model, price, overallPerformance, connectionType);
                break;
            default:
                throw new IllegalArgumentException(INVALID_PERIPHERAL_TYPE);
        }

        return peripheral;
    }

    private static Component CreateComponent(int id, String componentType, String manufacturer, String model, double price, double overallPerformance, int generation) {
        Component component;
        switch (componentType) {
            case "CentralProcessingUnit":
                component = new CentralProcessingUnit(id, manufacturer, model, price, overallPerformance, generation);
                break;
            case "Motherboard":
                component = new Motherboard(id, manufacturer, model, price, overallPerformance, generation);
                break;
            case "PowerSupply":
                component = new PowerSupply(id, manufacturer, model, price, overallPerformance, generation);
                break;
            case "RandomAccessMemory":
                component = new RandomAccessMemory(id, manufacturer, model, price, overallPerformance, generation);
                break;
            case "SolidStateDrive":
                component = new SolidStateDrive(id, manufacturer, model, price, overallPerformance, generation);
                break;
            case "VideoCard":
                component = new VideoCard(id, manufacturer, model, price, overallPerformance, generation);
                break;
            default:
                throw new IllegalArgumentException(INVALID_COMPONENT_TYPE);
        }

        return component;
    }

    private void validateComputerExists(int id) {
        if (!this.computers.containsKey(id)) {
            throw new IllegalArgumentException(NOT_EXISTING_COMPUTER_ID);
        }
    }
}
