var dataTable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": {
            "url": "/Nucleos/GetNucleos",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "idNucleo", "width": "15%" },
            { "data": "nucleo", "width": "60%" },            
            {
                "data": "idNucleo",
                "render": function (data) {
                    return `<div class="text-center">
                                <a href="/Nucleos/UpdateNucleo/${data}" class='btn btn-success text-white'
                                    style='cursor:pointer;'> <i class='far fa-edit'></i></a>
                                    &nbsp;
                                <a onclick=Delete("/Nucleos/DeleteNucleo/${data}") class='btn btn-danger text-white'
                                    style='cursor:pointer;'> <i class='far fa-trash-alt'></i></a>
                                </div>
                            `;
                }, "width": "25%"
            }
        ]
    });
}

function Delete(url) {
    new swal({
        title: "Tem a certeza que quer eliminar?",
        text: "Depois de apagar não é possível restaurar o núcleo",
        icon: "warning",
        buttons: true,
        showCancelButton: true,
        cancelButtonText: "Cancelar",
        dangerMode: true
    }).then((willDelete) => {
        if (willDelete) {
            $.ajax({
                type: 'DELETE',
                url: url,
                success: function (data) {
                    if (data.success) {
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