// 
const axiosreq = require('axios')
function fetchdata()
{
    return new Promise((resolve,reject)=>{
        axiosreq.get('https://jsonplaceholder.typicode.com/users')
        .then(response=>{
            resolve(response.data)
        })
        .catch(error=>{
            reject(`Error:${error}`)
        })

    })
}
fetch('https://dummyjson.com/products')
  .then(res => res.json())
  .then(data => {
    console.log("Products:");
    data.products.forEach(p => {
      console.log(`Name: ${p.title}, Price: $${p.price}`);
    });
  })
  .catch(err => console.error(err));

fetchdata()
.then(users =>{
    console.log("Users Data");
    users.forEach(user=>{
        console.log((`userId:${user.id},username:${user.name},email:${user.email}`));
    })
})
fetch('https://dummyjson.com/products')
  .then(res => res.json())
  .then(data => {
    console.log("Products:");
    data.products.forEach(p => {
      console.log(`Name: ${p.title}, Price: $${p.price}`);
    });
  })
  .catch(err => console.error(err));
