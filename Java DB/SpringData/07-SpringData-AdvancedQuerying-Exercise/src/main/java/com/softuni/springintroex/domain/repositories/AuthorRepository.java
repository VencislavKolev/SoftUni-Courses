package com.softuni.springintroex.domain.repositories;

import com.softuni.springintroex.domain.entities.Author;
import org.springframework.data.jpa.repository.JpaRepository;

public interface AuthorRepository extends JpaRepository<Author,Long> {
}
