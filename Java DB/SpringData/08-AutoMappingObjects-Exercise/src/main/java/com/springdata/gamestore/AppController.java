package com.springdata.gamestore;

import com.springdata.gamestore.domain.dto.UserLoginDto;
import com.springdata.gamestore.domain.dto.UserRegisterDto;
import com.springdata.gamestore.service.UserService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.CommandLineRunner;
import org.springframework.stereotype.Component;

import java.io.BufferedReader;
import java.io.InputStreamReader;

@Component
public class AppController implements CommandLineRunner {
    private final UserService userService;

    @Autowired
    public AppController(UserService userService) {
        this.userService = userService;
    }

    @Override
    public void run(String... args) throws Exception {
        BufferedReader reader = new BufferedReader(new InputStreamReader(System.in));
        String input; // = reader.readLine();

        while (!(input = reader.readLine()).equals("")) {
            String[] tokens = input.split("\\|");

            String command = tokens[0];
            switch (command) {
                case "RegisterUser":
                    UserRegisterDto userRegisterDto = new UserRegisterDto(tokens[1], tokens[2], tokens[3], tokens[4]);
                    System.out.println(this.userService.register(userRegisterDto));
                    break;
                case "LoginUser":
                    UserLoginDto userLoginDto = new UserLoginDto(tokens[1], tokens[2]);
                    System.out.println(this.userService.login(userLoginDto));
                    break;
                case "Logout":
                    System.out.println(this.userService.logout());
                    break;
            }
        }
    }
}
