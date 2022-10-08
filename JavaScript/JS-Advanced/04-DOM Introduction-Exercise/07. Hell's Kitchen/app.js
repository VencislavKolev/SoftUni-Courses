function solve() {
   document.querySelector('#btnSend').addEventListener('click', onClick);
   let restaurants = [];

   function onClick() {
      let inputs = JSON.parse(document.querySelector('#inputs textarea').value);
      for (const input of inputs) {
         let isNewRestaurant = true;
         let split = input.split(' - ');
         let restaurantName = split[0];
         let currentRestaurant;
         if (restaurants[restaurantName]) {
            currentRestaurant = restaurants[restaurantName]
            isNewRestaurant = false;
         } else {
            currentRestaurant = {
               name: restaurantName,
               employees: [],
               totalSalary: 0,
               averageSalary: 0,
               bestSalary: 0
            }
         }

         let workersSalaries = split[1].split(', ');
         for (const data of workersSalaries) {
            let name = data.split(' ')[0];
            let salary = Number(data.split(' ')[1]);
            if (salary > currentRestaurant.bestSalary) {
               currentRestaurant.bestSalary = salary
            }
            let employee = { name, salary };
            currentRestaurant.employees.push(employee);
            currentRestaurant.totalSalary += salary;
         }
         let averageSalary = currentRestaurant.totalSalary / currentRestaurant.employees.length;
         currentRestaurant.averageSalary = parseFloat(averageSalary.toFixed(2));
         if (isNewRestaurant) {
            restaurants.push(currentRestaurant)
         }
         console.log(currentRestaurant);
      }
      restaurants.sort((x, y) => y.averageSalary - x.averageSalary)
      const winner = restaurants[0];
      winner.employees.sort((x, y) => y.salary - x.salary);
      let firstOutput = `Name: ${winner.name} Average Salary: ${winner.averageSalary.toFixed(2)} Best Salary: ${winner.bestSalary.toFixed(2)}`;
      console.log(firstOutput);

      let secondOutput = '';
      for (const e of winner.employees) {
         secondOutput = secondOutput.concat(`Name: ${e.name} With Salary: ${e.salary} `);
      }
      console.log(secondOutput);
      let paragraphs = document.querySelectorAll('p');
      paragraphs[0].textContent = firstOutput
      paragraphs[1].textContent = secondOutput
   }
}

// solve('["PizzaHut - Peter 500, George 300, Mark 800","TheLake - Bob 1300, Joe 780, Jane 660"]')
// solve('["Mikes - Steve 1000, Ivan 200, Paul 800","Fleet - Maria 850, Janet 650"]')