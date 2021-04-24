package com.springdata.automapper.service.impl;

import com.springdata.automapper.dao.EmployeeRepository;
import com.springdata.automapper.entity.Employee;
import com.springdata.automapper.service.EmployeeService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;

import java.time.LocalDate;
import java.util.List;
import java.util.NoSuchElementException;

@Service
@Transactional(readOnly = true)
public class EmployeeServiceImpl implements EmployeeService {

    private final EmployeeRepository employeeRepo;

    @Autowired
    public EmployeeServiceImpl(EmployeeRepository employeeRepo) {
        this.employeeRepo = employeeRepo;
    }

    @Override
    public List<Employee> getAllEmployees() {
        return this.employeeRepo.findAll();
    }

    @Override
    public Employee getEmployeeById(Long id) {
        return this.employeeRepo.findById(id)
                .orElseThrow(() -> new NoSuchElementException(
                        String.format("Employee with ID: %s does not exist", id)
                ));
    }

    @Override
    @Transactional
    public Employee addEmployee(Employee employee) {
        employee.setId(null);

        if (employee.getManager() != null) {
            employee.getManager().getSubordinates().add(employee);
        }

        return this.employeeRepo.save(employee);
    }

    @Override
    @Transactional
    public Employee updateEmployee(Employee employee) {
        Employee existing = this.getEmployeeById(employee.getId());
        Employee updated = this.employeeRepo.save(employee);

        //Managing BI-directional reference
        if (existing.getManager() != null && !existing.getManager().equals(employee.getManager())) {
            existing.getManager().getSubordinates().remove(existing);
        }

        if (updated.getManager() != null && !updated.getManager().equals(existing.getManager())) {
            updated.getManager().getSubordinates().add(updated);
        }
        return updated;
    }

    @Override
    @Transactional
    public Employee deleteEmployee(Long id) {
        Employee removed = this.getEmployeeById(id);
        if (removed.getManager() != null) {
            removed.getManager().getSubordinates().remove(removed);
        }
        this.employeeRepo.delete(removed);
        return removed;
    }

    @Override
    public long getEmployeeCount() {
        return this.employeeRepo.count();
    }

    @Override
    public List<Employee> getManagers() {
        return this.employeeRepo.getManagers();
    }

    @Override
    public List<Employee> getEmployeesBornBefore(LocalDate date) {
        return this.employeeRepo.getEmployeesByBirthdayBeforeOrderBySalaryDesc(date);
    }
}
