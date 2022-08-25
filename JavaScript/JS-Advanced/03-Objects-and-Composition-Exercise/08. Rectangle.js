function createRectangle(width, height, color) {
    
    function capitalizeFirstLetter(color) {
        const capitalized = color.charAt(0).toUpperCase() + color.slice(1);
        return capitalized;
    }
    const capitalized = capitalizeFirstLetter(color);
    return {
        width, height, color: capitalized,
        calcArea: function () { return width * height }
    }
}

let rect = createRectangle(4, 5, 'red');
console.log(rect.width);
console.log(rect.height);
console.log(rect.color);
console.log(rect.calcArea());