let numbers = [1, 2, 3, 4];

function processArray(arr, callback) {
    arr.forEach(function(num) {
        callback(num);
    });
}

processArray(numbers, (n)=> {
    console.log("Number is: " + n);
});
