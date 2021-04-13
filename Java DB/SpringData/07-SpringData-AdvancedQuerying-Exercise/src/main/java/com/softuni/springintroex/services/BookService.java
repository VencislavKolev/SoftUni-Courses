package com.softuni.springintroex.services;

import com.softuni.springintroex.domain.entities.AgeRestriction;
import com.softuni.springintroex.domain.entities.EditionType;

import java.io.IOException;
import java.math.BigDecimal;
import java.time.LocalDate;

public interface BookService {
    void seedBooksInDB() throws IOException;

    void printTitlesByAgeRestriction(AgeRestriction ageRestriction);

    void printTitlesOfGoldenBooksAndLessThan5000Copies(EditionType editionType, int copies);

    void printBooksByPrice(BigDecimal min, BigDecimal max);

    void printBooksNotReleasedIn(LocalDate releaseYear);

    void printBooksReleasedBefore(LocalDate releaseYear);

    void printBooksByTitleContaining(String pattern);

    void printBooksByAuthorLastNameStartingWith(String pattern);

    void printNumberOfBooksWithTitleLongerThan(int length);

    void printBookDetails(String title);

    void increaseBookCopies(int copies,LocalDate date);

    void deleteBookWithCopiesLeeThan(int copies);
}
