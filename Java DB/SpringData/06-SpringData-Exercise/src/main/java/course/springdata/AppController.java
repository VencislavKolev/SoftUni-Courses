package course.springdata;

import course.springdata.entity.Author;
import course.springdata.entity.Book;
import course.springdata.service.AuthorService;
import course.springdata.service.BookService;
import course.springdata.service.CategoryService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.CommandLineRunner;
import org.springframework.stereotype.Controller;

import java.time.LocalDate;
import java.time.format.DateTimeFormatter;
import java.util.List;
import java.util.stream.Collectors;

@Controller
public class AppController implements CommandLineRunner {

    private final CategoryService categoryService;
    private final AuthorService authorService;
    private final BookService bookService;

    @Autowired
    public AppController(CategoryService categoryService, AuthorService authorService, BookService bookService) {
        this.categoryService = categoryService;
        this.authorService = authorService;
        this.bookService = bookService;
    }

    @Override
    public void run(String... args) throws Exception {
        this.categoryService.seedCategories();
        this.authorService.seedAuthors();
        this.bookService.seedBooks();

        //Query 1
        //this.getAllBooksAfter2000();

        //Query 2
        //this.getAllAuthorsWithAtleastOneBookBefore1990();

        //Query 3
        this.getAuthorsByNumberOfBooksDesc();

        //Query 4
        //this.getAllBooksFromAuthor();
    }

    private void getAuthorsByNumberOfBooksDesc() {
        this.authorService.getAuthorsOrderedByBooksCountDescending()
                .forEach(a -> {
                    System.out.printf("First name: %s, Last name: %s, Books count: %d%n",
                            a.getFirstName(), a.getLastName(), a.getBooks().size());
                });
    }

    private void getAllAuthorsWithAtleastOneBookBefore1990() {
        LocalDate localDate = LocalDate.parse("1/1/1990",
                DateTimeFormatter.ofPattern("d/M/yyyy"));

        List<Book> booksBeforeDate = this.bookService.getAllBooksBefore(localDate);

        List<Author> authors = booksBeforeDate
                .stream()
                .distinct()
                .map(Book::getAuthor)
                .filter(author -> author.getBooks().size() >= 1)
                .collect(Collectors.toList());

        for (Author a : authors) {
            System.out.printf("First name: %s, Last name: %s%n",
                    a.getFirstName(), a.getLastName());
        }
    }

    private void getAllBooksFromAuthor() {
        String firstName = "George";
        String lastName = "Powell";
        this.bookService.
                getBooksFromAuthor(firstName, lastName)
                .forEach(book -> System.out.printf("Title: %s, release date: %s, copies: %d%n",
                        book.getTitle(), book.getReleaseDate(), book.getCopies()));
    }

    private void getAllBooksAfter2000() {
        this.bookService.getAllBooksAfter()
                .forEach(b -> System.out.printf("Title: %s%n", b.getTitle()));
    }
}
