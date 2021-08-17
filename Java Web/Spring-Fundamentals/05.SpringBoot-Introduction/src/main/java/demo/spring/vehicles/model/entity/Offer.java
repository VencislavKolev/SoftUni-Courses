package demo.spring.vehicles.model.entity;

import demo.spring.vehicles.model.entity.enums.Engine;
import demo.spring.vehicles.model.entity.enums.Transmission;
import lombok.Getter;
import lombok.NoArgsConstructor;
import lombok.Setter;

import javax.persistence.*;
import java.math.BigDecimal;
import java.time.LocalDateTime;

@Entity
@Table(name = "offers")
@Getter
@Setter
@NoArgsConstructor
public class Offer extends BaseEntity{
    @Column(columnDefinition = "TEXT")
    private String description;

    @Enumerated(EnumType.STRING)
    private Engine engine;

    @Column(columnDefinition = "TEXT")
    //TODO 8 - 512 chars
    private String imageUrl;

    private int mileage;

    private BigDecimal price;

    private Transmission transmission;

    private int year;

    private LocalDateTime createdOn;

    private LocalDateTime modifiedOn;

    @ManyToOne
    private Model model;

    @ManyToOne
    private User user;
}
