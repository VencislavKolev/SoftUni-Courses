function attachGradientEvents() {
    let gradientElement = document.getElementById('gradient');
    let resultElement = document.getElementById('result');

    gradientElement.addEventListener('mousemove', gradientMove);
    gradientElement.addEventListener('mouseout', gradientOut);

    function gradientMove(event) {
        let percentage = Math.floor((event.offsetX / event.target.clientWidth) * 100);
        resultElement.textContent = `${percentage}%`;
    }
    function gradientOut() {
        resultElement.textContent = '';
    }
}