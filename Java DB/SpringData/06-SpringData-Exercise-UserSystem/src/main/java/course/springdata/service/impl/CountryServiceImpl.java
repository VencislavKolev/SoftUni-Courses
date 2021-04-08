package course.springdata.service.impl;

import course.springdata.entity.Country;
import course.springdata.repository.CountryRepository;
import course.springdata.service.CountryService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.util.List;
import java.util.Set;

@Service
public class CountryServiceImpl implements CountryService {

    private CountryRepository countryRepo;

    @Autowired
    public CountryServiceImpl(CountryRepository countryRepo) {
        this.countryRepo = countryRepo;
    }

    @Override
    public void seedCountries() {
        Set<Country> countries = Set.of(
                new Country("Bulgaria"),
                new Country("USA"),
                new Country("United Kingdom")
        );
        this.countryRepo.saveAll(countries);

    }

    @Override
    public List<Country> getAllCoutries() {
        return this.countryRepo.findAll();
    }

    @Override
    public Country findCountryByName(String countryName) {
        return this.countryRepo.findCountryByNameEquals(countryName);
    }
}
