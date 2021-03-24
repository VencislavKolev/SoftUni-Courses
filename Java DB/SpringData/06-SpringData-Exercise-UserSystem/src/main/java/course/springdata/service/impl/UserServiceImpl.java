package course.springdata.service.impl;

import course.springdata.entity.User;
import course.springdata.repository.UserRepository;
import course.springdata.service.UserService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.util.List;

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
}
