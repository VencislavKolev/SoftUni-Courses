package com.springdata.gamestore.service.impl;

import com.springdata.gamestore.domain.dto.UserLoginDto;
import com.springdata.gamestore.domain.dto.UserRegisterDto;
import com.springdata.gamestore.domain.entity.Game;
import com.springdata.gamestore.domain.entity.Role;
import com.springdata.gamestore.domain.entity.User;
import com.springdata.gamestore.repository.UserRepository;
import com.springdata.gamestore.service.GameService;
import com.springdata.gamestore.service.UserService;
import com.springdata.gamestore.util.ValidatorUtil;
import org.modelmapper.ModelMapper;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.util.List;
import java.util.Optional;
import java.util.stream.Collectors;

@Service
public class UserServiceImpl implements UserService {

    private final ModelMapper modelMapper;
    private final UserRepository userRepo;
    private final ValidatorUtil validatorUtil;
    private final GameService gameService;

    private User loggedUser;

    @Autowired
    public UserServiceImpl(ModelMapper modelMapper, UserRepository userRepo, ValidatorUtil validatorUtil, GameService gameService) {
        this.modelMapper = modelMapper;
        this.userRepo = userRepo;
        this.validatorUtil = validatorUtil;
        this.gameService = gameService;
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
            this.loggedUser = dbUser.get();
            sb.append(String.format("Successfully logged in %s%n", dbUser.get().getFullName()));
        }

        return sb.toString();
    }

    @Override
    public String logout() {
        StringBuilder sb = new StringBuilder();
        if (this.loggedUser == null) {
            sb.append("Cannot log out. No user was logged in.");
        } else {
            sb.append(String.format("User %s successfully logged out", this.loggedUser.getFullName()));
            this.loggedUser = null;
        }
        return sb.toString();
    }

    @Override
    public String buyGame(String title) {
        StringBuilder sb = new StringBuilder();
        Game toBuy = this.gameService.findByTitle(title);
        if (this.loggedUser == null) {
            sb.append("You must log in before buying.");
        } else {
            this.loggedUser.getGames().add(toBuy);
            this.userRepo.save(this.loggedUser);
            sb.append("You bought: " + toBuy.getTitle());
        }
        return sb.toString();
    }

    @Override
    public List<String> getOwnedGames() {
        return this.loggedUser.getGames()
                .stream().map(Game::getTitle)
                .collect(Collectors.toList());
    }
}
