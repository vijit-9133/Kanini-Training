function order(){
    event.preventDefault(); 

    
    const prices = {
        c1: 799,
        c2: 899,
        c3: 999,
        c4: 299,
        c5: 1199
    };

    let total = 0;

    for (let id in prices) {
        const checkbox = document.getElementById(id);
        if (checkbox.checked) {
            total += prices[id];
        }
    }

    let discount = 0;
    if (total > 2000) {
        discount = 0.2 * total;
    }

    const final = total - discount;

document.getElementById("summary").innerText = "Total: Rs" + total + ", Discount: Rs" + discount + ", Final: Rs" + final;



}
function reset(){
  document.getElementById("form1").reset();
  document.getElementById("summary").innerText = "";


}