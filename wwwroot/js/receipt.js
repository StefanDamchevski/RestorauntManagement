function addToReceipt() {
    let quantityInputs = document.getElementsByClassName("quantityInput");
    let tableId = document.getElementById("tableId").value;

    quantityInputs = Array.from(quantityInputs);

    let selected = quantityInputs.filter(item => item.value > 0).map(function (item) { return { id: item.id, quantity: item.value } });

    let model = {
        TableId: tableId,
        Products: selected
    };

    axios.post('/table/addtotable', model)
        .then(function (response) {
            location.href = (`/table/details?tableId=${tableId}`)
        })
        .catch(function (error) {
            console.log(error);
        });
}