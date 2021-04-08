package course.springdata.service;

import course.springdata.entity.Country;

import java.util.List;

public interface CountryService {
    void seedCountries();
    List<Country> getAllCoutries();
    Country findCountryByName(String countryName);
}
