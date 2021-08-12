package softuni.workshop.repositoy;

import org.springframework.data.jpa.repository.JpaRepository;
import softuni.workshop.model.entity.Role;

import java.util.Optional;

public interface RoleRepository extends JpaRepository<Role, String> {

    Optional<Role> findByName(String name);

}
