const { expect } = require('chai')
const sum = require('./04. Sum of Numbers')

describe("Test sum of numbers", () => {
    it('Should be correct', () => {
        expect(sum([1, 2])).to.equal(3);
    })
    it('Should return zero', () => {
        expect(sum([10, -10])).to.equal(0);
    })
})