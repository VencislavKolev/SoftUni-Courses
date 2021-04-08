package course.springdata.service;

import course.springdata.entity.Town;

import java.util.List;

public interface TownService {
    List<Town> getAllTowns();
    void seedTowns();
}
