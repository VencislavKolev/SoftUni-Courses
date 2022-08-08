function largestNumber(first, second, third) {
    let largestNumber = first;
    if (largestNumber < second) {
        largestNumber = second
    }
    if (largestNumber < third) {
        largestNumber = third
    }
    console.log(`The largest number is ${largestNumber}.`);
}

largestNumber(5, -3, 16)