function buyFruit(fruit, weight, pricePerKg) {
    let weightKg = weight / 1000;
    let money = weightKg * pricePerKg;
    console.log(`I need $${money.toFixed(2)} to buy ${weightKg.toFixed(2)} kilograms ${fruit}.`);
}

buyFruit('orange', 2500, 1.80)