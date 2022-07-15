var dataTable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": {
            "url": "/Leitores/GetLeitores",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            {
                "data": {
                    nome: { "data": "nome" },
                    apelido: { "data": "apelido" },
                },
                "render": function (data) {
                    return data.nome + " " + data.apelido;
                }, "width": "15%"
            },
            { "data": "nif", "width": "10%" }, 
            { "data": "telefone", "width": "10%" },
            { "data": "email", "width": "15%" },
            { "data": "dataRegisto", "width": "10%" },
            { "data": "estadoRegisto", "width": "10%" },
            { "data": "dataEstado", "width": "10%" },
            {
                "data": {
                    nif: { "data": "nif" },
                    estadoRegisto: { "data": "estadoRegisto" },
                },
                "render": function (data) {
                    if (data.estadoRegisto == "Ativo") {
                        return `<div class="text-center">
                                <a href="/Leitores/UpdateLeitor/${data.nif}" class='btn btn-success text-white'
                                    style='cursor:pointer;'> <i class='far fa-edit'></i></a>
                                    &nbsp;
                                <a onclick=Delete("/Leitores/DeleteLeitor/${data.nif}") class='btn btn-danger text-white'
                                    style='cursor:pointer;'> <i class='far fa-trash-alt'></i></a>
                                </div>
                            `;
                    } else {
                        return `<div class="text-center">
                                <a href="/Leitores/UpdateLeitor/${data.nif}" class='btn btn-success text-white'
                                    style='cursor:pointer;'> <i class='far fa-edit'></i></a>
                                    &nbsp;
                                <a onclick=Reativar("/Leitores/ReativarLeitor/${data.nif}") class='btn btn-primary text-white'
                                    style='cursor:pointer;'> <i class="fa-solid fa-check"></i> Reativar</a>
                                </div>
                            `;
                    }                    
                }, "width": "25%"
            }
        ]
    });
}

function Delete(url) {
    new swal({
        title: "Tem a certeza que quer eliminar?",
        text: "Depois de apagar não é possível restaurar a informação do leitor",
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

function Reativar(url) {
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
}