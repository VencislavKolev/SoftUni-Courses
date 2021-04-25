package com.springdata.gamestore.domain.dto;

import lombok.AllArgsConstructor;
import lombok.Getter;
import lombok.NoArgsConstructor;
import lombok.Setter;
import org.hibernate.validator.constraints.Length;

import javax.validation.constraints.Pattern;
import javax.validation.constraints.Positive;
import java.math.BigDecimal;
import java.time.LocalDate;

@Getter
@Setter
@NoArgsConstructor
@AllArgsConstructor
public class AddGameDto {

    @Pattern(regexp = "[A-Z].{3,100}", message = "Must begin with uppercase and have length between 3-100 symbols")
    private String title;

    @Positive(message = "Price must be a positive number")
    private BigDecimal price;

    @Positive(message = "Size must be a positive number")
    private double size;

    @Length(min = 11, max = 11, message = "Invalid YouTube URL id")
    private String trailer;

    @Pattern(regexp = "https?://[^|]+",message = "Invalid image URL")
    private String imageThumbnail;

    @Length(min = 20,message = "Description must be at least 20 symbols")
    private String description;

    private LocalDate releaseDate;

//    public AddGameDto() {
//    }
//
//    public AddGameDto(@Pattern(regexp = "[A-Z].{3,100}", message = "Must begin with uppercase and have length between 3-100 symbols") String title, @Positive(message = "Price must be a positive number") BigDecimal price, @Positive(message = "Size must be a positive number") double size, @Length(min = 11, max = 11, message = "Invalid YouTube URL id") String trailer, @Pattern(regexp = "https?://[^|]+", message = "Invalid image URL") String imageThumbnail, @Length(min = 20, message = "Description must be at least 20 symbols") String description, LocalDate releaseDate) {
//        this.title = title;
//        this.price = price;
//        this.size = size;
//        this.trailer = trailer;
//        this.imageThumbnail = imageThumbnail;
//        this.description = description;
//        this.releaseDate = releaseDate;
//    }
//
//    //    public AddGameDto(@Pattern(regexp = "[A-Z].{3,100}", message = "Must begin with uppercase and have length between 3-100 symbols") String title, @Positive BigDecimal price, @Positive double size, @Pattern(regexp = "\\w{11}") String trailer, @Pattern(regexp = "https?://[^|]+") String imageThumbnail, @Pattern(regexp = ".{20,}") String description, LocalDate releaseDate) {
////        this.title = title;
////        this.price = price;
////        this.size = size;
////        this.trailer = trailer;
////        this.imageThumbnail = imageThumbnail;
////        this.description = description;
////        this.releaseDate = releaseDate;
////    }
//
//    public String getTitle() {
//        return title;
//    }
//
//    public void setTitle(String title) {
//        this.title = title;
//    }
//
//    public BigDecimal getPrice() {
//        return price;
//    }
//
//    public void setPrice(BigDecimal price) {
//        this.price = price;
//    }
//
//    public double getSize() {
//        return size;
//    }
//
//    public void setSize(double size) {
//        this.size = size;
//    }
//
//    public String getTrailer() {
//        return trailer;
//    }
//
//    public void setTrailer(String trailer) {
//        this.trailer = trailer;
//    }
//
//    public String getImageThumbnail() {
//        return imageThumbnail;
//    }
//
//    public void setImageThumbnail(String imageThumbnail) {
//        this.imageThumbnail = imageThumbnail;
//    }
//
//    public String getDescription() {
//        return description;
//    }
//
//    public void setDescription(String description) {
//        this.description = description;
//    }
//
//    public LocalDate getReleaseDate() {
//        return releaseDate;
//    }
//
//    public void setReleaseDate(LocalDate releaseDate) {
//        this.releaseDate = releaseDate;
//    }
}
