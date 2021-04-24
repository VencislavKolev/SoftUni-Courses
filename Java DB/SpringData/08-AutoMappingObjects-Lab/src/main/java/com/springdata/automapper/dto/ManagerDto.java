package com.springdata.automapper.dto;

import lombok.Data;
import lombok.NoArgsConstructor;

import java.util.List;
import java.util.stream.Collectors;

@Data
@NoArgsConstructor
public class ManagerDto {
    private Long id;
    private String firstName;
    private String lastName;
    private List<EmployeeDto> subordinates;

    //Derived property - GET only
    private int getSubordinatesNumber() {
        return this.subordinates.size();
    }

    @Override
    public String toString() {
        final StringBuilder sb = new StringBuilder();
        sb.append(this.firstName)
                .append(" ")
                .append(this.lastName)
                .append(" | Employees: ")
                .append(this.getSubordinatesNumber())
                .append(System.lineSeparator())
                .append(subordinates.stream()
                        .map(EmployeeDto::toString)
                        .collect(Collectors.joining(System.lineSeparator())));
        return sb.toString();

    }
}
