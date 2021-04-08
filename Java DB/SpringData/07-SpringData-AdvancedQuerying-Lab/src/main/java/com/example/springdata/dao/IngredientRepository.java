package com.example.springdata.dao;

import com.example.springdata.entity.Ingredient;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Modifying;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.transaction.annotation.Transactional;

import java.util.List;
import java.util.Optional;

public interface IngredientRepository extends JpaRepository<Ingredient, Long> {
    List<Ingredient> findAllByNameStartingWith(String letter);

    List<Ingredient> findAllByNameInOrderByPriceAsc(List<String> names);

    Optional<Ingredient> findByName(String name);

    @Transactional
    @Modifying
    @Query(value = "DELETE FROM Ingredient AS i WHERE i.name = ?1")
    int deleteAllByName(String name);


    @Modifying
    @Transactional
    @Query(value = "UPDATE Ingredient AS i " +
            "SET i.price = i.price * :percentage ")
    int updatePriceByPercentage(@Param("percentage") double percentage);
    //int updatePriceByPercentage();

    @Modifying
    @Transactional
    @Query(value = "UPDATE Ingredient AS i " +
            "SET i.price = i.price * :percentage " +
            "WHERE i.name IN (:ingredient_names)")
    int updatePriceOfIngredientsInList(@Param("ingredient_names") Iterable<String> ingredientNames,
                                       @Param("percentage") double percentage);

}
