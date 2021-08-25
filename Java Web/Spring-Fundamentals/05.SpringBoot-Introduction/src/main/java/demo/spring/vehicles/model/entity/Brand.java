package demo.spring.vehicles.model.entity;


import lombok.*;
import org.hibernate.validator.constraints.Length;

import javax.persistence.*;
import java.util.ArrayList;
import java.util.Date;
import java.util.List;
import java.util.Set;

@Entity
@Table(name = "brands")
@NoArgsConstructor
@RequiredArgsConstructor
@AllArgsConstructor
@Getter
@Setter
public class Brand extends BaseEntity {

    @NonNull
    @Length(min = 2, max = 40)
    private String name;

    private Date createdOn = new Date();

    private Date modifiedOn = new Date();

    @OneToMany(mappedBy = "brand", fetch = FetchType.EAGER, cascade = CascadeType.ALL)
    private List<Model> models = new ArrayList<>();

    public static Brand create(String name, Set<Model> models) {
        Brand brand = new Brand(name);
        models.forEach(model -> {
            model.setBrand(brand);
            brand.getModels().add(model);
        });
        return brand;
    }

//    @Override
//    private int compareTo(Brand brand) {
//        return this.name.compareToIgnoreCase(brand.getName());
//    }
}
