package com.softuni.springintroex.services;

import com.softuni.springintroex.constants.GlobalConstants;
import com.softuni.springintroex.domain.entities.Category;
import com.softuni.springintroex.domain.repositories.CategoryRepository;
import com.softuni.springintroex.utils.FileUtil;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.io.IOException;

@Service
public class CategoryServiceImpl implements CategoryService {
    private final CategoryRepository categoryRepo;
    private final FileUtil fileUtill;

    @Autowired
    public CategoryServiceImpl(CategoryRepository categoryRepo, FileUtil fileUtill) {
        this.categoryRepo = categoryRepo;
        this.fileUtill = fileUtill;
    }

    @Override
    public void seedCategoriesInDB() throws IOException {
        String[] content = this.fileUtill.readFileContent(GlobalConstants.CATEGORIES_FILE_PATH);

        for (String categoryName : content) {
            Category category = new Category(categoryName);
            this.categoryRepo.saveAndFlush(category);
        }
    }
}
