package com.springdata.gamestore.domain.dto;

import java.math.BigDecimal;

public class GameDetailsDto {
    private String title;
    private BigDecimal price;

    public GameDetailsDto() {
    }

    public GameDetailsDto(String title, BigDecimal price) {
        this.title = title;
        this.price = price;
    }

    public String getTitle() {
        return title;
    }

    public void setTitle(String title) {
        this.title = title;
    }

    public BigDecimal getPrice() {
        return price;
    }

    public void setPrice(BigDecimal price) {
        this.price = price;
    }

    @Override
    public String toString() {
        return String.format("%s - %s",
                this.getTitle(),
                this.getPrice());
    }
}
