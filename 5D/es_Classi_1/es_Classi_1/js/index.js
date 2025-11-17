"option script"

$(() => {
    let leggiClassi = sendRequestNoCallback("api/Classi/GetAllClassi", "GET", {});
    leggiClassi.fail(function(jqXHR){
        errore(jqXHR);
    });
    leggiClassi.done(function (data){
        console.log(data);
        let intest=Object.keys(data[0]);
        let table= $("<table class='table table-hover'>");
        let tr=$("<tr>");
        table.append(tr);
        $("#classi").children("div").eq(0).append(table);
        for(let item of intest){
            $("<th>").html(item).appendTo(tr);
        }
        for(let item of data){
            let trDati=$("<tr>");
            table.append(trDati);
            for(let voice of intest)
                $("<td>").appendTo(trDati).html(item[voice]);
        }
    });

    //$("#btnInsert").on("click",insert);
});


function insert(){
    let postData="{CodSede:'"+$("#txtCodIns").val()+"'," +
        "NomeSede:'"+$("#txtNomeIns").val()+"'," +
        "ResponsabileSede:'"+$("#txtResp").val()+"'," +
        "CittaSede:'"+$("#txtCittaIns").val()+"'," +
        "CodTipoAssicurazione:'"+$("#txtCodTipoIns").val()+"'}";
    let insert=sendRequestNoCallback("api/Assicurazioni/insert","POST",postData)
    insert.fail(function(jqXHR){
        errore(jqXHR)
    })
    insert.done(function(data){
        console.log(data)
        $("#risIns").html(data);
    })
}