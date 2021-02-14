// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$('#savePopUp').on('click', function () {
    var phoneBookModel = {
        Name : $('#nameInput').val(),
        Entries : $('#entriesInput').val(),
        PhoneNumber : $('#phoneNumberInput').val()
    };
    console.log(phoneBookModel);
    $.ajax({
        url: 'PhoneBook/AddContact',
        type: 'POST',
        data: phoneBookModel,
        success: function (result) {          
            alert("Saved");
            location.reload();
        }
    })
})
function myFunction() {
    var input, filter, table, tr, td, i, txtValue;
    input = document.getElementById("myInput");
    filter = input.value.toUpperCase();
    table = document.getElementById("phoneBookTable");
    tr = table.getElementsByTagName("tr");

    for (i = 0; i < tr.length; i++) {
        td = tr[i].getElementsByTagName("td")[1];
        if (td) {
            txtValue = td.textContent || td.innerText;
            if (txtValue.toUpperCase().indexOf(filter) > -1) {
                tr[i].style.display = "";
            } else {
                tr[i].style.display = "none";
            }
        }
    }
}


