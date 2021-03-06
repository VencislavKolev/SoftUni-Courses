package bakery;

import java.util.List;
import java.util.ArrayList;

public class Bakery {
    private final List<Employee> employees;
    private String name;
    private int capacity;

    private Bakery() {
        this.employees = new ArrayList<>();
    }

    public Bakery(String name, int capacity) {
        this();
        this.name = name;
        this.capacity = capacity;
    }

    public void add(Employee employee) {
        if (this.getCount() < this.capacity) {
            this.employees.add(employee);
        }
    }

    public boolean remove(String name) {
        return this.employees.removeIf(x -> x.getName().equals(name));
    }

    public Employee getOldestEmployee() {
        return this.employees
                .stream()
                .min((e1, e2) -> Integer.compare(e2.getAge(), e1.getAge()))
                .orElse(null);
    }

    public Employee getEmployee(String name) {
        return this.employees
                .stream()
                .filter(x -> x.getName().equals(name))
                .findFirst()
                .orElse(null);
    }

    public String report() {
        StringBuilder sb = new StringBuilder();
        sb.append(String.format("Employees working at Bakery %s:%n", this.name));

        for (Employee employee : employees) {
            sb.append(employee.toString())
                    .append(System.lineSeparator());
        }

        return sb.toString().trim();
    }

    public int getCount() {
        return this.employees.size();
    }
}
