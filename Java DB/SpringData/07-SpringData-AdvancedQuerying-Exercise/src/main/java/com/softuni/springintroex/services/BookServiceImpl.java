package com.softuni.springintroex.services;

import com.softuni.springintroex.constants.GlobalConstants;
import com.softuni.springintroex.domain.entities.*;
import com.softuni.springintroex.domain.repositories.AuthorRepository;
import com.softuni.springintroex.domain.repositories.BookRepository;
import com.softuni.springintroex.domain.repositories.CategoryRepository;
import com.softuni.springintroex.utils.FileUtil;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;

import java.io.IOException;
import java.math.BigDecimal;
import java.time.LocalDate;
import java.time.format.DateTimeFormatter;
import java.util.HashSet;
import java.util.Random;
import java.util.Set;

@Service
public class BookServiceImpl implements BookService {
    private final BookRepository bookRepo;
    private final FileUtil fileUtil;
    private final AuthorRepository authorRepo;
    private final CategoryRepository categoryRepo;

    @Autowired
    public BookServiceImpl(BookRepository bookRepo, FileUtil fileUtil, AuthorRepository authorRepo, CategoryRepository categoryRepository) {
        this.bookRepo = bookRepo;
        this.fileUtil = fileUtil;
        this.authorRepo = authorRepo;
        this.categoryRepo = categoryRepository;
    }

    @Override
    @Transactional
    public void seedBooksInDB() throws IOException {
        String[] content = this.fileUtil.readFileContent(GlobalConstants.BOOKS_FILE_PATH);

        Random random = new Random();
        for (String line : content) {
            String[] data = line.split("\\s+");

            long authorIndex = random.nextInt((int) this.authorRepo.count()) + 1;
            Author author = this.authorRepo.findById(authorIndex).get();
            EditionType editionType = EditionType.values()[Integer.parseInt(data[0])];
            DateTimeFormatter formatter = DateTimeFormatter.ofPattern("d/M/yyyy");
            LocalDate releaseDate = LocalDate.parse(data[1], formatter);
            int copies = Integer.parseInt(data[2]);
            BigDecimal price = new BigDecimal(data[3]);
            AgeRestriction ageRestriction = AgeRestriction.values()[Integer.parseInt(data[4])];
            StringBuilder titleBuilder = new StringBuilder();
            for (int i = 5; i < data.length; i++) {
                titleBuilder.append(data[i]).append(" ");
            }

            String title = titleBuilder.toString().trim();

            Book book = new Book();
            book.setAuthor(author);
            book.setEditionType(editionType);
            book.setReleaseDate(releaseDate);
            book.setCopies(copies);
            book.setPrice(price);
            book.setAgeRestriction(ageRestriction);
            book.setTitle(title);
            book.setCategories(this.generateCategories());

            this.bookRepo.saveAndFlush(book);
        }
    }

    private Set<Category> generateCategories() {
        Set<Category> categories = new HashSet<>();
        Random random = new Random();
        for (int i = 0; i < 3; i++) {
            long categoryId = random.nextInt((int) this.categoryRepo.count()) + 1;
            Category category = this.categoryRepo.findById(categoryId).get();
            categories.add(category);
        }
        return categories;
    }
}
