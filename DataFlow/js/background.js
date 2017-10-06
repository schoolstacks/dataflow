/*  Chrome extension and message listeners  */
chrome.browserAction.onClicked.addListener(function() {
    openNewTab(LINKEDIN_SEARCH_PAGE);
});

chrome.runtime.onMessage.addListener(function(message, sender, sendResponse) {
    return true;
});

chrome.runtime.onInstalled.addListener(function(details) {
    /*
        Do something when chrome extension install
    */
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
