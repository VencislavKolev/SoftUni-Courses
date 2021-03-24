//package course.springdata.controllers;
//
//import course.springdata.entity.User;
//import course.springdata.service.UserService;
//import org.springframework.beans.factory.annotation.Autowired;
//import org.springframework.http.HttpStatus;
//import org.springframework.http.ResponseEntity;
//import org.springframework.web.bind.annotation.PostMapping;
//import org.springframework.web.bind.annotation.RequestBody;
//import org.springframework.web.bind.annotation.RequestMapping;
//import org.springframework.web.bind.annotation.RestController;
//
//import javax.validation.Valid;
//
//
//@RestController
//@RequestMapping(value = "api/user/")
//public class UserController {
//
//    private UserService userService;
//
//    @Autowired
//    public UserController(UserService userService) {
//        this.userService = userService;
//    }
//
//    @PostMapping("register")
//    public ResponseEntity<User> createUser(@Valid @RequestBody User user) {
//        User toSave = this.userService.registerUser(user);
//        return new ResponseEntity<>(toSave, HttpStatus.CREATED);
//    }
//}
