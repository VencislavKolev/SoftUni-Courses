package com.springdata.gamestore.service.impl;

import com.springdata.gamestore.domain.dto.UserLoginDto;
import com.springdata.gamestore.domain.dto.UserRegisterDto;
import com.springdata.gamestore.domain.entity.Game;
import com.springdata.gamestore.domain.entity.Role;
import com.springdata.gamestore.domain.entity.User;
import com.springdata.gamestore.repository.GameRepository;
import com.springdata.gamestore.repository.UserRepository;
import com.springdata.gamestore.service.UserService;
import com.springdata.gamestore.util.ValidatorUtil;
import org.modelmapper.ModelMapper;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.util.List;
import java.util.NoSuchElementException;
import java.util.Optional;
import java.util.stream.Collectors;

@Service
public class UserServiceImpl implements UserService {

    private final ModelMapper modelMapper;
    private final UserRepository userRepo;
    private final ValidatorUtil validatorUtil;
    //private final GameService gameService;
    private final GameRepository gameRepo;

    private User loggedUser;

    @Autowired
    public UserServiceImpl(ModelMapper modelMapper, UserRepository userRepo, ValidatorUtil validatorUtil, GameRepository gameRepo) {
        this.modelMapper = modelMapper;
        this.userRepo = userRepo;
        this.validatorUtil = validatorUtil;
        this.gameRepo = gameRepo;
    }

    @Override
    public String register(UserRegisterDto userRegisterDto) {
        StringBuilder sb = new StringBuilder();
        boolean userEmailExists = this.userRepo.existsByEmail(userRegisterDto.getEmail());

        if (this.validatorUtil.isValid(userRegisterDto)) {
            User user = this.modelMapper.map(userRegisterDto, User.class);
            if (userEmailExists) {
                throw new IllegalArgumentException
                        (String.format("User with email: %s already exists!", user.getEmail()));
            }

            if (this.userRepo.count() == 0) {
                user.setRole(Role.ADMIN);
            } else {
                user.setRole(Role.USER);
            }
            this.userRepo.save(user);

            sb.append(String.format("%s was registered.%n", userRegisterDto.getFullName()));
        } else {
            this.validatorUtil.violations(userRegisterDto)
                    .forEach(e -> sb.append(String.format("%s%n", e.getMessage())));
        }
        return sb.toString();
    }

    @Override
    public String login(UserLoginDto userLoginDto) {
        StringBuilder sb = new StringBuilder();

        User mappedUser = this.modelMapper.map(userLoginDto, User.class);
        Optional<User> dbUser = this.userRepo
                .findUserByEmailAndPassword(mappedUser.getEmail(), mappedUser.getPassword());
        if (dbUser.isEmpty()) {
            sb.append("Incorrect username / password").append(System.lineSeparator());
        } else {
            this.setLoggedUser(dbUser.get());
            sb.append(String.format("Successfully logged in %s%n", dbUser.get().getFullName()));
        }

        return sb.toString();
    }

    @Override
    public String logout() {
        StringBuilder sb = new StringBuilder();
        if (this.getLoggedUser() == null) {
            sb.append("Cannot log out. No user was logged in.");
        } else {
            sb.append(String.format("User %s successfully logged out", this.getLoggedUser().getFullName()));
            this.setLoggedUser(null);
        }
        return sb.toString();
    }

    @Override
    public String buyGame(String title) {
        StringBuilder sb = new StringBuilder();
        Game toBuy = this.gameRepo.findByTitle(title)
                .orElseThrow(() -> new NoSuchElementException("No such game"));

        if (this.getLoggedUser() == null) {
            sb.append("You must log in before buying.");
        } else {
            this.getLoggedUser().getGames().add(toBuy);
            this.userRepo.save(this.getLoggedUser());
            sb.append("You bought: ").append(toBuy.getTitle());
        }
        return sb.toString();
    }

    @Override
    public List<String> getOwnedGames() {
        if (this.getLoggedUser() == null) {
            throw new IllegalArgumentException("You must login first.");
        }

        return this.getLoggedUser().getGames()
                .stream().map(Game::getTitle)
                .collect(Collectors.toList());
    }

    @Override
    public User getUser() {
        return this.getLoggedUser();
    }

    public User getLoggedUser() {
        return this.loggedUser;
    }

    public void setLoggedUser(User loggedUser) {
        this.loggedUser = loggedUser;
    }
}
