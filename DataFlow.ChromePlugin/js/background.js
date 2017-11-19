/*  Chrome extension and message listeners  */
chrome.browserAction.onClicked.addListener(function() {
    
});

chrome.runtime.onMessage.addListener(function(message, sender, sendResponse) {
    if(message.startRecording){
        chrome.storage.local.set({
            isRecording: true
        });
        chrome.browserAction.setIcon({
            path : chrome.runtime.getURL('images/icon-rec-128.png')
        });
        chrome.tabs.query({
            active: true,
            currentWindow: true
        }, function(tabs) {
            if(tabs.length > 0) {
                chrome.tabs.sendMessage(tabs[0].id, {
                    startedRecording: true
                });
            }
        });
        sendResponse();
    } else if(message.stopRecording){
        chrome.storage.local.set({
            isRecording: false
        });
        chrome.browserAction.setIcon({
            path : chrome.runtime.getURL('images/icon-128.png')
        });
        sendResponse();
    } else if(message.getVisiblePage){
        chrome.tabs.captureVisibleTab(function(img){
            sendResponse(img);
        })
    }
    return true;
});

chrome.runtime.onInstalled.addListener(function(details) {
    //  Do something when chrome extension install

    //  Resetting isRecording value to false when extension is installed for first time or restarted
    chrome.storage.local.set({
        isRecording: false
    });
});

/*  Method for opening new tab from background.js   */
function openNewTab(URL, callback) {
    chrome.tabs.create({
        url: URL
    }, function(new_tab){
        if(typeof callback == 'function'){
            callback(new_tab);
        }
    });
}

window.onload = function() {
    
}
