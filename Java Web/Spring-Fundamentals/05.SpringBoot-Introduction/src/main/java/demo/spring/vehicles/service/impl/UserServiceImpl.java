package demo.spring.vehicles.service.impl;

import demo.spring.vehicles.dao.UserRepository;
import demo.spring.vehicles.model.entity.User;
import demo.spring.vehicles.model.entity.enums.Role;
import demo.spring.vehicles.service.UserService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import javax.persistence.EntityNotFoundException;
import javax.transaction.Transactional;
import javax.validation.Valid;
import java.util.Collection;
import java.util.Date;
import java.util.List;
import java.util.Set;
import java.util.stream.Collectors;


@Service
public class UserServiceImpl implements UserService {

    private final UserRepository userRepo;

    @Autowired
    public UserServiceImpl(UserRepository userRepo) {
        this.userRepo = userRepo;
    }

    @Override
    public Collection<User> getUsers() {
        return this.userRepo.findAll();
    }

    @Override
    public User getUserById(String id) {
        return userRepo.findById(id).orElseThrow(() ->
                new EntityNotFoundException(String.format("User with ID=%s not found.", id)));
    }

    @Override
    public User getUserByUsername(String username) {
        return userRepo.findByUsername(username).orElseThrow(() ->
                new EntityNotFoundException(String.format("User '%s' not found.", username)));
    }

    @Override
    public User createUser(@Valid User user) {
        this.userRepo.findByUsername(user.getUsername()).ifPresent(u -> {
            throw new IllegalArgumentException(String.format("User with username '%s' already exists.", user.getUsername()));
        });

        user.setCreated(new Date());
        user.setModified(new Date());

        if (user.getRoles().size() == 0) {
            user.setRoles(Set.of(Role.SELLER));
        }
        user.setActive(true);
        return this.userRepo.save(user);
    }

    @Override
    public User updateUser(User user) {
        User toUpdate = this.getUserById(user.getId());
        if (!user.getUsername().equals(toUpdate.getUsername())) {
            throw new IllegalArgumentException("Username of a user could not be changed.");
        }
        user.setModified(new Date());
        return this.userRepo.save(user);
    }

    @Override
    public User deleteUser(String id) {
        User toDelete = this.getUserById(id);
        this.userRepo.deleteById(id);
        return toDelete;
    }

    @Override
    public long getUsersCount() {
        return this.userRepo.count();
    }

    @Transactional
    @Override
    public List<User> createUsersBatch(List<User> users) {
        List<User> created = users.stream()
                .map(this::createUser)
                .collect(Collectors.toList());
        return created;
    }
}
