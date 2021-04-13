package com.softuni.springintroex.domain.repositories;

import com.softuni.springintroex.domain.entities.AgeRestriction;
import com.softuni.springintroex.domain.entities.Book;
import com.softuni.springintroex.domain.entities.EditionType;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Modifying;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.transaction.annotation.Transactional;

import java.math.BigDecimal;
import java.time.LocalDate;
import java.util.List;

public interface BookRepository extends JpaRepository<Book, Long> {
    List<Book> findAllByAgeRestriction(AgeRestriction ageRestriction);

    List<Book> findAllByEditionTypeAndCopiesLessThan(EditionType editionType, int copies);

    List<Book> findAllByPriceLessThanOrPriceGreaterThan(BigDecimal min, BigDecimal max);

    List<Book> findAllByReleaseDateIsNot(LocalDate year);

    List<Book> findAllByReleaseDateBefore(LocalDate date);

    List<Book> findAllByTitleContaining(String pattern);

    @Query(value = "SELECT b FROM Book AS b WHERE b.author.lastName LIKE :lastName%")
    List<Book> findAllByAuthorLastNameJPQL(@Param("lastName") String text);

    @Query(value = "SELECT COUNT(b) FROM Book AS b WHERE length(b.title) > :length")
    int countAllByTitleLength(@Param("length") int length);

    Book findBookByTitle(String title);

    @Transactional
    @Modifying
    @Query(value = "UPDATE Book b SET b.copies = b.copies + :copies WHERE b.releaseDate > :date")
    int getUpdatedRows(int copies, LocalDate date);
}
