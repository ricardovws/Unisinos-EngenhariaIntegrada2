//Verifica se a cor do botão está correta.
$(window).on("load", function () {

    if ($("#btn_w").text() == "Ligado") {
        $("#btn_w").addClass("on");
    }
    if ($("#btn_y").text() == "Ligado") {
        $("#btn_y").addClass("on");
    }
    if ($("#btn_r").text() == "Ligado") {
        $("#btn_r").addClass("on");
    }
    if ($("#btn_g").text() == "Ligado") {
        $("#btn_g").addClass("on");
    }
});

//Habilita-desabilita as opções edição de configuração
$("#edit_config").click(function () {

    $(".box").toggle();
});


//Botão para ligar exaustão
$("#btn_w").click(function () {
    var ID = 1;

   
    if ($(this).hasClass("on")) {
        $(this).removeClass("on");

        $(this).load("/Home/MandaComando",
            { id: ID, comando: "Desligado" }
        );

    }
    else {
        $(this).addClass("on");

        $(this).load("/Home/MandaComando",
            { id: ID, comando: "Ligado" }
        );
    }
});

//Botão para salvar temperatura
$("#Salvar_temp").click(function () {
    var url = "/Home/SalvarConfiguracaoTemperatura";
    var temperatura = $("#temp").val();
    $.post(url, { temperatura: temperatura });
    $("#mensagemTempOk").html("Temperatura salva!").fadeIn(500)
        .delay(1000).fadeOut(500);
});

//Botão para salvar umidade
$("#Salvar_umi").click(function () {
    var url = "/Home/SalvarConfiguracaoUmidade";
    var umidade = $("#umi").val();
    $.post(url, { umidade: umidade });
    $("#mensagemUmiOk").html("Umidade salva!").fadeIn(500)
        .delay(1000).fadeOut(500);
});


//Botão para salvar tempo de iluminação
$("#Salvar_tempo").click(function () {
    var url = "/Home/SalvarTempo";
    var tempoLigado = $("#tempoLigado").val();
    var tempoDesligado = $("#tempoDesligado").val();
    $.post(url, { tempoLigado: tempoLigado, tempoDesligado: tempoDesligado });
    $("#mensagemTempoOk").html("Intervalor de tempo salvo!").fadeIn(500)
        .delay(1000).fadeOut(500);
});



