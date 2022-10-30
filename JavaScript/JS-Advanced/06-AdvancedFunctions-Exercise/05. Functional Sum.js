function add(a) {
    let curry = (b) => {
        a += b
        return curry
    }
    curry.toString = () => a
    return curry
}

console.log(+add(1))
console.log(+add(1)(6)(-3));