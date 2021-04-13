package com.softuni.springintroex.domain.entities.dto;

import com.softuni.springintroex.domain.entities.AgeRestriction;
import com.softuni.springintroex.domain.entities.EditionType;

import java.math.BigDecimal;

public class BookDto {
    private final String title;
    private final EditionType editionType;
    private final AgeRestriction ageRestriction;
    private final BigDecimal price;

    public BookDto(String title, EditionType editionType, AgeRestriction ageRestriction, BigDecimal price) {
        this.title = title;
        this.editionType = editionType;
        this.ageRestriction = ageRestriction;
        this.price = price;
    }

    public String getTitle() {
        return title;
    }

    public EditionType getEditionType() {
        return editionType;
    }

    public AgeRestriction getAgeRestriction() {
        return ageRestriction;
    }

    public BigDecimal getPrice() {
        return price;
    }

    @Override
    public String toString() {
        return "BookDto{" +
                "title='" + title + '\'' +
                ", editionType=" + editionType +
                ", ageRestriction=" + ageRestriction +
                ", price=" + price +
                '}';
    }
}
