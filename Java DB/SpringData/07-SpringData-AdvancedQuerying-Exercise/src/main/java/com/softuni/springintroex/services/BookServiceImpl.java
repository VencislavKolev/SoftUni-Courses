package com.softuni.springintroex.services;

import com.softuni.springintroex.constants.GlobalConstants;
import com.softuni.springintroex.domain.entities.*;
import com.softuni.springintroex.domain.entities.dto.BookDto;
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
import java.util.List;
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

    @Override
    public void printTitlesByAgeRestriction(AgeRestriction ageRestriction) {
        List<Book> books = this.bookRepo.findAllByAgeRestriction(ageRestriction);
        this.printTitle(books);
    }

    @Override
    public void printTitlesOfGoldenBooksAndLessThan5000Copies(EditionType editionType, int copies) {
        printTitle(this.bookRepo.findAllByEditionTypeAndCopiesLessThan(editionType, copies));
    }

    @Override
    public void printBooksByPrice(BigDecimal min, BigDecimal max) {
        this.bookRepo.findAllByPriceLessThanOrPriceGreaterThan(min, max)
                .forEach(b -> System.out.printf("%s - $%.2f%n",
                        b.getTitle(), b.getPrice()));
    }

    @Override
    public void printBooksNotReleasedIn(LocalDate releaseYear) {
        this.printTitle(this.bookRepo.findAllByReleaseDateIsNot(releaseYear));
    }

    @Override
    public void printBooksReleasedBefore(LocalDate releaseDate) {
        this.bookRepo.findAllByReleaseDateBefore(releaseDate)
                .forEach(b -> System.out.printf("%s - %s - $%.2f%n",
                        b.getTitle(), b.getEditionType(), b.getPrice()));
    }

    @Override
    public void printBooksByTitleContaining(String pattern) {
        this.printTitle(this.bookRepo.findAllByTitleContaining(pattern));
    }

    @Override
    public void printBooksByAuthorLastNameStartingWith(String pattern) {
        this.printTitle(this.bookRepo.findAllByAuthorLastNameJPQL(pattern));
    }

    @Override
    public void printNumberOfBooksWithTitleLongerThan(int length) {
        System.out.println(this.bookRepo.countAllByTitleLength(length));
    }

    @Override
    public void printBookDetails(String title) {
        Book book = this.bookRepo.findBookByTitle(title);

        BookDto bookDto = new BookDto(book.getTitle(), book.getEditionType(), book.getAgeRestriction(), book.getPrice());
        System.out.println(bookDto);
    }

    @Override
    public void increaseBookCopies(int copies, LocalDate date) {
        System.out.println(this.bookRepo.getUpdatedRows(copies, date) * copies);
    }

    @Override
    public void deleteBookWithCopiesLeeThan(int copies) {
        System.out.println(this.bookRepo.getDeletedRows(copies));
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

    private void printTitle(List<Book> books) {
        books.forEach(b -> System.out.printf("%s%n", b.getTitle()));
    }
}
