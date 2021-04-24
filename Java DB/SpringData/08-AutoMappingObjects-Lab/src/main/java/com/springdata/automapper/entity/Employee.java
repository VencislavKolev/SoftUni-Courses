package com.springdata.automapper.entity;

import lombok.*;

import javax.persistence.*;
import java.time.LocalDate;
import java.util.ArrayList;
import java.util.HashSet;
import java.util.List;
import java.util.Set;

@Entity
@Table(name = "employees")
@Getter
@Setter
@Data
@NoArgsConstructor
@RequiredArgsConstructor
@AllArgsConstructor
public class Employee {

    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private Long id;
    @NonNull
    private String firstName;
    @NonNull
    private String lastName;
    @NonNull
    private double salary;
    @NonNull
    private LocalDate birthday;
    @ManyToOne
    @NonNull
    private Address address;
    private boolean onVacation;

    @ManyToOne(optional = true)
    @JoinColumn(name = "manager_id", referencedColumnName = "id")
    private Employee manager;

    @OneToMany(mappedBy = "manager", fetch = FetchType.EAGER)
    @ToString.Exclude
    private List<Employee> subordinates = new ArrayList<>();
}
