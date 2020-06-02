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



//Cada botão envia um comando on/off para a função "MandaComando" presente na controller

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

$("#btn_y").click(function () {
    var ID = 2;

   
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

$("#btn_r").click(function () {
    var ID = 3;

   
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

$("#btn_g").click(function () {
    var ID = 4;

    
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