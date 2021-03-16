package springdata.codefirst.entities;

import javax.persistence.*;
import java.math.BigDecimal;

@Entity
@Table(name = "planes")
public class Plane {
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private Long id;
    private String model;
    @Column(name = "fuel_type")
    private String fuelType;
    private BigDecimal price;
    @Column(name = "passenger_capacity")
    private int passengerCapacity;
    @ManyToOne
    private Company company;

    public Plane() {
    }

    public Plane(String model, String fuelType, BigDecimal price, int passengerCapacity, Company company) {
        this.model = model;
        this.fuelType = fuelType;
        this.price = price;
        this.passengerCapacity = passengerCapacity;
        this.company = company;
    }

    public Plane(Long id, String model, String fuelType, BigDecimal price, int passengerCapacity, Company company) {
        this.id = id;
        this.model = model;
        this.fuelType = fuelType;
        this.price = price;
        this.passengerCapacity = passengerCapacity;
        this.company = company;
    }

    public Long getId() {
        return id;
    }

    public void setId(Long id) {
        this.id = id;
    }

    public String getFuelType() {
        return fuelType;
    }

    public void setFuelType(String fuelType) {
        this.fuelType = fuelType;
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

    public int getPassengerCapacity() {
        return passengerCapacity;
    }

    public void setPassengerCapacity(int passengerCapacity) {
        this.passengerCapacity = passengerCapacity;
    }

    @Override
    public String toString() {
        return "Plane{" +
                "id=" + id +
                ", fuelType='" + fuelType + '\'' +
                ", model='" + model + '\'' +
                ", price=" + price +
                ", passengerCapacity=" + passengerCapacity +
                '}';
    }
}
