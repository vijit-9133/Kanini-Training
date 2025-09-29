function check(){
    const data1=document.getElementById("reg1").value;
    const regex= /^(?=.*[A-Za-z])(?=.*\d).{6,}$/;
    alert(regex.test(data1));
}
let arr1=[]
function store(){
    let input= document.getElementById("arraydata").value
    arr1= input.split(",").map(Number);
    alert("Stored array is:"+arr1);
}
function pop(){
    alert(arr1.pop());
}
function push(){
    let in1=prompt("Enter the element you want to add:");
    arr1.push(in1);
    alert("THe updated array is:"+arr1);
}
function reduce(){
    const res=arr1.reduce((acc,num)=>acc*num,1);
    alert("The product is:"+res);
}
// This is the practice for callback
function cook(food, doneCooking) {
  console.log("Cooking " + food);
  doneCooking();
}

cook("pasta", () => {
  console.log("Pasta is ready! 🍝");
});
//this is practice for string manipulation methods 
function getInput() {
  return document.getElementById("userInput").value;
}

function displayResult(text) {
  document.getElementById("result").innerText = text;
}

function toUpper() {
  let str = getInput();
  displayResult(str.toUpperCase());
}

function toLower() {
  let str = getInput();
  displayResult(str.toLowerCase());
}

function trimString() {
  let str = getInput();
  displayResult(str.trim());
}

function sliceString() {
  let str = getInput();
  let ind1=prompt("Enter the starting index for slicing:");
  let ind2=prompt("Enter the ending index for slicing:");
  displayResult(str.slice(ind1, ind2));
}

function substringString() {
  let str = getInput();
  let ind1=prompt("Enter the starting index for substring:");
  let ind2=prompt("Enter the ending index for substring:");
  displayResult(str.substring(ind1, ind2));
}

function charAtString() {
  let str = getInput();
  displayResult("Character at index 2: " + str.charAt(2));
}

function replaceString() {
  let str = getInput();
  displayResult(str.replace(/a/g, "@")); 
}

function splitString() {
  let str = getInput();
  let arr = str.split(" ");
  displayResult("Split array: [" + arr.join(", ") + "]");
}

function includesString() {
  let str = getInput();
  displayResult("Includes 'name'? " + str.includes("name"));
}

function indexOfString() {
  let str = getInput();
  displayResult("Index of 'a': " + str.indexOf("a"));
}

function getLength() {
  let str = getInput();
  displayResult("String length: " + str.length);
}
