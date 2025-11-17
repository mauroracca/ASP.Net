"use strict";
//let accessoOk=true;  // se si inserisce il login google mettere questa variabile a false perchè verrà settata a true una volta loggati con google
$(document).ready(function () {
    /* INIZIALIZZA LA LIBRERIA */
   /* google.accounts.id.initialize({
        client_id: '512110855693-pdfgr25haa0s32gmigu9bt977v0opmb8.apps.googleusercontent.com',
        callback: handleCredentialResponse
    });
    google.accounts.id.renderButton(
        document.getElementById("btnGLogin"),
        { theme: "outline", size: "large" }
    );
    google.accounts.id.prompt();*/

    $("#btnToken").on("click", function () {
        /*if(accessoOk) {
            let uriWebService = "api/Fumetti/setToken";
            send_request(uriWebService, "GET", "", setToken);
        }else
            alert("E' necessario prima loggarsi");*/

        let uriWebService = "api/Fumetti/setToken";
        let setToken=sendRequestNoCallback(uriWebService, "GET", "");
        setToken.fail(function (jqXHR, test_status, str_error){
            console.log(str_error);
        });
        setToken.done((data)=>{
            console.log("Token salvato correttamente nel cookie");
            console.log(data);
            $("#pSetToken").html(Cookies.get("token"));
            //Cookies.replace("token", "");
        });
    });

    $("#btnGetToken").on("click", function () {
        let uriWebService = "api/Fumetti/getToken";
        let getToken=sendRequestNoCallback(uriWebService, "GET", "");
        getToken.fail(function (jqXHR, test_status, str_error){
            console.log(str_error);
        });
        getToken.done(data=>{
            console.log(data);
            if (data == "true")
                $("#pGetToken").html(Cookies.get("token"));
            else
                $("#pGetToken").html("Token scaduto!");
        });
    }); 

    $("#btnSetLocalToken").on("click", function () {
        let uriWebService = "api/Fumetti/setLocalToken";
        //send_request(uriWebService, "GET", "", setLocalToken);
        let localT=sendRequestNoCallback(uriWebService, "GET", "");
        localT.done(function (serverData){
            // Salvo token in local storage
            serverData = serverData.replace(/"/g, "");
            $("#pSetLocalToken").html(serverData);
            localStorage.setItem("token", serverData);
            // preparo elenco domande su pagina web
        });
        localT.fail(function (jqXHR, test_status, str_error){
            console.log(str_error);
        });
    });

    $("#btnGetHeaders").on("click", function () {
        let uriWebService = "api/Fumetti/getHeaders";
        send_request(uriWebService, "get", "", getHeaders);
    });

    $("#btnLogout").on("click", function () {
        localStorage.clear();
    });
});

function setLocalToken(data) {
    data = data.replace(/"/g, "");
    $("#pSetLocalToken").html(data);
    localStorage.setItem("token", data);
}

function getHeaders(data) {
    $("#pGetHeaders").html(data);
}

function getToken(data) {
    if (data == "true")
        $("#pGetToken").html(Cookies.get("token"));
    else
        $("#pGetToken").html("Token scaduto!");
}

function setToken(data) {
    console.log("Token salvato correttamente nel cookie");
    $("#pSetToken").html(Cookies.get("token"));
    Cookies.replace("token", "");
}

/* QUANDO IL LOGIN VIENE EFFETTUATO */
//function handleCredentialResponse(data){
//    //console.log(data);
//    console.log(parseJwt(data.credential));
//    accessoOk=true;

//}
///* E' possibile usare delle librerie invece di questa funzione */
//function parseJwt (token) {
//    var base64Url = token.split('.')[1];
//    var base64 = base64Url.replace(/-/g, '+').replace(/_/g, '/');
//    var jsonPayload = decodeURIComponent(window.atob(base64)
//        .split('').map(function(c) {
//            return '%' + ('00' + c.charCodeAt(0).toString(16)).slice(-2);
//        }).join(''));
//    return JSON.parse(jsonPayload);
//}