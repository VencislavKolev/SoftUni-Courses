const { expect } = require('chai')
function isSymmetric(arr) {
    if (!Array.isArray(arr)){
        return false; // Non-arrays are non-symmetric
    }
    let reversed = arr.slice(0).reverse(); // Clone and reverse
    let equal = (JSON.stringify(arr) == JSON.stringify(reversed));
    return equal;
}

describe("Test symmetry", () => {
    
    it('Should be symmetric', () => {
        expect(isSymmetric([1, 2, 1])).to.be.true;
    })
    it('Should not be symmetric', () => {
        expect(isSymmetric([1, 2, 3])).to.be.false;
    })
    it('Should be false when not an array', () => {
        expect(isSymmetric({})).to.be.false;
        expect(isSymmetric('')).to.be.false;
        expect(isSymmetric(null)).to.be.false;
        expect(isSymmetric(undefined)).to.be.false;
        expect(isSymmetric(5)).to.be.false;
    })
})