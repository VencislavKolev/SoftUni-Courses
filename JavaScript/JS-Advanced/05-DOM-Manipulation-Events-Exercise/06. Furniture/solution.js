function solve() {
  let furnitureTextAreaElement = document.getElementsByTagName('textarea')[0];
  let resultTextAreaElement = document.getElementsByTagName('textarea')[1];

  let generateBtn = document.getElementsByTagName('button')[0];
  let buyBtn = document.getElementsByTagName('button')[1];

  generateBtn.addEventListener('click', generateEventHandler)
  buyBtn.addEventListener('click', buyEventHandler);

  function buyEventHandler(e) {
    let checkboxes = Array.from(document.querySelectorAll('input[type=checkbox]')).filter(x => x.checked);
    let furniture = [];
    let totalPrice = 0;
    let totalDecFactor = 0;

    for (const checkbox of checkboxes) {
      let trData = checkbox.parentElement.parentElement.children;
      let name = trData[1].innerText;
      let price = Number(trData[2].innerText);
      let decFactor = Number(trData[3].innerText);

      furniture.push(name);
      totalPrice += price;
      totalDecFactor += decFactor;
    }
    resultTextAreaElement.value += `Bought furniture: ${furniture.join(', ')}\n`;
    resultTextAreaElement.value += `Total price: ${totalPrice.toFixed(2)}\n`;
    resultTextAreaElement.value += `Average decoration factor: ${totalDecFactor / furniture.length}`;
  }

  function generateEventHandler(e) {
    let jsonObjects = JSON.parse(furnitureTextAreaElement.value);
    let tbodyElement = document.querySelector('table tbody');

    for (const obj of jsonObjects) {
      let tr = document.createElement('tr');
      let tdImage = document.createElement('td');
      let tdName = document.createElement('td');
      let tdPrice = document.createElement('td');
      let tdDecorationFactor = document.createElement('td');
      let tdMark = document.createElement('td');

      tdImage.innerHTML = `<img src=${obj.img}>`;
      tdName.innerHTML = `<p>${obj.name}</p>`;
      tdPrice.innerHTML = `<p>${obj.price}</p>`;
      tdDecorationFactor.innerHTML = `<p>${obj.decFactor}</p>`;
      tdMark.innerHTML = `<input type="checkbox"/>`;

      tr.appendChild(tdImage)
      tr.appendChild(tdName);
      tr.appendChild(tdPrice);
      tr.appendChild(tdDecorationFactor);
      tr.appendChild(tdMark);

      tbodyElement.appendChild(tr);
    }
  }
}