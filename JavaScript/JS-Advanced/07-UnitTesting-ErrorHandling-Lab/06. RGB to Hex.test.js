const { expect } = require('chai')

function rgbToHexColor(red, green, blue) {
    if (!Number.isInteger(red) || (red < 0) || (red > 255)) {
        return undefined; // Red value is invalid
    }
    if (!Number.isInteger(green) || (green < 0) || (green > 255)) {
        return undefined; // Green value is invalid
    }
    if (!Number.isInteger(blue) || (blue < 0) || (blue > 255)) {
        return undefined; // Blue value is invalid
    }
    return "#" +
        ("0" + red.toString(16).toUpperCase()).slice(-2) +
        ("0" + green.toString(16).toUpperCase()).slice(-2) +
        ("0" + blue.toString(16).toUpperCase()).slice(-2);
}

describe("Test RGB to HEX", () => {

    it('Should be undefined when color is out of bounds', () => {
        expect(rgbToHexColor(-1, 1, 1)).to.be.undefined;
        expect(rgbToHexColor(1, -1, 1)).to.be.undefined;
        expect(rgbToHexColor(1, 1, -1)).to.be.undefined;

        expect(rgbToHexColor('red', 1, -1)).to.be.undefined;
        expect(rgbToHexColor(1, 'green', -1)).to.be.undefined;
        expect(rgbToHexColor(1, 1, 'blue')).to.be.undefined;
    })
    it('Should return correct HEX value', () => {
        expect(rgbToHexColor(255, 255, 255)).to.equal('#FFFFFF');
    })
})