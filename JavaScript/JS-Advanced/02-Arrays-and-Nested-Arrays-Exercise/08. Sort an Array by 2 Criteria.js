function sortByTwoCriteria(input) {
    input.sort((a, b) => {
        if (a.length > b.length) return 1;
        if (a.length < b.length) return -1;

        return a.localeCompare(b);
    })
    input.forEach(x => console.log(x));
}

sortByTwoCriteria(['alpha', 'beta', 'gamma'])
sortByTwoCriteria(['test', 'Deny', 'omen', 'Default'])
sortByTwoCriteria(['Isacc', 'Theodor', 'Jack', 'Harrison', 'George'])