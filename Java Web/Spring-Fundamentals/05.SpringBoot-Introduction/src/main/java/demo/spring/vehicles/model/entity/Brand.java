package demo.spring.vehicles.model.entity;


import lombok.Getter;
import lombok.NoArgsConstructor;
import lombok.Setter;

import javax.persistence.Entity;
import javax.persistence.Table;
import java.time.LocalDateTime;

@Entity
@Table(name = "brands")
@NoArgsConstructor
@Getter
@Setter
public class Brand extends BaseEntity{
    private String name;
    private LocalDateTime createdOn;
    private LocalDateTime modifiedOn;
}
