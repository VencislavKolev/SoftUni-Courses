package demo.spring.vehicles.model.entity;

import lombok.Getter;
import lombok.NoArgsConstructor;
import lombok.Setter;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.ManyToOne;
import javax.persistence.Table;
import java.time.LocalDateTime;

@Entity
@Table(name = "users")
@Getter
@Setter
@NoArgsConstructor
public class User extends BaseEntity {
    @Column(nullable = false, unique = true)
    private String username;

    @Column(nullable = false, length = 30)
    private String firstName;

    @Column(nullable = false, length = 30)
    private String lastName;

    private boolean isActive;

    @Column(nullable = false, length = 512)
    //TODO 8 - 512 chars
    private String imageUrl;

    @ManyToOne
    private UserRole role;

    private LocalDateTime createdOn;

    private LocalDateTime modifiedOn;
}
