package com.springdata.gamestore.domain.entity;

import lombok.AllArgsConstructor;
import lombok.Getter;
import lombok.NoArgsConstructor;
import lombok.Setter;

import javax.persistence.*;
import java.math.BigDecimal;
import java.time.LocalDate;
import java.util.List;

@Entity
@Table(name = "games")
@Getter
@Setter
@NoArgsConstructor
@AllArgsConstructor
public class Game {
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private Long id;
    @Column(nullable = false, unique = true, length = 100)
    private String title;
    @Column(nullable = false, unique = true, length = 11)
    private String trailer;
    @Column(name = "image_thumbnail", nullable = false)
    private String imageThumbnail;
    @Column(nullable = false)
    private double size;
    @Column(nullable = false)
    private BigDecimal price;
    @Column(nullable = false)
    private String description;
    @Column(name = "release_date", nullable = false)
    private LocalDate releaseDate;

    @ManyToMany(mappedBy = "games")
    private List<User> users;
}
