function solve(commands) {
    let number = 1;
    let arr = [];

    for (const command of commands) {
        switch (command) {
            case 'add': arr.push(number); break;
            case 'remove': arr.pop(); break;
        }
        number++;
    }
    if (arr.length > 0) {
        arr.forEach((x) => console.log(x));
    } else {
        console.log('Empty');
    }
}

solve(['add', 'add', 'remove', 'add', 'add'])

solve(['remove', 'remove', 'remove'])