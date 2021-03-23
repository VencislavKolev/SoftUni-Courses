package course.springdata.service;

import course.springdata.entity.Author;

import java.io.IOException;
import java.util.List;

public interface AuthorService {
    void seedAuthors() throws IOException;

    int getTotalAuthorsCount();

    Author getAuthorById(Long id);

    List<Author> getAuthorsOrderedByBooksCountDescending();
}
