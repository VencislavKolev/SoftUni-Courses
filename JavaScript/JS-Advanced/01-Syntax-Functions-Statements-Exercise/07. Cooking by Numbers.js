function cookingNumber(num, op1, op2, op3, op4, op5) {
    let number = Number(num);
    let operations = [op1, op2, op3, op4, op5];

    for (const operation of operations.values()) {
        switch (operation) {
            case 'chop': number /= 2;
                break;
            case 'dice': number = Math.sqrt(number);
                break;
            case 'spice': number += 1;
                break;
            case 'bake': number *= 3;
                break;
            case 'fillet': number -= (number * 0.2);
                break;
        }
        console.log(number);
    }
}

// cookingNumber('32', 'chop', 'chop', 'chop', 'chop', 'chop')
cookingNumber('9', 'dice', 'spice', 'chop', 'bake', 'fillet')