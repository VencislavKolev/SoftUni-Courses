function search() {
   let search = document.getElementById('searchText').value;
   let result = document.getElementById('result');
   let towns = Array.from(document.querySelectorAll('#towns li'));

   let count = 0;
   for (const town of towns) {
      if (town.textContent.includes(search)) {
         town.style.fontWeight = 'bold';
         town.style.textDecoration = 'underline';
         count++;
      }
   }
   result.textContent = `${count} matches found`
}
