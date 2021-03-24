package course.springdata.controllers;

import course.springdata.entity.User;
import course.springdata.service.UserService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.CommandLineRunner;
import org.springframework.stereotype.Controller;

import java.util.HashSet;
import java.util.Random;
import java.util.Set;

@Controller
public class AppController implements CommandLineRunner {
    private UserService userService;

    @Autowired
    public AppController(UserService userService) {
        this.userService = userService;
    }

    @Override
    public void run(String... args) throws Exception {

        User user = new User("Vencipoto", "Pass-123", "venci362@gmail.com", 23, "Ven", "Ko");
        Set<User> colleagues = this.generateUsers();
        user.setColleagues(colleagues);
        this.userService.registerUser(user);


        User user2 = new User("RyanVillopoto", "Pass-321", "rvillopoto@gmail.com", 32);
        this.userService.registerUser(user2);
        user2.setColleagues(Set.of(user));

//        User user2 = new User("venci2", "Pass-123", "venci362@gmail.com", 24, "Vencislav", "Kolev");
//        this.userService.registerUser(user);
//        this.userService.registerUser(user2);
//
        this.userService.getAllUsers()
                .forEach(System.out::println);

        this.getUsersWithEmailPattern();
    }

    private void getUsersWithEmailPattern() {
        var users = this.userService.getUsersEndingWith("gmail.com");
        users.forEach(u -> {
            System.out.printf("username: %s, email: %s%n",
                    u.getUsername(), u.getEmail());
        });
    }

    private Set<User> generateUsers() {
        Set<User> colleagues = new HashSet<>();

        Random random = new Random();

        for (int i = 0; i < 3; i++) {
            int age = random.nextInt((120) + 1);
            String randomFirstName = this.generateName();
            String randomLastName = this.generateName();

            colleagues.add(new User("Venci" + i, "Pass-" + i, "venci" + i + "@gmail.com", age, randomFirstName, randomLastName));
        }
        return colleagues;
    }

    private String generateName() {
        int leftLimit = 97; // letter 'a'
        int rightLimit = 122; // letter 'z'
        int targetStringLength = 5;
        Random random = new Random();

        String generatedString = random.ints(leftLimit, rightLimit + 1)
                .limit(targetStringLength)
                .collect(StringBuilder::new, StringBuilder::appendCodePoint, StringBuilder::append)
                .toString();

        return generatedString;
    }
}
