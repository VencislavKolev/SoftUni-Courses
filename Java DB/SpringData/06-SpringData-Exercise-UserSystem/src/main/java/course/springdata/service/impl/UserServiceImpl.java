package course.springdata.service.impl;

import course.springdata.entity.User;
import course.springdata.repository.UserRepository;
import course.springdata.service.UserService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.util.List;
import java.util.Optional;

@Service
public class UserServiceImpl implements UserService {

    private UserRepository userRepo;

    @Autowired
    public UserServiceImpl(UserRepository userRepo) {
        this.userRepo = userRepo;
    }

    @Override
    public User registerUser(User user) {
        return this.userRepo.save(user);
    }

    @Override
    public List<User> getAllUsers() {
        return this.userRepo.findAll();
    }

    @Override
    public List<User> getUsersEndingWith(String pattern) {
        return this.userRepo.getUsersByEmailEndsWith("@" + pattern);
    }

    @Override
    public void updateIsDeteled() {
        long id = 1;
        User user = this.userRepo.findById(id).orElseThrow(() -> new IllegalArgumentException("No user with given id " + id));

        user.setDeleted(true);
        this.userRepo.save(user);
    }

    @Override
    public void deleteUsers() {
        List<User> toDelete = this.getDeletedUsers();
        this.userRepo.deleteAll(toDelete);

        //TODO deletes cascade(all of his colleagues)
    }

    @Override
    public List<User> getDeletedUsers() {
        return this.userRepo.getUserByDeletedIsTrue();
    }
}
