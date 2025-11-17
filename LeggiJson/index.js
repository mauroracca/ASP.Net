$(document).ready(function () {
    $("#frmModifica").hide();
    $('#tabDati').DataTable();
});

function getData(id) {
    //alert(id);
    let indice = id.substring(1);
    console.log($("#city" + indice).html() + " " + $("#name" + indice).html() + " " + $("#ab" + indice).html() + " " + $("#sup" + indice).html());
    $("#city" + indice).html("Fossangeles");
    console.log($("#city" + indice).html() + " " + $("#name" + indice).html() + " " + $("#ab" + indice).html() + " " + $("#sup" + indice).html());
    $("#txtCity").val($("#city" + indice).html());
    $("#txtName").val($("#name" + indice).html());
    $("#txtAb").val($("#ab" + indice).html());
    $("#txtSup").val($("#sup" + indice).html());
    $("#frmModifica").show();
}

