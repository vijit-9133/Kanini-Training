function doTask(callback){
    console.log("Task started");
    setTimeout(()=>
    {
        callback("Task Finished","Error Occured");
    },3000);
}
function dopromise(){
return  new Promise((resolve,reject)=>{
   doTask((result,err)=>{
    if(result){
        resolve(result);
    }
    else{
        reject(err);
    }
   });
});
}
dopromise
.then(result=>console.log(result))
.catch(err=>console.log("Error:",err))