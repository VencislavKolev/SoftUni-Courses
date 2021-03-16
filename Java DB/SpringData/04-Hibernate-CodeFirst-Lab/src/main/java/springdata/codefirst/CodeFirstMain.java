package springdata.codefirst;

import springdata.codefirst.entities.*;

import javax.persistence.EntityManager;
import javax.persistence.EntityManagerFactory;
import javax.persistence.Persistence;
import java.math.BigDecimal;
import java.util.Set;

public class CodeFirstMain {
    public static void main(String[] args) {

        EntityManagerFactory emf = Persistence.createEntityManagerFactory("code_first");
        EntityManager em = emf.createEntityManager();

        em.getTransaction().begin();

        //-----------------OneToOne-----------------

        Car car1 = new Car("Mercedes S-Class", "Petrol", 150000, 5);
        em.persist(car1);

        PlateNumber car1PlateNumber = new PlateNumber("CB6363BK", car1);
        car1.setPlate(car1PlateNumber);

        em.persist(car1PlateNumber);


        //-----------------OneToMany-----------------

        Company company = new Company("VMWare-Skyline");

        Plane plane1 = new Plane("Airbus A380", "kerosene", new BigDecimal(1200000), 380, company);
        Plane plane2 = new Plane("BOEING 747", "kerosene", new BigDecimal(1000000), 220, company);
        Plane plane3 = new Plane("BOEING 737", "kerosene", new BigDecimal(1250000), 250, company);

        em.persist(plane1);
        em.persist(plane2);
        em.persist(plane3);

        company.getPlanes().add(plane1);
        company.getPlanes().add(plane2);
        company.getPlanes().add(plane3);

        em.persist(company);


        //-----------------ManyToMany-----------------

        Truck truck1 = new Truck("DAF", new BigDecimal(60000), 20);
        Truck truck2 = new Truck("Scania", new BigDecimal(70000), 15);
        Truck truck3 = new Truck("Iveco", new BigDecimal(65000), 18);
        em.persist(truck1);
        em.persist(truck2);
        em.persist(truck3);

        Driver driver1 = new Driver("First Driver", Set.of(truck1, truck2));
        truck1.getDrivers().add(driver1);
        truck2.getDrivers().add(driver1);

        em.persist(driver1);

        Driver driver2 = new Driver("Second Driver", Set.of(truck2, truck3));
        truck2.getDrivers().add(driver2);
        truck3.getDrivers().add(driver2);
        em.persist(driver2);

        em.getTransaction().commit();
    }
}
