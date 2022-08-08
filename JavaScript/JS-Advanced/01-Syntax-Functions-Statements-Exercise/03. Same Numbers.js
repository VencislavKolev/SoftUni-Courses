function sameNumbers(number) {
    let isSame = true;
    let str = number.toString();
    let toCompare = str[0];
    let sum = 0;
    for (let i = 0; i < str.length; i++) {
        let current = str[i];
        if (current !== toCompare) {
            isSame = false;
        }
        sum += Number(current);
    }
    console.log(isSame);
    console.log(sum);
}

sameNumbers(2222222)
sameNumbers(1234)