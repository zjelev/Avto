function newRow() {
    var table = document.querySelector("table");
    var lastRow = table.querySelector("tr:last-child"); // Get the last row as a template

    // Clone the last row
    var newRow = lastRow.cloneNode(true);

    // Clear the input values in the cloned row
    var inputs = newRow.querySelectorAll("input");
    inputs.forEach(function (input) {
        input.value = '';
        // Update the input name attribute to include Transaks[rowIndex]
        input.name = input.name.replace(/\[\d+\]/, '[' + rowIndex + ']');
    });

    // Append the cloned row to the table
    table.appendChild(newRow);

    // Increment the rowIndex for the next row
    rowIndex++;
}