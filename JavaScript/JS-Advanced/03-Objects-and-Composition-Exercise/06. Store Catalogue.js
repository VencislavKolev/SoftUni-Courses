function solve(inputArr) {
    const catalog = [];

    for (let input of inputArr) {
        input = input.split(' : ');
        const product = { name: input[0], price: Number(input[1]) }
        catalog.push(product);
    }

    catalog.sort((a, b) => a.name.localeCompare(b.name));

    let letter = '';
    for (const product of catalog) {
        if (letter != product.name[0]) {
            letter = product.name[0];
            console.log(letter);
        }
        console.log(`  ${product.name}: ${product.price}`);
    }
}

solve(['Appricot : 20.4',
    'Fridge : 1500',
    'TV : 1499',
    'Deodorant : 10',
    'Boiler : 300',
    'Apple : 1.25',
    'Anti-Bug Spray : 15',
    'T-Shirt : 10'])