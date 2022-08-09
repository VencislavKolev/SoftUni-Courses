function pieceOfPie(flavorArr, start, end) {
    let result = [];
    for (const flavor of flavorArr) {
        if (flavor === start) {
            result.push(flavor);
            continue;
        }
        if (flavor === end) {
            result.push(flavor);
            break;
        }
        if (result.length > 0) {
            result.push(flavor);
        }
    }
    console.log(result);
}

pieceOfPie(['Pumpkin Pie',
    'Key Lime Pie',
    'Cherry Pie',
    'Lemon Meringue Pie',
    'Sugar Cream Pie'],
    'Key Lime Pie',
    'Lemon Meringue Pie'
)

pieceOfPie(['Apple Crisp',
    'Mississippi Mud Pie',
    'Pot Pie',
    'Steak and Cheese Pie',
    'Butter Chicken Pie',
    'Smoked Fish Pie'],
    'Pot Pie',
    'Smoked Fish Pie'
)