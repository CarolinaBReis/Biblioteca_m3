var dataTable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {   

    dataTable = $('#tblData').DataTable({
        "ajax": {
            "url": "/Requisicoes/GetRequisicoes",
            "type": "GET",
            "datatype": "json"
        },        
        "columns": [
            { "data": "isbn", "width": "15%" },
            { "data": "idNucleo", "width": "15%" },
            { "data": "nif", "width": "15%" },
            { "data": "dataRequisicao", "width": "15%" },
            { "data": "dataDevolucao", "width": "15%" },
            {
                "data": {
                    dataDevolucao: { "data": "dataDevolucao" },
                    isbn: { "data": "isbn" },
                    idNucleo: { "data": "idNucleo" },
                    nif: { "data": "nif" },                    
                },
                "render": function (data) {                    
                    if (data.dataDevolucao == null) {
                        return `<div class="text-center">
                                <a onclick=Devolver("/Requisicoes/DevolverRequisicao/${data.isbn}/${data.idNucleo}/${data.nif}") class='btn btn-success text-white'
                                    style='cursor:pointer;'> <i class="fa-solid fa-circle-arrow-left"></i></i> &nbsp Devolução</a>
                                    &nbsp;
                                </div>
                            `;                    
                    }
                    else {
                        return `<div class="text-center">                                
                                </div>
                            `;
                    }
                }, "width": "25%"
            }
        ]
    });
}

function Devolver(url) {
            $.ajax({
                type: 'POST',
                url: url,
                headers: { "RequestVerificationToken": $('input[name="__RequestVerificationToken"]').val() },
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


