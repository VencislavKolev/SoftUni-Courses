// Function declaration
function printUsername(firstName, lastName) {
    console.log(`${firstName} ${lastName}`)
}

printUsername('Vencislav', 'Kolev')

// Function expression
//countDown holds the reference to the function, not its value
let countDown = function(number) {
    for(let i=number; i>0; i--){
        console.log(i);
    }
}
countDown(5)

// Arrow function
let countUp = (number) => {
    for(let i=0; i<number; i++){
        console.log(i);
    }
}
countUp(5)