function calculator() {
    let a;
    let b;
    let result;

    return {
        init: (selector1, selector2, resultSelector) => {
            a = document.querySelector(selector1);
            b = document.querySelector(selector2);
            result = document.querySelector(resultSelector);
        },
        add: () => {
            result.value = Number(a.value) + Number(b.value);
        },
        subtract: () => {
            result.value = Number(a.value) - Number(b.value);
        }
    }
}

const calculate = calculator();
calculate.init('#num1', '#num2', '#result');