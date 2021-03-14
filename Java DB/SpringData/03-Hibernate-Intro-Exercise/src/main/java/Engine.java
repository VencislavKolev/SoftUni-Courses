import entities.*;

import javax.persistence.EntityManager;
import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.math.BigDecimal;
import java.util.Comparator;
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
        //Exercise 2
        //changeCasingEx2();

        //Exercise 3
//        try {
//            containsEmployeeEx3();
//        } catch (IOException e) {
//            e.printStackTrace();
//        }

        //Exercise 4
        //employeesWithSalaryOver50000Ex4();

        //Exercise 5
        //employeesFromDepartmentEx5();

        //Exercise 6
        //addingNewAddressAndUpdatingEmployeeEx6();

        //Exercise 7
        //addressesWithEmployeeCountEx7();

        //Exercise 8
//        try {
//            getEmployeeWithProject();
//        } catch (IOException e) {
//            e.printStackTrace();
//        }

        //Exercise 9
        //findLatest10Projects();

        //Exercise 10
        //increaseSalaries();

        //Exercise 11
//        try {
//            findEmployeesByFirstName();
//        } catch (IOException e) {
//            e.printStackTrace();
//        }

        //Exercise 12
        //maxSalaryForDepartments();

        //Exercise 13
        try {
            removeTowns();
        } catch (IOException e) {
            e.printStackTrace();
        }
    }

    private void removeTowns() throws IOException {
        System.out.println("Enter town name:");
        String townName = reader.readLine();

        entityManager.getTransaction().begin();

        Town toDelete = entityManager.createQuery("SELECT t FROM Town AS t " +
                "WHERE t.name = :name", Town.class)
                .setParameter("name", townName)
                .getSingleResult();

        List<Address> addressesToDelete = entityManager.createQuery("SELECT a FROM Address AS a " +
                "WHERE a.town.id = :id", Address.class)
                .setParameter("id", toDelete.getId())
                .getResultList();

        addressesToDelete
                .forEach(a -> a.getEmployees()
                        .forEach(emp -> emp.setAddress(null)));

        addressesToDelete.forEach(entityManager::remove);

        entityManager.remove(toDelete);

        int deletedAddresses = addressesToDelete.size();
        System.out.printf("%d address%s in %s deleted",
                deletedAddresses,
                deletedAddresses == 1 ? "" : "es",
                townName);

        entityManager.getTransaction().commit();

    }

    private void maxSalaryForDepartments() {
        final BigDecimal lower = BigDecimal.valueOf(30000);
        final BigDecimal upper = BigDecimal.valueOf(70000);

        List<Object[]> filteredDepartments = entityManager
                .createQuery("SELECT d.name, MAX(e.salary) " +
                                "FROM Employee AS e " +
                                "JOIN Department AS d ON e.department.id = d.id " +
                                "GROUP BY d.name " +
                                "HAVING MAX(e.salary) NOT BETWEEN :low AND :up",
                        Object[].class)
                .setParameter("low", lower)
                .setParameter("up", upper)
                .getResultList();

        filteredDepartments
                .forEach(x -> System.out.println(x[0] + " " + x[1]));

    }

    private void findEmployeesByFirstName() throws IOException {
        System.out.println("Enter first name pattern:");
        String name = reader.readLine();

        List<Employee> employees = entityManager
                .createQuery("SELECT e FROM Employee AS e " +
                        "WHERE e.firstName LIKE CONCAT(:pattern,'%')", Employee.class)
                .setParameter("pattern", name)
                .getResultList();

        employees.forEach(employee -> System.out.printf("%s %s - %s - ($%.2f)%n",
                employee.getFirstName(),
                employee.getLastName(),
                employee.getJobTitle(),
                employee.getSalary()));
    }

    private void increaseSalaries() {
        entityManager.getTransaction().begin();
        int affectedRows = entityManager
                .createQuery("UPDATE Employee AS e " +
                        "SET e.salary = e.salary * 1.12 " +
                        "WHERE e.department.id IN (1, 2, 4, 11)")
                .executeUpdate();
        entityManager.getTransaction().commit();

        entityManager
                .createQuery("SELECT e FROM Employee AS e " +
                        "WHERE e.department.id IN (1, 2, 4, 11)", Employee.class)
                .getResultStream()
                .forEach(emp -> System.out.printf("%s %s ($%.2f)%n",
                        emp.getFirstName(),
                        emp.getLastName(),
                        emp.getSalary()
                ));
    }

    private void findLatest10Projects() {
        List<Project> projects = entityManager
                .createQuery("SELECT p FROM Project AS p " +
                        "ORDER BY p.startDate DESC, p.name ASC ", Project.class)
                .setMaxResults(10)
                .getResultList();

        for (Project project : projects) {
            System.out.printf("Project name: %s%n", project.getName());
            System.out.printf("\tProject Description: %s%n", project.getDescription());
            System.out.printf("\tProject Start Date: %s%n", project.getStartDate());
            System.out.printf("\tProject End Date: %s%n", project.getEndDate());
        }
    }

    private void getEmployeeWithProject() throws IOException {
        System.out.println("Please enter valid employee id:");
        int id = Integer.parseInt(reader.readLine());

        Employee employee = entityManager.find(Employee.class, id);
        StringBuilder sb = new StringBuilder();
        sb.append(String.format("%s %s - %s",
                employee.getFirstName(),
                employee.getLastName(),
                employee.getJobTitle()))
                .append(System.lineSeparator());

        employee.getProjects()
                .stream().sorted(Comparator.comparing(Project::getName))
                .forEach(project -> sb.append(String.format("   %s%n",
                        project.getName())));

        System.out.println(sb.toString());

    }

    private void addressesWithEmployeeCountEx7() {
        List<Address> addresses = entityManager.createQuery("SELECT a FROM Address AS a " +
                "ORDER BY a.employees.size DESC ", Address.class)
                .setMaxResults(10)
                .getResultList();

        addresses.forEach(address -> System.out.printf("%s, %s - %d employees%n",
                address.getText(),
                address.getTown().getName(),
                address.getEmployees().size()));
    }

    private void addingNewAddressAndUpdatingEmployeeEx6() {
        Address address = createAddress("Vitoshka 15");

        Employee employee = entityManager.find(Employee.class, 291);

        entityManager.getTransaction().begin();
        employee.setAddress(address);
        entityManager.getTransaction().commit();
    }

    private void employeesFromDepartmentEx5() {
        entityManager.createQuery("SELECT e FROM Employee AS e " +
                "WHERE e.department.name = 'Research and Development' " +
                "ORDER BY e.salary ASC, e.id ASC", Employee.class)
                .getResultStream()
                .forEach(employee -> System.out.printf("%s %s from Research and Development - $%.2f%n",
                        employee.getFirstName(),
                        employee.getLastName(),
                        employee.getSalary()));
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
