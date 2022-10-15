function create(words) {
   let contentElement = document.getElementById('content');

   for (const word of words) {
      let divElement = document.createElement('div');
      let p = document.createElement('p');
      p.style.display = 'none';
      p.textContent = word;

      divElement.appendChild(p);
      divElement.addEventListener('click', onClickEventHandler);

      contentElement.appendChild(divElement);
   }

   function onClickEventHandler(e) {
      e.target.querySelector('p').style.display = 'block';
   }
}