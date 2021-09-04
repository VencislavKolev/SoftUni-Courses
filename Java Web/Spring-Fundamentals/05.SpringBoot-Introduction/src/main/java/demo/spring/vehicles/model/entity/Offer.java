package demo.spring.vehicles.model.entity;

import com.fasterxml.jackson.annotation.JsonProperty;
import demo.spring.vehicles.model.entity.enums.Engine;
import demo.spring.vehicles.model.entity.enums.Transmission;
import lombok.Getter;
import lombok.NoArgsConstructor;
import lombok.NonNull;
import lombok.Setter;
import org.hibernate.validator.constraints.Length;

import javax.persistence.*;
import javax.validation.constraints.Min;
import javax.validation.constraints.PastOrPresent;
import javax.validation.constraints.Positive;
import java.math.BigDecimal;
import java.time.LocalDateTime;
import java.util.Date;

@Entity
@Table(name = "offers")
@Getter
@Setter
@NoArgsConstructor
public class Offer extends BaseEntity {

    @NonNull
    @Length(min = 2, max = 512)
    private String description;

    @NonNull
    @Enumerated(EnumType.STRING)
    private Engine engine;

    @NonNull
    @Length(min = 8, max = 512)
    private String imageUrl;

    private int mileage;

    @NonNull
    @PastOrPresent
    @Positive
    private BigDecimal price;

    @NonNull
    @Enumerated(EnumType.STRING)
    private Transmission transmission;

    @PastOrPresent
    @Min(1900)
    private int year;

    private Date createdOn = new Date();

    private Date modifiedOn = new Date();

    @NonNull
    @ManyToOne
    private Model model;


    @ManyToOne()
    private User seller;

    @JsonProperty(access = JsonProperty.Access.WRITE_ONLY)
    @Transient
    private String sellerId;
}
