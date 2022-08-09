function evenPosition(input) {
    let evenArr = [];
    for (let i = 0; i < input.length; i+=2) {
        const element = input[i];
        evenArr.push(element);
    }
    console.log(evenArr.join(' ').trimEnd());
}

evenPosition(['5, 10'])
evenPosition(['20', '30', '40', '50', '60'])