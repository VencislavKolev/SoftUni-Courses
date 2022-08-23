function solve(inputArr) {
    const food = {};
    for (let i = 0; i < inputArr.length; i += 2) {
        const foodName = inputArr[i];
        const caloriesPer100Grams = Number(inputArr[i + 1]);
        food[foodName] = caloriesPer100Grams;
    }
    console.log(food);
}

solve(['Yoghurt', '48', 'Rise', '138', 'Apple', '52'])
solve(['Potato', '93', 'Skyr', '63', 'Cucumber', '18', 'Milk', '42'])