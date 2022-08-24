function solve(inputArr) {
    const products = [];

    for (const line of inputArr) {
        let [town, item, price] = line.split(' | ');
        const product = { town, item, price: Number(price) };

        let exists = products.find(p => p.item === product.item);
        if (exists == undefined) {
            products.push(product);
        } else if (exists.price > product.price) {
            products.splice(products.indexOf(exists), 1, product);
        }
    }
    products.forEach(p => console.log(`${p.item} -> ${p.price} (${p.town})`));
}

solve(['Sample Town | Sample Product | 1000',
    'Sample Town | Orange | 2',
    'Sample Town | Peach | 1',
    'Sofia | Orange | 1',
    'Sofia | Peach | 2',
    'New York | Sample Product | 1000.1',
    'New York | Burger | 10'])