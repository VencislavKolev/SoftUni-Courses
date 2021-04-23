package com.springdata.automapper.dto;

import lombok.Data;
import lombok.NoArgsConstructor;

@Data
@NoArgsConstructor
public class EmployeeDto {
    private Long id;
    private String firstName;
    private String lastName;
    private double salary;
    private String addressCity;
    private String managerLastName;

    @Override
    public String toString() {
        final StringBuilder sb = new StringBuilder();
        sb.append("     - ")
                .append(this.firstName)
                .append(" ")
                .append(this.lastName)
                .append(" ")
                .append(this.salary)
                .append(" - Manager: ")
                .append(this.managerLastName != null ? this.managerLastName : "[no manager]");
        return sb.toString();
    }
}
