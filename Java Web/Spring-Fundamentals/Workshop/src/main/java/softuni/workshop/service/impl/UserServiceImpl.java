package softuni.workshop.service.impl;

import org.modelmapper.ModelMapper;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;
import softuni.workshop.model.entity.User;
import softuni.workshop.model.service.UserServiceModel;
import softuni.workshop.repositoy.UserRepository;
import softuni.workshop.service.RoleService;
import softuni.workshop.service.UserService;

@Service
public class UserServiceImpl implements UserService {
    private final UserRepository userRepo;
    private final RoleService roleService;
    private final ModelMapper modelMapper;

    @Autowired
    public UserServiceImpl(UserRepository userRepo, RoleService roleService, ModelMapper modelMapper) {
        this.userRepo = userRepo;
        this.roleService = roleService;
        this.modelMapper = modelMapper;
    }

    @Override
    public UserServiceModel registerUser(UserServiceModel model) {
        model.setRole(this.roleService
                .findByName(this.userRepo.count() == 0
                        ? "ADMIN" : "USER"));

        User user = this.modelMapper.map(model, User.class);

        return this.modelMapper.map(this.userRepo.saveAndFlush(user), UserServiceModel.class);
    }
}
