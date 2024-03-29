package com.example.springdata.entity;

import lombok.Data;
import lombok.EqualsAndHashCode;
import lombok.ToString;

import javax.persistence.*;
import java.util.HashSet;
import java.util.Set;

@Data
@Entity
@Table(name = "labels")
@EqualsAndHashCode(onlyExplicitlyIncluded = true)
public class Label {
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    @EqualsAndHashCode.Include
    private Long id;

    private String title;

    private String subtitle;

    @ToString.Exclude
    @OneToMany(mappedBy = "label")
    private Set<Shampoo> shampoos = new HashSet<>();
}