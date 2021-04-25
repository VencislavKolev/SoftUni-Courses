package com.springdata.gamestore.service;

import com.springdata.gamestore.domain.dto.UserLoginDto;
import com.springdata.gamestore.domain.dto.UserRegisterDto;
import com.springdata.gamestore.domain.entity.User;

import java.util.List;

public interface UserService {

    String register(UserRegisterDto userRegisterDto);

    String login(UserLoginDto userLoginDto);

    String logout();

    String buyGame(String title);

    List<String> getOwnedGames();

    User getUser();
}
