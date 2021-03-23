package course.springdata.service;

import course.springdata.entity.Author;
import course.springdata.entity.Book;
import course.springdata.entity.Category;
import course.springdata.entity.enums.AgeRestriction;
import course.springdata.entity.enums.EditionType;
import course.springdata.repository.BookRepository;
import course.springdata.utils.FileUtil;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;

import java.io.IOException;
import java.math.BigDecimal;
import java.time.LocalDate;
import java.time.format.DateTimeFormatter;
import java.util.*;
import java.util.stream.Collectors;

import static course.springdata.constants.GlobalConstants.*;

@Service
@Transactional
public class BookServiceImpl implements BookService {

    private final FileUtil fileUtil;
    private final BookRepository bookRepo;
    private final CategoryService categoryService;
    private final AuthorService authorService;

    public BookServiceImpl(FileUtil fileUtil, BookRepository bookRepo, CategoryService categoryService, AuthorService authorService) {
        this.fileUtil = fileUtil;
        this.bookRepo = bookRepo;
        this.categoryService = categoryService;
        this.authorService = authorService;
    }

    @Override
    public void seedBooks() throws IOException {
        if (this.bookRepo.count() != 0) {
            return;
        }

        String[] fileContent = this.fileUtil
                .readFileContent(BOOKS_FILE_PATH);

        Arrays.stream(fileContent)
                .forEach(line -> {
                    String[] tokens = line.split("\\s+");
                    Author author = this.getRandomAuthor();

                    EditionType editionType = EditionType.values()[Integer.parseInt(tokens[0])];

                    DateTimeFormatter formatter = DateTimeFormatter.ofPattern("d/M/yyyy");
                    LocalDate releaseDate = LocalDate.parse(tokens[1], formatter);

                    int copies = Integer.parseInt(tokens[2]);

                    BigDecimal price = new BigDecimal(tokens[3]);

                    AgeRestriction ageRestriction = AgeRestriction.values()[Integer.parseInt(tokens[4])];

                    String title = this.getTitle(tokens);

                    Set<Category> categories = this.getRandomCategories();

                    Book book = new Book();
                    book.setAuthor(author);
                    book.setEditionType(editionType);
                    book.setReleaseDate(releaseDate);
                    book.setCopies(copies);
                    book.setPrice(price);
                    book.setAgeRestriction(ageRestriction);
                    book.setTitle(title);
                    book.setCategories(categories);

                    this.bookRepo.saveAndFlush(book);
                });
    }

    @Override
    public List<Book> getAllBooksAfter() {
        LocalDate localDate = LocalDate.of(2000, 12, 31);
        return this.bookRepo.getAllByReleaseDateAfter(localDate);
    }

    @Override
    public List<Book> getAllBooksBefore(LocalDate localDate) {
        return this.bookRepo.getAllByReleaseDateBefore(localDate);
    }

    @Override
    public List<Book> getBooksFromAuthor(String firstName, String lastName) {
        return this.bookRepo.getAllByAuthorFirstNameAndAuthorLastNameOrderByReleaseDateDescTitleAsc(firstName, lastName);
    }

    private Set<Category> getRandomCategories() {
        Random random = new Random();
        int bound = random.nextInt(3) + 1;
        int categoriesBound = (int) this.categoryService.getTotalCategoriesCount();
        Set<Category> categories = new HashSet<>();

        for (int i = 1; i <= bound; i++) {
            int randomId = random.nextInt(categoriesBound) + 1;
            Category randomCategory = this.categoryService.getById((long) randomId);
            categories.add(randomCategory);
        }
        return categories;
    }

    private String getTitle(String[] tokens) {
        return Arrays.stream(tokens)
                .skip(5)
                .map(String::new)
                .collect(Collectors.joining(" "));
    }

    private Author getRandomAuthor() {
        Random random = new Random();
        //from 1 to authorsCount inclusive
        int randomId = random.nextInt(this.authorService.getTotalAuthorsCount()) + 1;
        return this.authorService.getAuthorById((long) randomId);
    }
}
