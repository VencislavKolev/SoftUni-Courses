package com.example.springdata.dao;

import com.example.springdata.entity.Ingredient;
import com.example.springdata.entity.Shampoo;
import com.example.springdata.entity.Size;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;

import java.util.Collection;
import java.util.List;

public interface ShampooRepository extends JpaRepository<Shampoo, Long> {
    List<Shampoo> findAllBySizeOrderById(Size size);

    List<Shampoo> findAllBySizeOrLabelIdOrderByPriceAsc(Size size, Long label_id);

    List<Shampoo> findAllByPriceGreaterThanOrderByPriceDesc(double price);

    @Query(value = "SELECT s FROM Shampoo AS s, IN (s.ingredients) AS i WHERE i =:ingredient")
    List<Shampoo> findByIngredient(Ingredient ingredient);

    int countAllByPriceLessThan(double price);

    @Query(value = "SELECT s FROM Shampoo AS s " +
            "JOIN s.ingredients AS i " +
            "WHERE i.name IN :names")
    List<Shampoo> findAllByIngredients(@Param("names") Collection<String> ingredientNames);

    @Query(value = "SELECT s FROM Shampoo AS s WHERE s.ingredients.size < :count")
    List<Shampoo> findAllByIngredientsCount(@Param("count") int count);
}