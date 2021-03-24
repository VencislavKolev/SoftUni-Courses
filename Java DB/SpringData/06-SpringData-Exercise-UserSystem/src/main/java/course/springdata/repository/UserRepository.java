package course.springdata.repository;

import course.springdata.entity.User;
import org.springframework.data.jpa.repository.JpaRepository;

import java.util.List;

public interface UserRepository extends JpaRepository<User, Long> {
    List<User> getUsersByEmailEndsWith(String pattern);
}
