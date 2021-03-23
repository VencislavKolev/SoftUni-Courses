package course.springdata.service;

import course.springdata.entity.Category;
import course.springdata.repository.CategoryRepository;
import course.springdata.utils.FileUtil;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.io.IOException;
import java.util.Arrays;

import static course.springdata.constants.GlobalConstants.*;

@Service
public class CategoryServiceImpl implements CategoryService {

    private final FileUtil fileUtil;
    private final CategoryRepository categoryRepo;

    @Autowired
    public CategoryServiceImpl(FileUtil fileUtil, CategoryRepository categoryRepo) {
        this.fileUtil = fileUtil;
        this.categoryRepo = categoryRepo;
    }

    @Override
    public void seedCategories() throws IOException {
        if (this.categoryRepo.count() != 0) {
            return;
        }

        String[] fileContent = this.fileUtil
                .readFileContent(CATEGORIES_FILE_PATH);

        Arrays.stream(fileContent)
                .forEach(categoryName -> {
                    Category category = new Category(categoryName);
                    this.categoryRepo.saveAndFlush(category);
                });

    }

    @Override
    public long getTotalCategoriesCount() {
        return this.categoryRepo.count();
    }

    @Override
    public Category getById(Long id) {
        return this.categoryRepo.getOne(id);
    }
}
