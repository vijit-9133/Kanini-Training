const readline = require('readline');

const rl = readline.createInterface({
  input: process.stdin,
  output: process.stdout
});
function fetchData(num) {
  return new Promise(function(resolve, reject) {
    setTimeout(() => {
      if(num%2===0){
      resolve(num);
      
      } 
      reject("Error: Only even numbers are accepted!");
    }, 2000);
  });
}
rl.question("Enter a number: ", function(input) {
  const userInput = Number(input);

fetchData(userInput)
  .then(function(userInput) {
    console.log("Number Accepted");
  })
  .catch(function(err) {
    console.log(err);
  })
  .finally(() => {
      rl.close();  
    });
});
