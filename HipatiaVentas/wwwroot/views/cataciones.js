$(document).ready(function () {
    $("input").blur(function () {
        let fragancia_aroma = $('#FraganciaAroma').val();
        let sabor = $('#Sabor').val();
        let sabor_residual = $('#SaborResidual').val();
        let acidez = $('#Acidez').val();
        let cuerpo = $('#Cuerpo').val();
        let uniformidad = $('#Uniformidad').val();
        let dulzor = $('#Dulzor').val();
        let limpieza_taza = $('#LimpiezaTaza').val();
        let balance = $('#Balance').val();
        let global = $('#Global').val();

        suma =
            parseFloat(fragancia_aroma) +
            parseFloat(sabor) +
            parseFloat(sabor_residual) +
            parseFloat(acidez) +
            parseFloat(cuerpo) +
            parseFloat(uniformidad) +
            parseFloat(dulzor) +
            parseFloat(limpieza_taza) +
            parseFloat(balance) +
            parseFloat(global);

        $('#Puntaje').val(suma);
    });
});
