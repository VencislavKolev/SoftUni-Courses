package softuni.workshop.web;

import org.modelmapper.ModelMapper;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Controller;
import org.springframework.validation.BindingResult;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.ModelAttribute;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.servlet.ModelAndView;
import softuni.workshop.model.binding.UserAdd;
import softuni.workshop.model.binding.UserLogin;
import softuni.workshop.model.service.UserServiceModel;
import softuni.workshop.service.UserService;

import javax.servlet.http.HttpSession;
import javax.validation.Valid;

@Controller
@RequestMapping(path = "/users")
public class UserController {

    private final UserService userService;
    private final ModelMapper modelMapper;

    @Autowired
    public UserController(UserService userService, ModelMapper modelMapper) {
        this.userService = userService;
        this.modelMapper = modelMapper;
    }

    @GetMapping(path = "/login")
    public String login() {
        return "login";
    }

    @PostMapping(path = "/login")
    public ModelAndView loginConfirm(@Valid @ModelAttribute("userLogin")
                                             UserLogin userLogin,
                                     BindingResult bindingResult, ModelAndView modelAndView,
                                     HttpSession httpSession) {

        if (bindingResult.hasErrors()) {
            modelAndView.setViewName("redirect:/users/login");
        } else {
            modelAndView.setViewName("redirect:/");
        }

        //TODO userService login method
        httpSession.setAttribute("user", "userServiceModel");
        return modelAndView;
    }

    @GetMapping(path = "/register")
    public String register() {
        return "register";
    }

    @PostMapping(path = "/register")
    public ModelAndView registerConfirm(@Valid @ModelAttribute("userAddBindingModel")
                                                UserAdd userAddBindingModel,
                                        BindingResult bindingResult, ModelAndView modelAndView) {
        if (bindingResult.hasErrors()) {
            //TODO validations msg
            modelAndView.setViewName("redirect:/users/register");
        } else {
            UserServiceModel userServiceModel = this.userService
                    .registerUser(this.modelMapper.map(userAddBindingModel, UserServiceModel.class));
            modelAndView.setViewName("redirect:/users/login");
        }
        return modelAndView;
    }
}
