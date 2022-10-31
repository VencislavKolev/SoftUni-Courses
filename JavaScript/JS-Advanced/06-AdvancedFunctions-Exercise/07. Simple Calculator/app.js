function calculator() {
    let selector1Element;
    let selector2Element;
    let resultElement;

    return {
        init: (selector1, selector2, resultSelector) => {
            selector1Element = selector1;
            selector2Element = selector2;
            resultElement = resultSelector;
        },
        add: () => {
            document.querySelector(resultElement).value = Number(document.querySelector(selector1Element).value) + Number(document.querySelector(selector2Element).value);
        },
        subtract: () => {
            document.querySelector(resultElement).value = Number(document.querySelector(selector1Element).value) - Number(document.querySelector(selector2Element).value);
        }
    }
}

const calculate = calculator();
calculate.init('#num1', '#num2', '#result');