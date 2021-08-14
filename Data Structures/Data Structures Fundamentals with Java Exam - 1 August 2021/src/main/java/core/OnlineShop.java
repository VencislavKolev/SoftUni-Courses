package core;

import model.Order;
import shared.Shop;

import java.util.*;

public class OnlineShop implements Shop {

    private final List<Order> orders;

    public OnlineShop() {
        this.orders = new ArrayList<>();
    }

    @Override
    public void add(Order order) {
        this.orders.add(order);
    }

    @Override
    public Order get(int index) {
        this.validateIndex(index);
        return this.orders.get(index);
    }

    @Override
    public int indexOf(Order order) {
        return this.orders.indexOf(order);
    }

    @Override
    public Boolean contains(Order order) {
        return this.orders.contains(order);
    }

    @Override
    public Boolean remove(Order order) {
        return this.orders.remove(order);
    }

    @Override
    public Boolean remove(int id) {
        for (int i = 0; i < this.orders.size(); i++) {
            if (this.orders.get(i).getId() == id) {
                this.orders.remove(i);
                return true;
            }
        }
        return false;
    }

    @Override
    public void set(int index, Order order) {
        this.validateIndex(index);
        this.orders.set(index, order);
    }

    @Override
    public void set(Order oldOrder, Order newOrder) {
        var oldOrderIndex = this.indexOf(oldOrder);
        this.validateIndex(oldOrderIndex);
        this.orders.set(oldOrderIndex, newOrder);
    }

    @Override
    public void clear() {
        this.orders.clear();
    }

    @Override
    public Order[] toArray() {
        return this.orders.toArray(new Order[0]);
    }

    @Override
    public void swap(Order first, Order second) {
        var firstIndex = this.indexOf(first);
        var secondIndex = this.indexOf(second);

        if (firstIndex == -1 || secondIndex == -1) {
            throw new IllegalArgumentException();
        }
//        Collections.swap(this.orders, firstIndex, secondIndex);
        var temp = this.orders.get(firstIndex);
        this.orders.set(firstIndex, second);
        this.orders.set(secondIndex, temp);

    }

    @Override
    public List<Order> toList() {
        return new ArrayList<>(this.orders);
    }

    @Override
    public void reverse() {
        Collections.reverse(this.orders);
    }

    @Override
    public void insert(int index, Order order) {
        this.validateIndex(index);
        this.orders.add(index, order);
    }

    @Override
    public Boolean isEmpty() {
        return this.orders.isEmpty();
    }

    @Override
    public int size() {
        return this.orders.size();
    }

    private void validateIndex(int index) {
        if (index < 0 || index >= this.size())
            throw new IndexOutOfBoundsException();
    }
}
