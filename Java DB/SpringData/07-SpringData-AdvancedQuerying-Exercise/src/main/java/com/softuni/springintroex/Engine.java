package com.softuni.springintroex;

import com.softuni.springintroex.services.AuthorService;
import com.softuni.springintroex.services.BookService;
import com.softuni.springintroex.services.CategoryService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.CommandLineRunner;
import org.springframework.stereotype.Component;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.math.BigDecimal;
import java.time.LocalDate;
import java.time.Year;
import java.time.format.DateTimeFormatter;
import java.util.Date;

@Component
public class Engine implements CommandLineRunner {

    private final CategoryService categoryService;
    private final AuthorService authorService;
    private final BookService bookService;
    BufferedReader reader;

    @Autowired
    public Engine(CategoryService categoryService, AuthorService authorService, BookService bookService) {
        this.categoryService = categoryService;
        this.authorService = authorService;
        this.bookService = bookService;
        this.reader = new BufferedReader(new InputStreamReader(System.in));
    }

    @Override
    public void run(String... args) throws Exception {
        //this.seedDB();

//        //------------1.Books Titles by Age Restriction------------
//        String input = this.reader.readLine().toUpperCase();
//        AgeRestriction ageRestriction = Enum.valueOf(AgeRestriction.class, input);
//        this.bookService.printTitlesByAgeRestriction(ageRestriction);

//        //------------2.Golden Books------------
//        this.bookService.printTitlesOfGoldenBooksAndLessThan5000Copies(EditionType.GOLD, 5000);

//        //------------3.Books by Price------------
//        this.bookService.printBooksByPrice(new BigDecimal(5), new BigDecimal(40));

        //------------4.Not Released Books------------
//        String input = this.reader.readLine();
//        LocalDate year = LocalDate.of(Integer.parseInt(input),1,1);
//        this.bookService.printBooksNotReleasedIn(year);

//        //------------5.Books Released Before Date------------
//        String input = this.reader.readLine();
//        LocalDate date = LocalDate.parse(input, DateTimeFormatter.ofPattern("dd-MM-yyyy"));
//        this.bookService.printBooksReleasedBefore(date);

//        //------------6.Authors Search------------
//        String input = this.reader.readLine();
//        this.authorService.printAuthorWithFirstNameEndingWith(input);

//        //------------7.Books Search------------
//        String input = this.reader.readLine();
//        this.bookService.printBooksByTitleContaining(input);

//        //------------8.Book Titles Search------------
//        String input = this.reader.readLine();
//        this.bookService.printBooksByAuthorLastNameStartingWith(input);

//        //------------9.Count Books------------
//        int input = Integer.parseInt(this.reader.readLine());
//        this.bookService.printNumberOfBooksWithTitleLongerThan(input);

//        //------------10.Total Book Copies------------
//        this.authorService.printAuthorsByBookCopies();

//        //------------11.Reduced Book------------
//        this.bookService.printBookDetails(reader.readLine());

        //------------12.Increase Book Copies------------
        DateTimeFormatter dtf = DateTimeFormatter.ofPattern("dd MMM yyyy");
        LocalDate localDate = LocalDate.parse(reader.readLine(), dtf);
        int copies = Integer.parseInt(reader.readLine());
        this.bookService.increaseBookCopies(copies, localDate);
    }

    private void seedDB() throws IOException {
        this.categoryService.seedCategoriesInDB();
        this.authorService.seedAuthorsInDB();
        this.bookService.seedBooksInDB();
    }
}
