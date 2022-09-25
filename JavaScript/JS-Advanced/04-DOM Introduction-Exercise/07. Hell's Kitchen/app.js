function solve() {
   document.querySelector('#btnSend').addEventListener('click', onClick);
   let data = {};

   function onClick() {
      let inputs = JSON.parse(document.querySelector('#inputs textarea').value);
      for (const input of inputs) {
         let split = input.split(' - ');
         let restaurant = {};
         restaurant.name = split[0];
         restaurant.employees = [];

         let workersSalaries = split[1].split(', ');
         let totalSalary = 0;
         for (const data of workersSalaries) {
            let name = data.split(' ')[0];
            let salary = Number(data.split(' ')[1]);
            let employee = { name, salary };
            restaurant.employees.push(employee);
            totalSalary += salary;
         }
         let averageSalary = totalSalary / restaurant.employees.length;
         restaurant.averageSalary = averageSalary;
         console.log(restaurant);
      }
   }
}