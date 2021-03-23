package course.springdata.service;

import course.springdata.entity.Book;

import java.io.IOException;
import java.time.LocalDate;
import java.util.List;

public interface BookService {
    void seedBooks() throws IOException;

    List<Book> getAllBooksAfter();
    List<Book> getAllBooksBefore(LocalDate localDate);
    List<Book> getBooksFromAuthor(String firstName,String lastName);
}
