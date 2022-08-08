function wordsUppercase(input) {
    const re = /\w+/g;
    let words = input.match(re);

    const upper = words.map(word => {
        return word.toUpperCase();
    })
    console.log(upper.join(', '));
}

wordsUppercase('Hi, how are you?')