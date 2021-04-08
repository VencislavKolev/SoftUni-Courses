package com.example.springdata.entity;

import lombok.AllArgsConstructor;
import lombok.Data;
import lombok.EqualsAndHashCode;
import lombok.NoArgsConstructor;

import javax.persistence.*;
import java.util.HashSet;
import java.util.Set;

import static javax.persistence.CascadeType.*;

@Data
@NoArgsConstructor
@AllArgsConstructor
@Entity
@Table(name = "shampoos")
@EqualsAndHashCode(onlyExplicitlyIncluded = true)
public class Shampoo {

    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    @EqualsAndHashCode.Include
    private Long id;

    private String brand;

    private double price;

    @Enumerated(value = EnumType.ORDINAL)
    private Size size;

    @ManyToOne
    private Label label;

    @ManyToMany(fetch = FetchType.EAGER, cascade = {PERSIST, REFRESH})
    @JoinTable(name = "shampoos_ingredients",
            joinColumns = @JoinColumn(name = "shampoo_id", referencedColumnName = "id"),
            inverseJoinColumns = @JoinColumn(name = "ingredient_id", referencedColumnName = "id"))
    private Set<Ingredient> ingredients = new HashSet<>();
}
