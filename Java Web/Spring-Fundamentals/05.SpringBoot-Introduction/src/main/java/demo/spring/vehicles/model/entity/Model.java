package demo.spring.vehicles.model.entity;

import demo.spring.vehicles.model.entity.enums.Category;
import lombok.Getter;
import lombok.NoArgsConstructor;
import lombok.Setter;

import javax.persistence.*;
import java.time.LocalDateTime;

@Entity
@Table(name = "models")
@Getter
@Setter
@NoArgsConstructor
public class Model extends BaseEntity{
    private String name;

    @Enumerated(EnumType.STRING)
    private Category category;

    @Column(columnDefinition = "TEXT")
    //TODO 8 - 512 chars
    private String imageUrl;

    private int startYear;

    private int endYear;

    private LocalDateTime createdOn;

    private LocalDateTime modifiedOn;

    @ManyToOne
    private Brand brand;
}
