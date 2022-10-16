function attachEventsListeners() {
    let convertBtn = document.getElementById('convert');

    convertBtn.addEventListener('click', convertEventHandler);

    function convertEventHandler(e) {
        let value = Number(e.target.parentElement.children[1].value);
        let fromUnit = e.target.parentElement.children[2].selectedIndex;
        let toUnit = document.getElementById('outputUnits').selectedIndex;
        let outputDistanceElement = document.getElementById('outputDistance');

        outputDistanceElement.value = convertMetersToTargetUnit(convertInputToMeters(value, fromUnit), toUnit);
    }

    function convertInputToMeters(value, unitIndex) {
        let meters;
        switch (unitIndex) {
            case 0: meters = value * 1000; break;
            case 1: meters = value * 1; break;
            case 2: meters = value * 0.01; break;
            case 3: meters = value * 0.001; break;
            case 4: meters = value * 1609.34; break;
            case 5: meters = value * 0.9144; break;
            case 6: meters = value * 0.3048; break;
            case 7: meters = value * 0.0254; break;
            default: console.error('Invalid unit.'); break;
        }
        return meters;
    }
    function convertMetersToTargetUnit(meters, unitIndex) {
        let targetValue;
        switch (unitIndex) {
            case 0: targetValue = meters / 1000; break;
            case 1: targetValue = meters / 1; break;
            case 2: targetValue = meters / 0.01; break;
            case 3: targetValue = meters / 0.001; break;
            case 4: targetValue = meters / 1609.34; break;
            case 5: targetValue = meters / 0.9144; break;
            case 6: targetValue = meters / 0.3048; break;
            case 7: targetValue = meters / 0.0254; break;
            default: console.error('Invalid unit.'); break;
        }
        return targetValue;
    }
}