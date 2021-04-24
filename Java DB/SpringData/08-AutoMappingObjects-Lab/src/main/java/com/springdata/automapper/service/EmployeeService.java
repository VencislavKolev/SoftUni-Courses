package com.springdata.automapper.service;

import com.springdata.automapper.entity.Employee;

import java.time.LocalDate;
import java.util.List;

public interface EmployeeService {
    List<Employee> getAllEmployees();

    Employee getEmployeeById(Long id);

    Employee addEmployee(Employee employee);

    Employee updateEmployee(Employee employee);

    Employee deleteEmployee(Long id);

    long getEmployeeCount();

    List<Employee> getManagers();

    List<Employee> getEmployeesBornBefore(LocalDate date);
}
