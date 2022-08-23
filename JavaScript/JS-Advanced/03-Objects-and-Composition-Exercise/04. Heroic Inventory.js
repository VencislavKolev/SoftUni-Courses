function solve(inputArr) {
    const heroes = [];
    for (const input of inputArr) {
        const [name, level, items] = input.split(' / ');
        const hero = {
            name,
            level: Number(level),
            items: items ? items.split(', ') : []
        };
        heroes.push(hero)
    }
    console.log(JSON.stringify(heroes));
}

solve(['Isacc / 25 / Apple, GravityGun',
    'Derek / 12 / BarrelVest, DestructionSword',
    'Hes / 1 / Desolator, Sentinel, Antara'])