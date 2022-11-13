function solve() {
    let result = {}
    Array.from(arguments)
        .forEach(arg => {
            let type = typeof (arg);
            console.log(`${type}: ${arg}`);

            if (!result[type]) {
                result[type] = 0;
            }
            result[type]++;
        });

    Object.keys(result)
        .sort((a, b) => result[b] - result[a])
        .forEach(key => console.log(`${key} = ${result[key]}`));

    // for (let i = 0; i < params.length; i++) {
    //     let type = typeof (params[i])
    //     if (result[type]) {
    //         result[type]++;
    //     }
    //     else {
    //         result[type] = 1;
    //     }
    //     console.log(`${type}: ${params[i]}`);
    // }
    // result = Object.fromEntries(Object.entries(result).sort((a, b) => result[b] - result[a]));
    // for (const type in result) {
    //     const count = result[type];
    //     console.log(`${type} = ${count}`);
    // }
}

solve('cat', 42, function () { console.log('Hello world!'); })