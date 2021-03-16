package springdata.codefirst;

import springdata.codefirst.entities.Car;
import springdata.codefirst.entities.PlateNumber;

import javax.persistence.EntityManager;
import javax.persistence.EntityManagerFactory;
import javax.persistence.Persistence;

public class CodeFirstMain {
    public static void main(String[] args) {
        EntityManagerFactory emf = Persistence.createEntityManagerFactory("code_first");
        EntityManager em = emf.createEntityManager();

        em.getTransaction().begin();

        Car car1 = new Car("Mercedes S-Class", "Petrol", 150000, 5);
        em.persist(car1);
        PlateNumber car1PlateNumber = new PlateNumber("CB6363BK", car1);
        car1.setPlate(car1PlateNumber);
        em.persist(car1PlateNumber);

        em.getTransaction().commit();
    }
}
