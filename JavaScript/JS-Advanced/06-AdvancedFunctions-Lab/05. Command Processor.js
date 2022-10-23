function solution() {
    let result = '';
    return {
        append: function (value) {
            result += value;
        },
        removeStart: function (value) {
            result = result.substring(value);
        },
        removeEnd: function (value) {
            result = result.substring(0, result.length - value);
        },
        print: function () {
            console.log(result);
        }
    }
}

let firstZeroTest = solution();

firstZeroTest.append('hello');
firstZeroTest.append('again');
firstZeroTest.removeStart(3);
firstZeroTest.removeEnd(4);
firstZeroTest.print();