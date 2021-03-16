package springdata.codefirst.entities;

import javax.persistence.*;
import java.math.BigDecimal;
import java.util.HashSet;
import java.util.Objects;
import java.util.Set;

@Entity
@Table(name = "trucks")
public class Truck {
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private Long id;
    private String model;
    private BigDecimal price;
    @Column(name = "load_capacity")
    private int loadCapacity;
    @ManyToMany(mappedBy = "trucks")
    private Set<Driver> drivers = new HashSet<>();

    public Truck() {
    }

    public Truck(String model, BigDecimal price, int loadCapacity) {
        this.model = model;
        this.price = price;
        this.loadCapacity = loadCapacity;
    }

    public Truck(Long id, String model, BigDecimal price, int loadCapacity) {
        this.id = id;
        this.model = model;
        this.price = price;
        this.loadCapacity = loadCapacity;
    }

    public Long getId() {
        return id;
    }

    public void setId(Long id) {
        this.id = id;
    }

    public String getModel() {
        return model;
    }

    public void setModel(String model) {
        this.model = model;
    }

    public BigDecimal getPrice() {
        return price;
    }

    public void setPrice(BigDecimal price) {
        this.price = price;
    }

    public int getLoadCapacity() {
        return loadCapacity;
    }

    public void setLoadCapacity(int loadCapacity) {
        this.loadCapacity = loadCapacity;
    }

    public Set<Driver> getDrivers() {
        return drivers;
    }

    public void setDrivers(Set<Driver> drivers) {
        this.drivers = drivers;
    }

    @Override
    public boolean equals(Object o) {
        if (this == o) {
            return true;
        }
        if (o == null || getClass() != o.getClass()) {
            return false;
        }
        Truck truck = (Truck) o;
        return Objects.equals(id, truck.id);
    }

    @Override
    public int hashCode() {
        return Objects.hash(id);
    }

    @Override
    public String toString() {
        return "Truck{" +
                "id=" + id +
                ", model='" + model + '\'' +
                ", price=" + price +
                ", loadCapacity=" + loadCapacity +
                '}';
    }
}
