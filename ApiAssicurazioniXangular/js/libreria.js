function sendRequest(url,method,parameters,callback){
	$.ajax({
		url: url,
		type: method,
		contentType: "application/x-www-form-urlencoded; charset=UTF-8",
		dataType: "text",  
		data: parameters,
		timeout : 6000000,
		success: callback,
		error : function(jqXHR, test_status, str_error){
			//console.log("No connection to " + link);
			//console.log("Test_status: " + test_status);
			alert("Error: " + str_error);
		}
	});
}

function sendRequestNoCallback(url,method,parameters){
	return $.ajax({
		url: url,
		//contentType: "application/x-www-form-urlencoded; charset=UTF-8",
        contentType: "application/json",
		type: method,
		dataType: "json",
		data: parameters,
		timeout: 15000000
	});
}