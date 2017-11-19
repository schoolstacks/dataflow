$(document).ready(function(){
    updateButton();
    $("#toggleRec").bind("click", function(){
    	var recType = $(this).attr("data-rec-type");
    	if(recType == 'start'){
    		chrome.runtime.sendMessage({
    			startRecording : true
    		}, function(){
    			updateButton();
    		})
    	} else {
    		chrome.runtime.sendMessage({
    			stopRecording : true
    		}, function(){
    			updateButton();
    		})
    	}
    })
});


function updateButton(){
	chrome.storage.local.get('isRecording', function(o){
    	if(o && o.isRecording){
    		$("#toggleRec").text("End Session").attr("data-rec-type","stop");
    	} else {
    		$("#toggleRec").text("Begin Session").attr("data-rec-type","start");
    	}
    })
}