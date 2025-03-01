
let dataTable;

$(document).ready(function () {
    loadDatatable();
});

function loadDatatable() {
    dataTable = $("#tblCategories").DataTable({
        "ajax": {
            "url": "/admin/categories/GetAll",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "id", "width": "5%" },
            { "data": "name", "width": "50%" },
            { "data": "order", "width": "20%" },
            {
                "data": "id",
                "render": function (data) {
                    return `<div class="text-center">
                                <a href="/Admin/Categories/Edit/${data}"
                                    class="btn btn-success text-white" style="cursor:pointer; width:100px;">
                                    <i class="far fa-edit"></i> Edit
                                </a>
                                &nbsp;
                                <a onclick="Delete('/Admin/Categories/Delete/${data}')"
                                    class="btn btn-danger text-white" style="cursor:pointer; width:100px;">
                                    <i class="far fa-trash-alt"></i> Delete
                                </a>
                            </div>`;
                }, "width": "30%"
            }
        ],
    })
}


function Delete(url) {
    swal({
        title: "Are you sure you want to delete this category?",
        text: "Once deleted can not be recovered!",
        type: "warning",
        showCancelButton: true,
        confirmButtonColor: "#DD6B55",
        confirmButtonText: "Yes, Delete!",
        closeOnconfirm: true
    }, function () {
        $.ajax({
            type: 'DELETE',
            url: url,
            success: function (data) {
                if (data.success) {
                    toastr.success(data.message);
                    console.log("Pasa por aqui");
                    console.log(dataTable.ajax);
                    console.log(dataTable.ajax.reload());
                    dataTable.ajax.reload();
                    console.log("Y por aqui");
                }
                else {
        
                    toastr.error(data.message);
                }
            }
        });
    });
}