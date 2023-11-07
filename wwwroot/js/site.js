function newRow() {
    var table = document.querySelector("table");
    var lastRow = table.querySelector("tr:last-child"); // Get the last row as a template

    // Clone the last row
    var newRow = lastRow.cloneNode(true);

    // Clear the input values in the cloned row
    var input = newRow.querySelector("input");
    input.value = '';
    // Update the input name attribute to include Transaks[rowIndex]
    input.name = input.name.replace(/\[\d+\]/, '[' + rowIndex + ']');

    // Update the name attribute for the select elements
    var selects = newRow.querySelectorAll("select");
    selects[0].name = selects[0].name.replace(/\[\d+\]/, '[' + rowIndex + ']');
    selects[1].name = selects[1].name.replace(/\[\d+\]/, '[' + rowIndex + ']');

    // Append the cloned row to the table
    table.appendChild(newRow);

    // Increment the transaksCount for the next row
    rowIndex++;
}