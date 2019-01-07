
//sort table by whatever header is clicked
function SortTable(n) {
    //use either table (main GetCars table or FoundCars table)
    var table = document.getElementById("carTable");
    var switching = true;
    //default sort is ascending
    var ascending = true;
    var switchcount = 0;
    //loop continues until no switching is done
    while (switching) {
        switching = false;
        var rows = table.rows;
        for (var i = 1; i < (rows.length - 1); i++) {
            //start with no switching
            var shouldSwitch = false;
            //get two elements - from current and next row
            var x = rows[i].getElementsByTagName("td")[n];
            var y = rows[i + 1].getElementsByTagName("td")[n];
            if (ascending) {
                if (x.innerHTML.toLowerCase() > y.innerHTML.toLowerCase()) {
                    //if the current row string should be sorted after the next row, switch them
                    shouldSwitch = true;
                    break;
                }
            } else {//if descending
                if (x.innerHTML.toLowerCase() < y.innerHTML.toLowerCase()) {
                    shouldSwitch = true;
                    break;
                }
            }
        }
        if (shouldSwitch) {
            //switch current and next row elements
            rows[i].parentNode.insertBefore(rows[i + 1], rows[i]);
            switching = true;
            switchcount++;
        } else {
            //if no switches have been made (meaning table is already sorted by that field), change direction to descending
            if (switchcount === 0 && ascending) {
                ascending = false;
                switching = true;
            }
        }
    }
}