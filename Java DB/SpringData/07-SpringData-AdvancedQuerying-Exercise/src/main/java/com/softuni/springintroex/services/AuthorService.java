package com.softuni.springintroex.services;

import java.io.IOException;

public interface AuthorService {
    void seedAuthorsInDB() throws IOException;

    void printAuthorWithFirstNameEndingWith(String pattern);

    void printAuthorsByBookCopies();
}
