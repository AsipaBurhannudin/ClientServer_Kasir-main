$.ajax({
    url: "https://localhost:7078/api/Item"
}).done((result) => {
    console.log(result);
    var temp = "";

    $.each(result, (key, val) => {
        temp += `<tr>
                    <td>${key + 1}</td>
                    <td>${val.name}</td>
                    <td>${val.name}</td>
                    <td>${val.name}</td>
                    <td>${val.name}</td>
                    <td>${val.name}</td>
                    <td><button type="button" class="btn btn-primary" onclick="detail('${val.url}')" data-bs-toggle="modal" data-bs-target="#modalItem">Detail</button></td>
                </tr>`;
    });

    console.log(temp);
    $("#tbodyItem").html(temp);
}).fail((error) => {
    console.log(error);
});


$(document).ready(function () {
    $('#tblItem').DataTable({
        ajax: {
            url: "https://localhost:7078/api/Item",
            dataSrc: 'data'
        },
        columns: [
            {
                data: null,
                render: function (data, type, row, meta) {
                    return meta.row + meta.settings._iDisplayStart + 1;
                }
            },
            { data: "ItemCode" },
            { data: "ItemName" },
            { data: "Stock" },
            { data: "SellingPrice" },
            { data: "PurchasePrice" },
            {
                data: null,
                render: function (data, type, row) {
                    return '<button type="button" class="btn btn-primary" onclick="detail(\'' + row.url + '\')" data-bs-toggle="modal" data-bs-target="#modalEmp">Detail</button>';
                }
            }
        ]
    });
});