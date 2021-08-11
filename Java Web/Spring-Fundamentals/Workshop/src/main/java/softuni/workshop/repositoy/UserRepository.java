package softuni.workshop.repositoy;

import org.springframework.data.jpa.repository.JpaRepository;
import softuni.workshop.model.entity.User;

public interface UserRepository extends JpaRepository<User, String> {
}
