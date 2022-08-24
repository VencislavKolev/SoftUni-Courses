function solve(inputArr) {
    inputArr.shift();

    class Town {
        constructor(name, latitude, longitude) {
            this.Town = name,
                this.Latitude = Number(latitude),
                this.Longitude = Number(longitude)
        }
    }
    const towns = [];
    for (let line of inputArr) {
        line = line.split('|').filter(e => e !== "").map(e => e.trim());

        let townName = line[0];
        let latitude = Number(line[1]).toFixed(2);
        let longitude = Number(line[2]).toFixed(2)
        const town = new Town(townName, latitude, longitude)
        towns.push(town);
    }
    console.log(JSON.stringify(towns));
}

solve(['| Town | Latitude | Longitude |',
    '| Sofia | 42.696552 | 23.32601 |',
    '| Beijing | 39.913818 | 116.363625 |'])