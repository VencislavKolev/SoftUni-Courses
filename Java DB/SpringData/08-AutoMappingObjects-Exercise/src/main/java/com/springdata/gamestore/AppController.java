package com.springdata.gamestore;

import com.springdata.gamestore.domain.dto.AddGameDto;
import com.springdata.gamestore.domain.dto.EditGameDto;
import com.springdata.gamestore.domain.dto.UserLoginDto;
import com.springdata.gamestore.domain.dto.UserRegisterDto;
import com.springdata.gamestore.service.GameService;
import com.springdata.gamestore.service.UserService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.CommandLineRunner;
import org.springframework.stereotype.Component;

import java.io.BufferedReader;
import java.io.InputStreamReader;
import java.math.BigDecimal;
import java.time.LocalDate;
import java.time.format.DateTimeFormatter;

@Component
public class AppController implements CommandLineRunner {
    private final UserService userService;
    private final GameService gameService;

    @Autowired
    public AppController(UserService userService, GameService gameService) {
        this.userService = userService;
        this.gameService = gameService;
    }

    @Override
    public void run(String... args) throws Exception {
        BufferedReader reader = new BufferedReader(new InputStreamReader(System.in));
        String input; // = reader.readLine();

        while (!(input = reader.readLine()).equals("")) {
            String[] tokens = input.split("\\|");

            String command = tokens[0];
            switch (command) {
                //-------------------USER--------------------
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
                case "BuyGame":
                    System.out.println(this.userService.buyGame(tokens[1]));
                    break;
                case "OwnedGames":
                    this.userService.getOwnedGames().forEach(System.out::println);
                    break;
                //-------------------Game--------------------
                case "AddGame":
                    //LocalDate date = LocalDate.parse(tokens[tokens.length - 1], DateTimeFormatter.ofPattern("dd-MM-yyyy"));
                    AddGameDto gameDto = new AddGameDto(
                            tokens[1],
                            new BigDecimal(tokens[2]),
                            Double.parseDouble(tokens[3]),
                            tokens[4],
                            tokens[5],
                            tokens[6],
                            LocalDate.parse(tokens[tokens.length - 1], DateTimeFormatter.ofPattern("dd-MM-yyyy"))
                    );
                    System.out.println(this.gameService.addGame(gameDto));
                    break;
                case "EditGame":
                    BigDecimal price = new BigDecimal(tokens[2].substring(tokens[2].indexOf("=") + 1));
                    double size = Double.parseDouble(tokens[3].substring(tokens[3].indexOf("=") + 1));
                    EditGameDto editGameDto = new EditGameDto(price, size);
                    System.out.println(this.gameService.editGame(Long.parseLong(tokens[1]), editGameDto));
                    break;
                case "DeleteGame":
                    System.out.println(this.gameService.deleteGame(Long.parseLong(tokens[1])));
                    break;
                //-------------------View Games--------------------
                case "AllGames":
                    this.gameService.getAllGames()
                            .forEach(System.out::println);
                    break;
                case "DetailGame":
                    System.out.println(this.gameService.getGameDetails(tokens[1]));
                    break;
            }
        }
    }
}
