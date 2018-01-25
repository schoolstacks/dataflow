/*Chrome Extension APIs*/
chrome.runtime.onMessage.addListener(function(message, sender, sendResponse) {

});
/*Essential methods*/
function randIn(min, max) {
    if (max == null) {
        max = min;
        min = 0;
    }
    return (min + Math.floor(Math.random() * (max - min + 1)));
}
function getTodaysDate() {
    return (new Date()).toISOString().substring(0, 10) + " " + (new Date()).toLocaleTimeString();
}