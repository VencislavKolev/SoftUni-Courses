package com.springdata.automapper;

import com.springdata.automapper.dto.EmployeeDto;
import com.springdata.automapper.dto.ManagerDto;
import com.springdata.automapper.entity.Address;
import com.springdata.automapper.entity.Employee;
import com.springdata.automapper.service.AddressService;
import com.springdata.automapper.service.EmployeeService;
import org.modelmapper.ModelMapper;
import org.modelmapper.TypeMap;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.CommandLineRunner;
import org.springframework.stereotype.Component;

import java.time.LocalDate;
import java.util.List;
import java.util.stream.Collectors;

@Component
public class AppInitializer implements CommandLineRunner {

    private final EmployeeService employeeService;
    private final AddressService addressService;

    @Autowired
    public AppInitializer(EmployeeService employeeService, AddressService addressService) {
        this.employeeService = employeeService;
        this.addressService = addressService;
    }

    @Override
    public void run(String... args) throws Exception {
        ModelMapper mapper = new ModelMapper();

        Address address = new Address("Bulgaria", "Sofia", "Blok 1");
        address = this.addressService.addAddress(address);

        Employee employee = new Employee("Vencislav", "Kolev", 2500, LocalDate.of(1997, 4, 7), address);
        employee = this.employeeService.addEmployee(employee);

        EmployeeDto employeeDto = mapper.map(employee, EmployeeDto.class);
        System.out.println(employeeDto);

        //2.TypeMap addresses and employees to ManagerDto with employeeDto's
        List<Address> addresses = List.of(
                new Address("Bulgaria", "Sofia", "ul. G.S.Rakovski, 50"),
                new Address("Bulgaria", "Sofia", "Bul. Dondukov, 45"),
                new Address("Bulgaria", "Sofia", "ul. Hristo Smirnenski, 40"),
                new Address("Bulgaria", "Sofia", "bul. Alexander Malinov, 93a"),
                new Address("Bulgaria", "Sofia", "bul. Slivnitsa, 50"),
                new Address("Bulgaria", "Plovdiv", "ul. Angel Kanchev,34")
        );
        addresses = addresses.stream()
                .map(addressService::addAddress)
                .collect(Collectors.toList());

        List<Employee> employees = List.of(
                new Employee("Steve", "Adams", 5780, LocalDate.of(1982, 3, 12),
                        addresses.get(0)),
                new Employee("Stephen", "Petrov", 2760, LocalDate.of(1974, 5, 19),
                        addresses.get(1)),
                new Employee("Hristina", "Petrova", 3680, LocalDate.of(1991, 11, 9),
                        addresses.get(1)),
                new Employee("Diana", "Atanasova", 6790, LocalDate.of(1989, 12, 9),
                        addresses.get(2)),
                new Employee("Samuil", "Georgiev", 4780, LocalDate.of(1979, 2, 10),
                        addresses.get(3)),
                new Employee("Slavi", "Hristov", 3780, LocalDate.of(1985, 2, 23),
                        addresses.get(4)),
                new Employee("Georgi", "Miladinov", 3960, LocalDate.of(1995, 3, 11),
                        addresses.get(5))
        );
        List<Employee> created = employees.stream()
                .map(employeeService::addEmployee)
                .collect(Collectors.toList());

        //Add managers and update employees
        created.get(1).setManager(created.get(0));
        created.get(2).setManager(created.get(0));

        created.get(4).setManager(created.get(3));
        created.get(5).setManager(created.get(3));
        created.get(6).setManager(created.get(3));

        List<Employee> updated = created.stream()
                .map(this.employeeService::updateEmployee)
                .collect(Collectors.toList());

        TypeMap<Employee, ManagerDto> typeMap = mapper.createTypeMap(Employee.class, ManagerDto.class)
                .addMappings(m -> m.map(Employee::getSubordinates, ManagerDto::setSubordinates));

        List<Employee> managers = this.employeeService.getManagers();
        List<ManagerDto> managerDtos = managers.stream()
                .map(typeMap::map)
                .collect(Collectors.toList());
        managerDtos.forEach(System.out::println);

        //3.
        System.out.println("-".repeat(50));
        TypeMap<Employee, EmployeeDto> task3TypeMap = mapper.getTypeMap(Employee.class, EmployeeDto.class)
                .addMapping(src -> src.getManager().getLastName(), EmployeeDto::setManagerLastName);

        List<Employee> bornBefore1990 = this.employeeService.getEmployeesBornBefore(LocalDate.of(1990, 1, 1));
        List<EmployeeDto> employeeDtos = bornBefore1990.stream()
                .map(task3TypeMap::map)
                .collect(Collectors.toList());
        employeeDtos.forEach(System.out::println);
    }
}
