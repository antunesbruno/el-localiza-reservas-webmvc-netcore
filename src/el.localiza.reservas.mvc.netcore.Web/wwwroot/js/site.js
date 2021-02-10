// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


function reserva_simula_calculo() {

    var valorHora = document.getElementById("valorHora").value;
    var totalDiasLocacao = document.getElementById("totalDiasLocacao").value;

    var total = valorHora * totalDiasLocacao;

    document.getElementById("totalDiasLbl").innerHTML  = totalDiasLocacao;
    document.getElementById("vlrPagarLbl").innerHTML  = total;    
}

function reserva_confirmacao() {
    $('#myModal').modal('show');
}
