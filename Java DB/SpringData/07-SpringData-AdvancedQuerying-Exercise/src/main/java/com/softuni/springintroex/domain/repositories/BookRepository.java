package com.softuni.springintroex.domain.repositories;

import com.softuni.springintroex.domain.entities.Book;
import org.springframework.data.jpa.repository.JpaRepository;

public interface BookRepository extends JpaRepository<Book, Long> {
}
