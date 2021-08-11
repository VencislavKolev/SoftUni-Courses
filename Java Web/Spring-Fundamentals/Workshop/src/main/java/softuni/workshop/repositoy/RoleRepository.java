package softuni.workshop.repositoy;

import org.springframework.data.jpa.repository.JpaRepository;
import softuni.workshop.model.entity.Role;

public interface RoleRepository extends JpaRepository<Role, String> {
}
