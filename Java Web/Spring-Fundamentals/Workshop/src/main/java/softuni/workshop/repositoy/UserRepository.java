package softuni.workshop.repositoy;

import org.springframework.data.jpa.repository.JpaRepository;
import softuni.workshop.model.entity.User;
import softuni.workshop.model.service.UserServiceModel;

public interface UserRepository extends JpaRepository<User, String> {

}
