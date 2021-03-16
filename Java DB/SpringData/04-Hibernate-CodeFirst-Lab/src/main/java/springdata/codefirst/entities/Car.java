package springdata.codefirst.entities;

import javax.persistence.*;

@Entity
@Table(name = "cars")
public class Car {
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private Long id;
    private String model;
    @Column(name = "fuel_type")
    private String fuelType;
    private double price;
    private int seats;
    @OneToOne(mappedBy = "car")
    private PlateNumber plate;

    public Car() {
    }

    public Car(String model, String fuelType, double price, int seats) {
        this.fuelType = fuelType;
        this.model = model;
        this.price = price;
        this.seats = seats;
    }

    public Car(Long id, String model, String fuelType, double price, int seats) {
        this.id = id;
        this.fuelType = fuelType;
        this.model = model;
        this.price = price;
        this.seats = seats;
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

    public double getPrice() {
        return price;
    }

    public void setPrice(double price) {
        this.price = price;
    }

    public int getSeats() {
        return seats;
    }

    public void setSeats(int seats) {
        this.seats = seats;
    }

    public PlateNumber getPlate() {
        return plate;
    }

    public void setPlate(PlateNumber plate) {
        this.plate = plate;
    }

    @Override
    public String toString() {
        return "Car{" +
                "id=" + id +
                ", fuelType='" + fuelType + '\'' +
                ", model='" + model + '\'' +
                ", price=" + price +
                ", seats=" + seats +
                ", plate=" + plate +
                '}';
    }
}
