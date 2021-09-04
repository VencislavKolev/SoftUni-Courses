package demo.spring.vehicles.model.entity;

import demo.spring.vehicles.model.entity.enums.Category;
import lombok.*;
import org.hibernate.validator.constraints.Length;

import javax.persistence.*;
import javax.validation.constraints.Min;
import javax.validation.constraints.NotNull;
import java.time.LocalDateTime;
import java.util.Date;

@Entity
@Table(name = "models")
@Getter
@Setter
@NoArgsConstructor
@AllArgsConstructor
public class Model extends BaseEntity {

    @NonNull
    @Length(min = 1, max = 40)
    private String name;

    @NonNull
    @NotNull
    @Enumerated(EnumType.STRING)
    private Category category;

    @NonNull
    @Length(min = 8, max = 512)
    private String imageUrl;

    @Min(1900)
    private Integer startYear;

    @Min(1900)
    private Integer endYear;

    private Date createdOn = new Date();

    private Date modifiedOn = new Date();

    @ManyToOne
    private Brand brand;

    public Model(String name, Category category, Integer startYear, Integer endYear, String imageUrl) {
        this.name = name;
        this.category = category;
        this.startYear = startYear;
        this.imageUrl = imageUrl;
        this.endYear = endYear;
    }
}
