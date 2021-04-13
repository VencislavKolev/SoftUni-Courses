package com.softuni.springintroex.domain.repositories;

import com.softuni.springintroex.domain.entities.Author;
import org.springframework.data.jpa.repository.JpaRepository;

import java.util.List;

public interface AuthorRepository extends JpaRepository<Author,Long> {
    List<Author> findAllByFirstNameEndingWith(String pattern);
}
