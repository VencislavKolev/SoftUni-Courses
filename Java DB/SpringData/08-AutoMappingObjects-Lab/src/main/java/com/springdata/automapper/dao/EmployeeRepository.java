package com.springdata.automapper.dao;

import com.springdata.automapper.entity.Employee;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;

import java.time.LocalDate;
import java.util.List;

public interface EmployeeRepository extends JpaRepository<Employee, Long> {

    @Query("SELECT e FROM Employee e WHERE e.subordinates IS NOT EMPTY")
    List<Employee> getManagers();

    List<Employee> getEmployeesByBirthdayBeforeOrderBySalaryDesc(LocalDate birthdate);
}
