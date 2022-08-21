function cityTaxes(inputArr) {
    let towns = {};
    for (const input of inputArr) {
        const line = input.split(' <-> ');
        let name = line[0];
        let population = Number(line[1]);
        if (!towns[name]) {
            towns[name] = 0;
        }
        towns[name] += population;
    }

    // for (const key in towns) {
    //     console.log(`${key} : ${towns[key]}`);
    // }

    // Object.keys(towns).forEach(key => {
    //     console.log(`${key} : ${towns[key]}`);
    // })

    for (const [name, population] of Object.entries(towns)) {
        console.log(`${name} : ${population}`);
    }
}

// solve(['Sofia <-> 1200000',
//     'Montana <-> 20000',
//     'New York <-> 10000000',
//     'Washington <-> 2345000',
//     'Las Vegas <-> 1000000']
// )

cityTaxes(['Istanbul <-> 100000',
    'Honk Kong <-> 2100004',
    'Jerusalem <-> 2352344',
    'Mexico City <-> 23401925',
    'Istanbul <-> 1000']
)