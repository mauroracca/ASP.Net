function send_request(url, method, parameters, callback) {
    //alert(parameters);
	$.ajax({
		url: url,
		type: method,
        contentType: 'application/json',
        dataType: 'text',
		data: parameters,
		timeout: 5000000,
		headers: { 'token': 'Bearer ' + localStorage.getItem("token") },
		success: callback,
		error : function(jqXHR, test_status, str_error){
			alert("Error: " + str_error + test_status + jqXHR);
		}
	});
}

function sendRequestNoCallback(url,method,parameters){
	/*let mycontentType;
	if(method.toUpperCase()=="GET")
		mycontentType="application/x-www-form-urlencoded; charset=UTF-8";
	else{
		mycontentType="application/json; charset=UTF-8";
		parameters=JSON.stringify(parameters);
	}*/
	return $.ajax({
		url: url,
		contentType: "application/x-www-form-urlencoded; charset=UTF-8",
		type: method,
		dataType: "text",
		data: parameters,
		headers: {token:"Bearer " + localStorage.getItem("token")},
		timeout: 5000
	});
}