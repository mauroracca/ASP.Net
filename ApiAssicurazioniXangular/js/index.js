"use strict"
$(() => {
    let leggiAssicurazioni = sendRequestNoCallback("api/Assicurazioni/GetAllAssicurazioni","GET",{});
    leggiAssicurazioni.fail(function (jqXHR){
        errore(jqXHR);
    });
    leggiAssicurazioni.done(function(data){
        let intest = Object.keys(data[0]);
        let table = $("<table class='table table-hover'>");
        let tr = $("<tr>");
        table.append(tr);
        $("#assicurazioni").children("div").eq(0).append(table);
        for (let item of intest) 
            $("<th>").html(item).appendTo(tr);
        
        for (let item of data) {
            console.log(item);
            let trDati = $("<tr>");
            table.append(trDati);
            for (let voice of intest)
                $("<td>").appendTo(trDati).html(item[voice]);
        }
    });

    $("#btnRicerca").on("click", ricerca);
    $("#btnRicerca2").on("click", ricerca2);
    $("#btnRicerca3").on("click", ricerca3);
    $("#btnInsert").on("click", insert);

});

function insert() {
    let postData = "{ id:'" + $("#txtCodIns").val() + "', nome:'" + $("#txtNomeIns").val() + "' , resp:'" + $("#txtResp").val() + "', citta:'" + $("#txtCittaIns").val() + "', tipo: '" + $("#txtCodTipoIns").val() + "'}";
    let insert = sendRequestNoCallback("api/Assicurazioni/insert", "POST", postData);
    insert.fail(function (jqXHR) {
        errore(jqXHR);
    });
    insert.done(function (data) {
        $("#risIns").html(data);
    });
}

function ricerca() {
    let postData = "{ CodSede:'" + $("#txtCode").val() + "' }";
    let ricercaAssicurazione = sendRequestNoCallback("api/Assicurazioni/RicercaAssicurazione", "POST", postData);
    ricercaAssicurazione.fail(function (jqXHR) {
        errore(jqXHR);
    });
    ricercaAssicurazione.done(function (data) {
        //alert(data);
        console.log("Assicurazione trovata: ");
        console.log(data);
        if (data != null) {
            let intest = Object.keys(data);
            let str = "";
            for (let item of intest)
                str += item + ": " + data[item] + "<br>";
            $("#ris").html(str);
        } else {
            $("#ris").html("Nessuna assicurazione trovata con il codice indicato!");
        }
    });
    //sendRequest("api/Assicurazioni/RicercaAssicurazione", "POST", postData,getSingolaAssicurazione);
}

function ricerca2() {
    let ricercaAssicurazione = sendRequestNoCallback("api/Assicurazioni/RicercaAssicurazioneGet/" + $("#txtCode").val(), "GET", {});
    ricercaAssicurazione.fail(function (jqXHR) {
        errore(jqXHR);
    });
    ricercaAssicurazione.done(function (data) {
        //alert(data);
        console.log("Assicurazione trovata: ");
        console.log(data);
        if (data != null) {
            let intest = Object.keys(data);
            let str = "";
            for (let item of intest)
                str += item + ": " + data[item] + "<br>";
            $("#ris2").html(str);
        } else {
            $("#ris2").html("Nessuna assicurazione trovata con il codice indicato!");
        }
    });
    //sendRequest("api/Assicurazioni/RicercaAssicurazione", "POST", postData,getSingolaAssicurazione);
}

function ricerca3() {
    let ricercaAssicurazione = sendRequestNoCallback("api/Assicurazioni/RicercaAssicurazioneGet/" + $("#txtCitta").val() + "/" + $("#txtCodTipo").val(), "GET", {});    
    ricercaAssicurazione.fail(function (jqXHR) {
        errore(jqXHR);
    });
    ricercaAssicurazione.done(function (data) {
        //alert(data);
        console.log("Assicurazione trovata: ");
        console.log(data);
        $("#ris3").html("");
        //if (data != null) {
        //    let intest = Object.keys(data);
        //    let str = "";
        //    for (let item of intest)
        //        str += item + ": " + data[item] + "<br>";
        //    $("#ris3").html(str);
        //} else {
        //    $("#ris3").html("Nessuna assicurazione trovata con il codice indicato!");
        //}
        if (data.length > 0) {
            for (let item of data) {
                let intest = Object.keys(item);
                let str = "";
                for (let voice of intest)
                    str += voice + ": " + item[voice] + "<br>";
                $("#ris3").html($("#ris3").html() + str + "<br>");
            }
        } else 
            $("#ris3").html("Nessuna assicurazione trovata con il codice indicato!");
    });
    //sendRequest("api/Assicurazioni/RicercaAssicurazione", "POST", postData,getSingolaAssicurazione);
}

function getSingolaAssicurazione(serverData) {
    console.log(serverData);
}

function errore(jqXHR) {
    console.log("Errore esecuzione web service ASP.Net");
    let code = jqXHR.status;
    let message = jqXHR.responseText;
    $("#pError").show();
    if (code == 0)
        $("#pError").html("Server Timeout!");
    else
        $("#pError").html("Codice errore: " + code + " - " + message);
}