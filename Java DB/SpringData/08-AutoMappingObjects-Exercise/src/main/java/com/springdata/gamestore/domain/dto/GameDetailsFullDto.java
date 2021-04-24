package com.springdata.gamestore.domain.dto;

import java.math.BigDecimal;
import java.time.LocalDate;

public class GameDetailsFullDto extends GameDetailsDto {
    private String description;
    private LocalDate releaseDate;

    public GameDetailsFullDto(){

    }

    public GameDetailsFullDto(String description, LocalDate releaseDate) {
        this.description = description;
        this.releaseDate = releaseDate;
    }

    public GameDetailsFullDto(String title, BigDecimal price, String description, LocalDate releaseDate) {
        super(title, price);
        this.description = description;
        this.releaseDate = releaseDate;
    }

    public String getDescription() {
        return description;
    }

    public void setDescription(String description) {
        this.description = description;
    }

    public LocalDate getReleaseDate() {
        return releaseDate;
    }

    public void setReleaseDate(LocalDate releaseDate) {
        this.releaseDate = releaseDate;
    }

    @Override
    public String toString() {
        final StringBuilder sb = new StringBuilder();
        sb.append("Title: " + this.getTitle() + System.lineSeparator())
                .append("Price: " + this.getPrice() + System.lineSeparator())
                .append("Description: " + this.getDescription() + System.lineSeparator())
                .append("Release date: " + this.getReleaseDate() + System.lineSeparator());
        return sb.toString();
    }
}
