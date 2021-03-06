package course.springdata.service;

import course.springdata.entity.User;

import java.util.List;

public interface UserService {
    User registerUser(User user);

    List<User> getAllUsers();

    List<User> getUsersEndingWith(String pattern);

    void updateIsDeteled();

    void deleteUsers();

    List<User> getDeletedUsers();
}
