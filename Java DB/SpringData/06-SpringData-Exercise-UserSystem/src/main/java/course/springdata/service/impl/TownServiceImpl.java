package course.springdata.service.impl;

import course.springdata.entity.Country;
import course.springdata.entity.Town;
import course.springdata.repository.TownRepository;
import course.springdata.service.CountryService;
import course.springdata.service.TownService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.util.List;
import java.util.Set;

@Service
public class TownServiceImpl implements TownService {

    private final TownRepository townRepo;
    private final CountryService countryService;

    @Autowired
    public TownServiceImpl(TownRepository townRepo, CountryService countryService) {
        this.townRepo = townRepo;
        this.countryService = countryService;
    }

    @Override
    public List<Town> getAllTowns() {
        return this.townRepo.findAll();
    }

    @Override
    public void seedTowns() {
        Set<Town> towns = Set.of(
                new Town("Sofia"),
                new Town("Burgas"),
                new Town("Veliko Tarnovo"),
                new Town("Varna")
        );

        Country country = this.countryService.findCountryByName("Bulgaria");

        towns.forEach(t -> t.setCountry(country));

        this.townRepo.saveAll(towns);
    }
}
