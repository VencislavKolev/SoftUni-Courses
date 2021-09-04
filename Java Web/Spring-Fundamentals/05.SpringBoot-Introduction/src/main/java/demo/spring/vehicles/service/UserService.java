package demo.spring.vehicles.service;

import demo.spring.vehicles.model.entity.User;

import java.util.Collection;
import java.util.List;

public interface UserService {
    Collection<User> getUsers();

    User getUserById(String id);

    User getUserByUsername(String username);

    User createUser(User user);

    User updateUser(User user);

    User deleteUser(String id);

    long getUsersCount();

    List<User> createUsersBatch(List<User> users);
}