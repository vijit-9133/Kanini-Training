fetch('https://dummyjson.com/products/add',{
    method: 'POST',
    headers: {
        'Content-type':'application/json'
    },
    body: JSON.stringify({
        title : 'My new product',
        price : 150
    })

})
.then(res=>res.json())
.then(data=>{
    console.log("Created product:",data);
})
.catch(err=>console.log(console.error(err))
);
