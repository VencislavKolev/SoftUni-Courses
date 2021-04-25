package softuni.workshop.service.services.impl;

import org.modelmapper.ModelMapper;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;
import org.springframework.ui.ModelMap;
import softuni.workshop.data.entities.Role;
import softuni.workshop.data.repositories.RoleRepository;
import softuni.workshop.service.models.RoleServiceModel;
import softuni.workshop.service.services.RoleService;

import java.util.Set;
import java.util.stream.Collectors;

@Service
public class RoleServiceImpl implements RoleService {

    private final RoleRepository roleRepo;
    private final ModelMapper modelMapper;

    @Autowired
    public RoleServiceImpl(RoleRepository roleRepo, ModelMapper modelMapper) {
        this.roleRepo = roleRepo;
        this.modelMapper = modelMapper;
    }

    @Override
    public void seedRolesInDb() {
        Set<Role> roles = Set.of(
                new Role("ADMIN"),
                new Role("USER")
        );
//        Role admin = new Role("ADMIN");
//        Role user = new Role("USER");
//        this.roleRepo.saveAndFlush(admin);
//        this.roleRepo.saveAndFlush(user);
        this.roleRepo.saveAll(roles);
    }

    @Override
    public Set<RoleServiceModel> findAllRoles() {
        return this.roleRepo.findAll()
                .stream()
                .map(x -> this.modelMapper.map(x, RoleServiceModel.class))
                .collect(Collectors.toSet());
    }

    @Override
    public RoleServiceModel findByAuthority(String role) {
        return this.modelMapper.map(this.roleRepo.findByAuthority(role), RoleServiceModel.class);
    }
}
