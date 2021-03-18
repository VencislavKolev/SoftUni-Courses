import javax.persistence.EntityManager;
import javax.persistence.EntityManagerFactory;
import javax.persistence.Persistence;

public class App {
    public static final String GRINGOTTS_PU = "gringotts";
    public static final String SALES_PU = "sales";
    public static final String UNIVERSITY_SYSTEM_PU = "university_system";
    public static final String HOSPITAL_PU = "hospital";
    public static final String BILL_PAYMENT_SYSTEM_PU = "bill_payment";

    public static void main(String[] args) {
        EntityManagerFactory entityManagerFactory =
                Persistence.createEntityManagerFactory(BILL_PAYMENT_SYSTEM_PU);
        EntityManager entityManager = entityManagerFactory.createEntityManager();

        Engine engine = new Engine(entityManager);
        engine.run();
    }
}
