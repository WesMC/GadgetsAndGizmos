var dataTable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {

    dataTable = $('#tblData').DataTable({
        "ajax": {
            "url": "/Admin/ProductType/GetAll"
        },
        "columns": [
            { "data": "subType", "width": "25%" },
            { "data": "subType1", "width": "15%" },
            { "data": "subType2", "width": "10%" },
            { "data": "subType3", "width": "10%" },
            {
                "data": "id",
                "render": function (data) {
                    return `
                            <div class="text-center">
                                <a href="/Admin/ProductType/Upsert/${data}" class="btn btn-success text-white" style="cursor: pointer;">
                                    <i class="fas fa-edit"></i> &nbsp; Edit
                                </a>
                                <a onclick=Delete("/Admin/ProductType/Delete/${data}") class="btn btn-danger text-white" style="cursor: pointer;">
                                    <i class="fas fa-trash"></i> &nbsp; Delete
                                </a>
                            </div>
                            `;
                }, "width": "40%"
            }
        ]
    });
}

function Delete(url) {
    swal({
        title: "Are you sure you want to Delete?",
        text: "You will not be able restore your data!",
        icon: "warning",
        buttons: true,
        dangerMode: true
    }).then((willDelete) => {
        if(willDelete) {
            $.ajax({
                type: "DELETE",
                url: url,
                success: function (data) {
                    if (data.success == true) {
                        toastr.success(data.message);
                        dataTable.ajax.reload();
                    }
                    else {
                        toastr.error(data.message);
                    }
                }
            });
        }
    });
}