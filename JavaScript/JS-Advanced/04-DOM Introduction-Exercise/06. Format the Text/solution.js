function solve() {
  let input = document.getElementById('input').value;
  let outputDiv = document.getElementById('output');
  let sentences = input.split('.').filter(x => x !== '');

  while (sentences.length > 0) {
    let text = sentences.splice(0, 3).join('. ') + '.';
    let p = document.createElement('p');
    p.textContent = text;
    outputDiv.appendChild(p);
  }
}