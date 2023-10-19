function newRow() {
    var table = document.querySelector("table");
    var firstRow = table.querySelector("tr:nth-of-type(2)"); // Get the first data row as a template

    // Clone the first row
    var newRow = firstRow.cloneNode(true);

    // Clear the input values in the cloned row
    var inputs = newRow.querySelectorAll("input");
    inputs.forEach(function (input) {
        input.value = '';
    });

    // Append the cloned row to the table
    table.appendChild(newRow);
}