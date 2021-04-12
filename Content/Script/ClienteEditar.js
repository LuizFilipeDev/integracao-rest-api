$("#nome").on("input", function () {
    $(this).val(this.value.replace(/[^a-zA-Z ]/g, ''));
});
$('#telefone').mask('999999999');

function verificar() {

    $('#grupoNome').removeClass('error');
    $('#grupoEmail').removeClass('error');
    $('#grupoTelefone').removeClass('error');

    var Campos = {
        grupoNome: $('#nome').val(),
        grupoEmail: $('#email').val(),
        grupoTelefone: $('#telefone').val()
    }

    if ($('#nome').val() != "" && $('#email').val() != "" && $('#telefone').val() != "" && $('#telefone').val().length == 9) {
       salvar();
    } else {

        for (var item in Campos) {
            if (Campos[item] == "") {
                $('#' + item).addClass('error');
            }
        }
        if (Campos.grupoTelefone.length < 9) { $('#grupoTelefone').addClass('error'); }
    }
}
function salvar() {

    var Cliente = {
        Nome: $('#nome').val().trim(),
        Email: $('#email').val().trim(),
        Telefone: parseInt($('#telefone').val().trim())
    }
    var Identificador = $('#id').val().trim();

    $.ajax({
        url: '/Cliente/ClienteSelecionar_Editar',
        method: 'POST',
        data: { Identificador: Identificador ,Cliente: Cliente},
        success:function(data){
            if(data == "existe"){
                $('#modalAtualizar').modal('show');
            }else{
                window.location.href = '/Cliente/ClienteEditar/' + data;
            }
        }
    });
}
function deletar() {

     var Identificador = $('#id').val().trim();

     $.ajax({
         url: '/Cliente/Cliente_Deletar',
         method: 'POST',
         data: { Identificador: Identificador},
         success:function(data){
             if (data == "delete") {
                 window.location.href = '/Cliente/ClienteEditar';
             }
         }
    });
}