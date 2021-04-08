package com.example.springdata.init;

import com.example.springdata.dao.IngredientRepository;
import com.example.springdata.dao.LabelRepository;
import com.example.springdata.dao.ShampooRepository;
import com.example.springdata.entity.Ingredient;
import com.example.springdata.entity.Shampoo;
import com.example.springdata.util.PrintUtil;
import org.springframework.aop.scope.ScopedProxyUtils;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.CommandLineRunner;
import org.springframework.stereotype.Component;

import java.util.List;
import java.util.Set;

@Component
public class AppInitializer implements CommandLineRunner {
    private final ShampooRepository shampooRepo;
    private final IngredientRepository ingredientRepo;
    private final LabelRepository labelRepo;

    @Autowired
    public AppInitializer(ShampooRepository shampooRepo, IngredientRepository ingredientRepo, LabelRepository labelRepo) {
        this.shampooRepo = shampooRepo;
        this.ingredientRepo = ingredientRepo;
        this.labelRepo = labelRepo;
    }


    @Override
    public void run(String... args) throws Exception {

//        //-----------1.Select Shampoos by Size-----------
//        shampooRepo.findAllBySizeOrderById(MEDIUM)
//                .forEach(PrintUtil::printShampoo);

//        //-----------2.Select Shampoos by Size or Label-----------
//        shampooRepo.findAllBySizeOrLabelIdOrderByPriceAsc(MEDIUM, 10L)
//                .forEach(PrintUtil::printShampoo);

//        //-----------3.Select Shampoos by Price-----------
//        shampooRepo.findAllByPriceGreaterThanOrderByPriceDesc(5)
//                .forEach(PrintUtil::printShampoo);

//        //-----------4.Select Ingredients by Name-----------
//        this.printIngredientFormatLine();
//        ingredientRepo.findAllByNameStartingWith("M")
//                .forEach(PrintUtil::printIngredient);

//        //-----------5.Select Ingredients by Names-----------
//        this.printIngredientFormatLine();
//        ingredientRepo.findAllByNameInOrderByPriceAsc(List.of("Lavender", "Herbs", "Apple"))
//                .forEach(PrintUtil::printIngredient);

//        //-----------6.Count Shampoos by Price-----------
//        double price = 8.50;
//        int shampoosCount = this.shampooRepo.countAllByPriceLessThan(price);
//        System.out.println("Count: " + shampoosCount);


//        //-----------7.Select Shampoos by Ingredients-----------
//        shampooRepo.findAllByIngredients(List.of("Berry", "Mineral-Collagen"))
//                .forEach(PrintUtil::printShampoo);

//        //-----------8.Select Shampoos by Ingredients Count-----------
//        shampooRepo.findAllByIngredientsCount(2)
//                .forEach(PrintUtil::printShampoo);

//        //-----------9.Delete Ingredients by Name-----------
//        String nameToDelete = "Berry";
//        Ingredient toDelete = ingredientRepo.findByName(nameToDelete).get();
//        List<Shampoo> shampoosWithIngredient = shampooRepo.findByIngredient(toDelete);
//        shampoosWithIngredient
//                .forEach(s -> s.getIngredients()
//                        .remove(toDelete));
//
//
//        int rowsAffected = ingredientRepo.deleteAllByName(nameToDelete);
//        System.out.printf("Ingredient %s is deleted - %d rows affected%n", nameToDelete, rowsAffected);

//        // -----------10.Update Ingredients by Price-----------
//        ingredientRepo.findAll().forEach(PrintUtil::printIngredient);
//
//        System.out.println("-".repeat(100) + System.lineSeparator());
//
//        double percentage = 10;
//        ingredientRepo.updatePriceByPercentage(1 + (percentage / 100));
//        ingredientRepo.findAll().forEach(PrintUtil::printIngredient);


        // -----------11.Update Ingredients by Names-----------
        ingredientRepo.findAll().forEach(PrintUtil::printIngredient);
        System.out.println("-".repeat(100) + System.lineSeparator());
        double percentage = 10;
        ingredientRepo.updatePriceOfIngredientsInList(List.of("Lavender", "Herbs", "Apple"), 1 + (percentage / 100));
        ingredientRepo.findAll().forEach(PrintUtil::printIngredient);

    }

    private void printIngredientFormatLine() {
        System.out.format("|%5s | %-30.30s | %8s |%n",
                "Id", "Name", "Price");
    }
}
