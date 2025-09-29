
function wordplay() {
   let in1 = document.getElementById("num1").value;
   in1 = Number(in1);  

   if (in1 < 2) {
     document.getElementById("para1").innerHTML = "The value is not in the defined range.";
   } 
   else if (in1 > 30) {
     document.getElementById("para1").innerHTML = "The value is not in the defined range.";  
   }
   else {
     let result = "";

    for (let i = 1; i <= in1; i++) {
      if (i % 2 === 0 && i % 5 === 0) {
        result += "jump ";
      } else if (i % 2 === 0) {
        result += "tap ";
      } else if (i % 5 === 0) {
        result += "stomp ";
      } else {
        result += i + " ";
      }
    }

    document.getElementById("para1").innerHTML = result.trim();
  }
   
}
function validate() {

    document.getElementById("namelocation").style.display = "none";
    document.getElementById("maillocation").style.display = "none";
    document.getElementById("passwordlocation").style.display = "none";
    document.getElementById("confirmlocation").style.display = "none";

    let isValid = true;

    let name = document.getElementById("Username").value.trim();
    let mail = document.getElementById("mail").value.trim();
    let pass = document.getElementById("Password").value;
    let cpass = document.getElementById("CPassword").value;

    if (name === "") {
        document.getElementById("namelocation").style.display = "inline";
        isValid = false;
    }

    let emailPattern = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
    if (!emailPattern.test(mail)) {
        document.getElementById("maillocation").style.display = "inline";
        isValid = false;
    }

    if (pass.length < 5) {
        document.getElementById("passwordlocation1").style.display = "inline";
        isValid = false;
    }

    if (pass !== cpass || cpass.length < 5) {
        document.getElementById("confirmlocation").style.display = "inline";
        isValid = false;
    }

    return isValid;
}
let obj_array = JSON.parse(localStorage.getItem("userData")) || []; 
window.onload = function () {
    if (obj_array.length > 0) {
        renderTable(obj_array);  
    }
};

function instantiateObject(name, age, height, weight) {
    return {
        Name: name,
        Age: age,
        Height: height,
        Weight: weight
    };
}
function addToArray(obj) {
    obj_array.push(obj);
    
    localStorage.setItem("userData", JSON.stringify(obj_array));

    return obj_array;
}

function handleSubmit(event) {
    event.preventDefault();

    const name = document.getElementById("name").value.trim();
    const age = document.getElementById("age1").value.trim();
    const height = document.getElementById("height").value.trim();
    const weight = document.getElementById("weight").value.trim();

    const person = instantiateObject(name, age, height, weight);

    const updatedArray = addToArray(person);

    let tableHTML = `<table class="table" border="1">
        <tr><th>Name</th><th>Age</th><th>Height</th><th>Weight</th></tr>`;

    updatedArray.forEach(function(obj) {
    tableHTML += "<tr>" +
        "<td>" + obj.Name + "</td>" +
        "<td>" + obj.Age + "</td>" +
        "<td>" + obj.Height + "</td>" +
        "<td>" + obj.Weight + "</td>" +
        "</tr>";
});

    tableHTML += `</table>`;

renderTable(updatedArray);
}
function reset(){
  document.getElementById("form1").reset();
  document.getElementById("summary").innerText = "";


}
function renderTable(dataArray) {
    let tableHTML = `<table class="table" border="1">
        <tr><th>Name</th><th>Age</th><th>Height</th><th>Weight</th></tr>`;

    dataArray.forEach(function(obj) {
    tableHTML += "<tr>" +
        "<td>" + obj.Name + "</td>" +
        "<td>" + obj.Age + "</td>" +
        "<td>" + obj.Height + "</td>" +
        "<td>" + obj.Weight + "</td>" +
        "</tr>";
});


    tableHTML += `</table>`;
    document.getElementById("result").innerHTML = tableHTML;
}
