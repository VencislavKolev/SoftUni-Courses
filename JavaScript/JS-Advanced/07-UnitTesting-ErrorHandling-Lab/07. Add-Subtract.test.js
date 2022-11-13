const { expect } = require('chai')

function createCalculator() {
    let value = 0;
    return {
        add: function (num) { value += Number(num); },
        subtract: function (num) { value -= Number(num); },
        get: function () { return value; }
    }
}

describe("Test Add / Subtract", () => {
    it('Should return correct sum when adding', () => {
        const calculator = createCalculator();

        calculator.add(5);
        expect(calculator.get()).to.equal(5);
        calculator.add('5');
        expect(calculator.get()).to.equal(10);
    })
    it('Should return correct sum when subtracting', () => {
        const calculator = createCalculator();

        calculator.subtract(5)
        expect(calculator.get()).to.equal(-5);
        calculator.subtract('5')
        expect(calculator.get()).to.equal(-10);
    })
})