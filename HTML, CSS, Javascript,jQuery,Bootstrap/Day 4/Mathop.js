function MathOp(){
    let a=parseInt(document.getElementById("num1").value);
    let b=parseInt(document.getElementById("num2").value);
    // let sum=a+b;

    // document.getElementById("res").innerText="Sum is:"+sum
    let choice = parseInt(prompt("Enter the operation that you want to perform\n1.Add\n2.Subtract\n3.Multiply\n4.Division"));
    switch(choice)
    {
        case 1:
            add(a,b);
            break;
        case 2:
            subtract(a,b);
            break;
        case 3:
            multiply(a,b);
            break;
        case 4:
            divide(a,b);
            break;
        default:
            alert("Enter a valid option:")

    }
}
function add(a,b){
    console.log(a+b);

}
function subtract(a,b){
    document.getElementById("res").innerHTML = "<h1>Result is:</h1>" +(a-b);

}
function multiply(a,b){
    alert(a*b);

}
function divide(a,b){
    document.writeln(a/b);

}

