package com.springdata.gamestore.domain.dto;

import javax.validation.constraints.Positive;
import java.math.BigDecimal;

public class EditGameDto {
    @Positive
    private BigDecimal price;
    @Positive
    private double size;

    public EditGameDto(@Positive BigDecimal price, @Positive double size) {
        this.price = price;
        this.size = size;
    }

    public BigDecimal getPrice() {
        return price;
    }

    public void setPrice(BigDecimal price) {
        this.price = price;
    }

    public double getSize() {
        return size;
    }

    public void setSize(double size) {
        this.size = size;
    }
}
