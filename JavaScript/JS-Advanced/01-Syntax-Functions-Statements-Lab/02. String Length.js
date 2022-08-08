function stringLength(one, two, three) {
    let sum = one.length + two.length + three.length
    let average = Math.floor(sum / 3)
    console.log(sum);
    console.log(average);
}

stringLength('chocolate', 'ice cream', 'cake')