function newRow(columns) {
    var table = document.querySelector("table");
    var newRow = table.insertRow(-1); // Insert a new row at the end of the table

    for (var i = 0; i < columns; i++) {
        var cell = newRow.insertCell(i);
        var input = document.createElement("input");
        input.type = "text";
        input.name = "new_row_col" + (i + 1); // Assign a unique name to each input
        cell.appendChild(input);
    }
}