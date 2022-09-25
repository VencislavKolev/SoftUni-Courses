function solve() {
   document.querySelector('#searchBtn').addEventListener('click', onClick);

   let search = document.getElementById('searchField');
   let elements = Array.from(document.querySelectorAll('tbody tr'));

   function onClick() {
      Array.from(document.getElementsByClassName('select')).forEach((el) => el.classList.remove('select'));
      for (const element of elements) {
         if (element.innerHTML.includes(search.value)) {
            element.className = 'select';
         }
      }
      search.value = '';
   }
}