package com.springdata.gamestore.service;

import com.springdata.gamestore.domain.dto.UserLoginDto;
import com.springdata.gamestore.domain.dto.UserRegisterDto;

public interface UserService {

    String register(UserRegisterDto userRegisterDto);

    String login(UserLoginDto userLoginDto);

    String logout();
}
