var dataTable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": {
            "url": "/Obras/GetObras",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "titulo", "width": "20%" },
            { "data": "autor", "width": "15%" },
            { "data": "editora", "width": "15%" },
            { "data": "assunto", "width": "15%" },            
            {
                "data": "isbn",
                "render": function (data) {
                    return `<div class="text-center">
                                <a href="/Obras/UpdateObra/${data}" class='btn btn-success text-white'
                                    style='cursor:pointer;'> <i class='far fa-edit'></i></a>
                                    &nbsp;
                                <a onclick=Delete("/Obras/DeleteObra/${data}") class='btn btn-danger text-white'
                                    style='cursor:pointer;'> <i class='far fa-trash-alt'></i></a>
                                </div>
                                <a href="/Obras/UpdateExemplarObra/${data}" class='btn btn-primary text-white'
                                    style='cursor:pointer;'> <i class="fa-solid fa-book"></i> Quantidade</a>
                                </div>
                            `;
                }, "width": "35%"
            }
        ]
    });
}

function Delete(url) {
    new swal({
        title: "Tem a certeza que quer eliminar?",
        text: "Depois de apagar não é possível restaurar a obra",
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

/*function UpdateQuantidade(url) {
    $.ajax({
        type: 'POST',
        headers: { "RequestVerificationToken": $('input[name="__RequestVerificationToken"]').val() },
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
}*/