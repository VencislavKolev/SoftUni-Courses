package com.softuni.springintroex.domain.repositories;

import com.softuni.springintroex.domain.entities.Category;
import org.springframework.data.jpa.repository.JpaRepository;

public interface CategoryRepository extends JpaRepository<Category, Long> {
}
