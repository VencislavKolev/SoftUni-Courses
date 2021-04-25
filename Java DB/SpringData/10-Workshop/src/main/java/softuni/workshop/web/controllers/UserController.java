package softuni.workshop.web.controllers;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Controller;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.servlet.ModelAndView;
import softuni.workshop.service.services.UserService;
import softuni.workshop.web.models.UserRegisterModel;

@Controller
@RequestMapping(path = "/users")
public class UserController extends BaseController {

    private final UserService userService;

    @Autowired
    public UserController(UserService userService) {
        this.userService = userService;
    }

    @GetMapping(path = "/register")
    public ModelAndView register() {
        return new ModelAndView("user/register");
    }

    @PostMapping(path = "register")
    public ModelAndView registerConfirm(UserRegisterModel userRegisterModel) {
        if (!userRegisterModel.getPassword().equals(userRegisterModel.getConfirmPassword())) {
            return super.redirect("users/register");
        }
        this.userService.registerUser(userRegisterModel);
        return super.redirect("/login");
    }

    @GetMapping(path = "/login")
    public ModelAndView login() {
        return new ModelAndView("user/login");
    }
}
