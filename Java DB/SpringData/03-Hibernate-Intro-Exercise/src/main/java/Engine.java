import entities.Address;
import entities.Employee;
import entities.Town;

import javax.persistence.EntityManager;
import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.util.List;

public class Engine implements Runnable {
    private final EntityManager entityManager;
    private final BufferedReader reader;

    public Engine(EntityManager entityManager) {
        this.entityManager = entityManager;
        this.reader = new BufferedReader(new InputStreamReader(System.in));
    }

    @Override
    public void run() {
        //changeCasingEx2();

//        try {
//            containsEmployeeEx3();
//        } catch (IOException e) {
//            e.printStackTrace();
//        }

        //employeesWithSalaryOver50000Ex4();

        //employeesFromDepartmentEx5();

        addingNewAddressAndUpdatingEmployeeEx6();
    }

    private void addingNewAddressAndUpdatingEmployeeEx6() {
        Address address = createAddress("Vitoshka 15");

        Employee employee = entityManager.find(Employee.class, 291);

        entityManager.getTransaction().begin();
        employee.setAddress(address);
        entityManager.getTransaction().commit();
    }

    private Address createAddress(String addressText) {
        Address address = new Address();
        address.setText(addressText);

        entityManager.getTransaction().begin();
        entityManager.persist(address);
        entityManager.getTransaction().commit();

        return address;
    }

    private void employeesWithSalaryOver50000Ex4() {
//        List<Employee> employees = entityManager.createQuery("SELECT e FROM Employee AS e " +
//                "WHERE e.salary > 50000", Employee.class)
//                .getResultList();


        entityManager.createQuery("SELECT e FROM Employee AS e " +
                "WHERE e.salary > 50000", Employee.class)
                .getResultStream()
                .map(Employee::getFirstName)
                .forEach(System.out::println);

    }

    private void containsEmployeeEx3() throws IOException {
        System.out.println("Enter full name:");
        String fullName = reader.readLine();
        List<Employee> employees = entityManager.createQuery("SELECT e FROM Employee AS e " +
                "WHERE concat(e.firstName,' ', e.lastName) = :name ", Employee.class)
                .setParameter("name", fullName)
                .getResultList();

        System.out.println(employees.size() > 0 ? "YES" : "NO");
    }

    private void changeCasingEx2() {
        List<Town> towns = entityManager.createQuery("SELECT t FROM Town AS t " +
                "WHERE length(t.name) <= 5", Town.class)
                .getResultList();

        entityManager.getTransaction().begin();
        towns.forEach(entityManager::detach);
        for (Town town : towns) {
            town.setName(town.getName().toLowerCase());
        }
        towns.forEach(entityManager::merge);
        entityManager.getTransaction().commit();
    }
}
