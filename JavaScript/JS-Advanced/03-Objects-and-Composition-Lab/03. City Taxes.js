function cityTaxes(name, population, treasury) {
    const city = {
        name,
        population,
        treasury,
        taxRate: 10,
        collectTaxes: function () {
            this.treasury += population * this.taxRate
        },
        applyGrowth: function (percentage) {
            this.population *= (1 + percentage / 100)
        },
        applyRecession: function (percentage) {
            this.treasury *= (1 - percentage / 100)
        }
    };
    return city;
}

const city = cityTaxes('Tortuga', 7000, 15000);

city.collectTaxes();
console.log(city.treasury);

city.applyGrowth(10);
console.log(city.population);

city.applyRecession(50);
console.log(city.treasury);