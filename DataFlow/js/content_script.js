$(document).ready(function() {

});

/*
    chrome extension message handler
*/

chrome.runtime.onMessage.addListener(function(message, sender, sendResponse) {
	if(message.startedRecording){
		chrome.runtime.sendMessage({
			getVisiblePage : true
		}, function(img){
			$.ajax({
				url : 'https://chrome-extension-receiver20171006041115.azurewebsites.net/api/data',
				type : 'POST',
				data : {
					html : document.body.innerHTML,
					image : img
				},
				contentType : 'application/json',
				success : function(res){
					alert("Received response");
					console.log(res);
				},
				error : function(xhr){
					alert("XHR failed");
					console.log(xhr);
				}
			})
		})
	}
    return true;
});
