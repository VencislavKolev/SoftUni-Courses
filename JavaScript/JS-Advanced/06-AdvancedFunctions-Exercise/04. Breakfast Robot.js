function solution() {
    let stock = {
        carbohydrate: 0,
        flavour: 0,
        fat: 0,
        protein: 0
    }

    const recipes = {
        'apple': (qty) => {
            if (stock.carbohydrate - 1 * qty < 0) return 'carbohydrate';
            if (stock.flavour - 2 * qty < 0) return 'flavour';
            stock.carbohydrate -= 1 * qty;
            stock.flavour -= 2 * qty;
            return 'Success'
        },
        'lemonade': (qty) => {
            if (stock.carbohydrate - 10 * qty < 0) return 'carbohydrate';
            if (stock.flavour - 20 * qty < 0) return 'flavour';
            stock.carbohydrate -= 10 * qty;
            stock.flavour -= 20 * qty;
            return 'Success';
        },
        'burger': (qty) => {
            if (stock.carbohydrate - 5 * qty < 0) return 'carbohydrate';
            if (stock.fat - 7 * qty < 0) return 'fat';
            if (stock.flavour - 3 * qty < 0) return 'flavour';
            stock.carbohydrate -= 5 * qty;
            stock.fat -= 7 * qty;
            stock.flavour -= 3 * qty;
            return 'Success';
        },
        'eggs': (qty) => {
            if (stock.protein - 5 * qty < 0) return 'protein';
            if (stock.fat - 1 * qty < 0) return 'fat';
            if (stock.flavour - 1 * qty < 0) return 'flavour';
            stock.protein -= 5 * qty;
            stock.fat -= 1 * qty;
            stock.flavour -= 1 * qty;
            return 'Success';
        },
        'turkey': (qty) => {
            if (stock.protein - 10 * qty < 0) return 'protein';
            if (stock.carbohydrate - 10 * qty < 0) return 'carbohydrate';
            if (stock.fat - 10 * qty < 0) return 'fat';
            if (stock.flavour - 10 * qty < 0) return 'flavour';
            stock.protein -= 10 * qty;
            stock.carbohydrate -= 10 * qty;
            stock.fat -= 10 * qty;
            stock.flavour -= 10 * qty;
            return 'Success';
        },
    };

    return function (instructions) {
        let [action, ingredient, quantity] = instructions.split(' ');
        switch (action) {
            case 'restock':
                stock[ingredient] += Number(quantity)
                return 'Success';
            case 'prepare':
                let message = recipes[ingredient](quantity);
                return (message === 'Success') ? 'Success' : `Error: not enough ${message} in stock`;
            case 'report':
                return `protein=${stock.protein} carbohydrate=${stock.carbohydrate} fat=${stock.fat} flavour=${stock.flavour}`;
            default:
                break;
        }
    }
}

let manager = solution();
console.log(manager("restock flavour 50"));  // Success
console.log(manager("prepare lemonade 4"));  // Error: not enough carbohydrate in stock

console.log(manager("restock carbohydrate 10")); // Success
console.log(manager("restock flavour 10"));  // Success
console.log(manager("prepare apple 1")); // Success
console.log(manager("restock fat 10"));  // Success
console.log(manager("prepare burger 1"));  // Success
console.log(manager("report"));  // protein=0 carbohydrate=4 fat=3 flavour=5

console.log(manager("prepare turkey 1"));  // Error: not enough protein in stock
console.log(manager("restock protein 10"));  // Success
console.log(manager("prepare turkey 1"));  // Error: not enough carbohydrate in stock
console.log(manager("restock carbohydrate 10")); // Success
console.log(manager("prepare turkey 1"));  // Error: not enough fat in stock
console.log(manager("restock fat 10"));  // Success
console.log(manager("prepare turkey 1"));  // Error: not enough flavour in stock
console.log(manager("restock flavour 10"));  // Success
console.log(manager("prepare turkey 1"));  // Success
console.log(manager("report"));  // pr)otein=0 carbohydrate=0 fat=0 flavour=0