package com.springdata.gamestore.domain.dto;

import javax.validation.constraints.Pattern;
import javax.validation.constraints.Positive;
import java.math.BigDecimal;
import java.time.LocalDate;

public class AddGameDto {
    @Pattern(regexp = "[A-Z].{3,100}", message = "Must begin with uppercase and have length between 3-100 symbols")
    private String title;
    @Positive
    private BigDecimal price;
    @Positive
    private double size;
    @Pattern(regexp = "\\w{11}")
    private String trailer;
    // @Pattern(regexp = "^https?://(.*)")
    @Pattern(regexp = "https?://[^|]+")
    private String imageThumbnail;
    @Pattern(regexp = ".{20,}")
    private String description;
    private LocalDate releaseDate;

    public AddGameDto() {
    }

    public AddGameDto(@Pattern(regexp = "[A-Z].{3,100}", message = "Must begin with uppercase and have length between 3-100 symbols") String title, @Positive BigDecimal price, @Positive double size, @Pattern(regexp = "\\w{11}") String trailer, @Pattern(regexp = "https?://[^|]+") String imageThumbnail, @Pattern(regexp = ".{20,}") String description, LocalDate releaseDate) {
        this.title = title;
        this.price = price;
        this.size = size;
        this.trailer = trailer;
        this.imageThumbnail = imageThumbnail;
        this.description = description;
        this.releaseDate = releaseDate;
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

    public double getSize() {
        return size;
    }

    public void setSize(double size) {
        this.size = size;
    }

    public String getTrailer() {
        return trailer;
    }

    public void setTrailer(String trailer) {
        this.trailer = trailer;
    }

    public String getImageThumbnail() {
        return imageThumbnail;
    }

    public void setImageThumbnail(String imageThumbnail) {
        this.imageThumbnail = imageThumbnail;
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
}
