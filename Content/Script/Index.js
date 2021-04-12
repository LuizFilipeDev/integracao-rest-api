$(document).ready(function(){

    var url = window.location.origin;
    var listaClientes;


    $.ajax({
        method:'POST',
        url:'/Cliente/Selecionar_Clientes',
        success:function(data){
            
            listaClientes = JSON.parse(data);

            console.log(listaClientes);

            $('#tabela').DataTable({
                "language": {
                    "lengthMenu": "Mostrando _MENU_ registros por pagina",
                    "zeroRecords": "Nenhum registro encontrado",
                    "info": "Mostrando pagina _PAGE_ de _PAGES_",
                    "infoEmpty": "Nenhum registro disponivel",
                    "infoFiltered": "(Filtrado de _MAX_ dos numeros totais de registros)",
                    "loadingRecords": "Carregando...",
                    "processing": "Processando...",
                    "search": "Buscar:",
                    "paginate": {
                        "first": "Primeiro",
                        "last": "Ultimo",
                        "next": "Proximo",
                        "previous": "Anterior"
                    },
                },
                data: listaClientes,
                columns: [
                    { data: '_id' },
                    { data: 'Nome' },
                    { data: 'Email' },
                    { data: 'Telefone' },
                    { data: '_id',
                      render: function (data) {
                          return "<a href='" + url + "/Cliente/ClienteEditar/" + data + "' target=\"+_blank\">Ver</a></td>";
                    }}
                ]
            });
        }
    });
    
});
