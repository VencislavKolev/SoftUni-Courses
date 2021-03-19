package com.springdata.springintro.entity;

import lombok.*;

import javax.persistence.*;
import java.time.LocalDate;
import java.util.HashSet;
import java.util.Set;

@Entity
@Data
@NoArgsConstructor
@RequiredArgsConstructor
@AllArgsConstructor
public class Post {

    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private Long id;
    @NonNull
    private String title;
    @NonNull
    private String description;
    @NonNull
    private String author;
    @NonNull
    @ElementCollection
    private Set<String> keywords = new HashSet<>();
    private LocalDate created = LocalDate.now();

    public Post(String title, String description, String author, Set<String> keywords) {
        this.title = title;
        this.description = description;
        this.author = author;
        this.keywords = keywords;
    }
}
