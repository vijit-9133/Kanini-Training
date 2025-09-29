function Hello(callback){
    console.log("Hello!");
    callback();
}

Hello(()=>{
    console.log("Hi");
})

function fetchData(callback){
    setTimeout(()=>{
    console.log("Fetching data...");
    callback("Fetched Data")
},3000)

}

fetchData(function (msg){
    console.log("Callback says:",msg);
})