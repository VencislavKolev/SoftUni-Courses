function solve() {
  let sectionElements = document.getElementsByTagName('section');
  let correctAnswers = ['onclick', 'JSON.stringify()', 'A programming API for HTML and XML documents'];
  let resultElement = document.querySelector('#quizzie ul li.results-inner h1');

  Array.from(document.querySelectorAll('li div p'))
    .forEach(x => x.addEventListener('click', checkAnswer));

  let currentSection = 0;
  let rightAnswers = 0;
  function checkAnswer(e) {
    if (e.target.textContent === correctAnswers[currentSection]) {
      rightAnswers++;
    }

    // sectionElements[currentSection].classList.add('hidden');
    sectionElements[currentSection].style.display = 'none';

    if (currentSection < sectionElements.length - 1) {
      // sectionElements[++currentSection].classList.remove('hidden');
      sectionElements[++currentSection].style.display = 'block';
    } else {
      let status;
      if (rightAnswers == correctAnswers.length) {
        status = 'You are recognized as top JavaScript fan!';
      } else {
        status = `You have ${rightAnswers} right answers`
      }
      resultElement.textContent = status;
      resultElement.parentElement.parentElement.style.display = 'block';
    }
  }
}