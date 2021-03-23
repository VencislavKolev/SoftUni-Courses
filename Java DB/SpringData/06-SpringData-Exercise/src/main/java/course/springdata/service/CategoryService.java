package course.springdata.service;

import course.springdata.entity.Category;

import java.io.IOException;

public interface CategoryService {
    void seedCategories() throws IOException;
    long getTotalCategoriesCount();
    Category getById(Long id);
}
