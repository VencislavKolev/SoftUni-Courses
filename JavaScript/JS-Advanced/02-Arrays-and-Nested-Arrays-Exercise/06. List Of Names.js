function sortNames(input) {
    // input.sort((a, b) => a[0].localeCompare(b[0]));
    input.sort();
    let i = 1;
    for (const name of input) {
        console.log(`${i++}.${name}`);
    }
}

// sortNames(["John", "Bob", "Christina", "Ema"])
sortNames(["Bob", "Boa", "Christina", "Ema"])