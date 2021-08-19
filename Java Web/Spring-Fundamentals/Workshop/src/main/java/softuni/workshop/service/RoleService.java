package softuni.workshop.service;

import softuni.workshop.model.service.RoleServiceModel;

public interface RoleService {
    RoleServiceModel findByName(String name);
}
