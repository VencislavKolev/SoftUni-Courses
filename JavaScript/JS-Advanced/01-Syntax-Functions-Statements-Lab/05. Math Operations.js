function mathOperation(num1, num2, operator) {
    let result;
    // if (operator === '+') {
    //     result = num1 + num2;
    // } else if (operator === '-') {
    //     result = num1 - num2;
    // } else if (operator === '*') {
    //     result = num1 * num2;
    // } else if (operator === '/') {
    //     result = num1 / num2;
    // } else if (operator === '%') {
    //     result = num1 % num2;
    // } else if (operator === '**') {
    //     result = num1 ** num2;
    // }
    switch(operator) {
        case '+': result = num1 + num2; break;
        case '-': result = num1 - num2; break;
        case '*': result = num1 * num2; break;
        case '/': result = num1 / num2; break;
        case '%': result = num1 % num2; break;
        case '**': result = num1 ** num2; break;
    }
    console.log(result);
}

mathOperation(3, 5.5, '*')