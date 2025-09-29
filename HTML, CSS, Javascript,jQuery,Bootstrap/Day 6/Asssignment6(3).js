// 
const axiosreq = require('axios')

async function fetchUserdata(){
try{
const response = await axiosreq.get('https://jsonplaceholder.typicode.com/todos');
    const todos = response.data;
    console.log("Todos List");
    todos.forEach(todo=>{
console.log(`Todo ID: ${todo.id}, Title: ${todo.title}, Completed: ${todo.completed}`);
    });    
}
catch(err){
    console.log(err);
}
}
fetchUserdata();
