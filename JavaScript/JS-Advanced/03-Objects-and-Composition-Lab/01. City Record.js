function cityTaxes(name, population, treasury) {
    const cityV1 = {
        name: name,
        population: Number(population),
        treasury: Number(treasury),
    }

    const cityV2 = { name, population, treasury }

    const cityV3 = {}
    city.name = name;
    city.population = population;
    city.treasury = treasury;

    return cityV1;
}

cityTaxes('Tortuga', 7000, 15000);