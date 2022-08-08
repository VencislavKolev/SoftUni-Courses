function squareOfStars(number = 5) {
    let char = '* '
    for (let i = 0; i < number; i++) {
        console.log(char.repeat(number));
    }
}

squareOfStars(2)