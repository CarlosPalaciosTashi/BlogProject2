
let dataTable;

$(document).ready(function () {
    loadDatatable();
});

function loadDatatable() {
    dataTable = $("#tblArticles").DataTable({
        "ajax": {
            "url": "/admin/articles/GetAll",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "id", "width": "5%" },
            { "data": "name", "width": "20%" },
            { "data": "category.name", "width": "15%" },
            {
                "data": "urlImage",
                "render": function (image){
                    return `<img src="../${image}" width="120px">
                }
            },
            { "data": "creationDate", "width": "30%" },
            {
                "data": "id",
                "render": function (data) {
                    return `<div class="text-center">
                                <a href="/Admin/Articles/Edit/${data}"
                                    class="btn btn-success text-white" style="cursor:pointer; width:100px;">
                                    <i class="far fa-edit"></i> Edit
                                </a>
                                &nbsp;
                                <a onclick="Delete('/Admin/Articles/Delete/${data}')"
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