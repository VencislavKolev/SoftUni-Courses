function solve(input) {
    const carriages = {
        Hatchback: { type: 'hatchback', color: null },
        Coupe: { type: 'coupe', color: null }
    }
    const engines = {
        small: { power: 90, volume: 1800 },
        normal: { power: 120, volume: 2400 },
        monster: { power: 200, volume: 3500 },
    }

    const { model, power, color, carriage, wheelsize } = input;
    const engine = getEngine(power);
    const chassis = constructChassis(carriage, color);
    const wheels = getWheels(wheelsize);

    const car = {
        model: model,
        engine: engine,
        carriage: chassis,
        wheels: wheels
    };

    return car;

    function getEngine(power) {
        if (power <= 90) {
            return engines.small;
        } else if (power <= 120) {
            return engines.normal
        } else {
            return engines.monster;
        }
    }

    function constructChassis(carriage, color) {
        let chassis = {};
        switch (carriage) {
            case 'hatchback':
                chassis = carriages.Hatchback;
                break;
            case 'coupe':
                chassis = carriages.Coupe;
                break;
        }
        chassis.color = color
        return chassis;
    }

    function getWheels(wheelSize) {
        if (wheelSize % 2 == 0) {
            wheelSize--;
        }
        return new Array(4).fill(wheelSize)
    }
}

solve({
    model: 'VW Golf II',
    power: 90,
    color: 'blue',
    carriage: 'hatchback',
    wheelsize: 14
})