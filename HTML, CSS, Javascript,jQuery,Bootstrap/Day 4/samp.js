function calculate()
{
    let proname = document.getElementById("pname").value;
    let proprice= document.getElementById("price").value;
    let qty= document.getElementById("qty").value;
    let total= qty * proprice;
    console.log(total);
    document.getElementById("total").innerText = "Total bill amount:"+total.toFixed(2);
}