const DOMAIN_URL = 'https://dataflow-xm4.azurewebsites.net/api/';
const ONE_MIN = 60000;
var scheduler = false;
var agents = [];
var curGUID = guid();
var mimeTypes = {
    'text/plain' : 'txt',
    'text/csv' : 'csv'
}
// curGUID = '61714bf2-613a-4357-b805-39e3e0f66416';
/*Chrome Extension APIs*/
chrome.runtime.onMessageExternal.addListener(function(message, sender, sendResponse){
    
})
chrome.runtime.onMessage.addListener(function(message, sender, sendResponse) {
    if(message.register){
        curGUID = guid()
        $.ajax({
            url : DOMAIN_URL + 'register',
            data: {
                uuid : curGUID
            },
            type: 'POST',
            success : function(res){
                sendResponse(res);
            },
            error : function(err){
                sendResponse(err);
            }
        })
    } else if(message.getAgents){
        getAgentsInterval(function(){
            sendResponse();
        });
    } else if(message.runAgent){
        runAgents(agents.filter(x=>x.agent_id == message.agent_id),0);
    }
    return true;
});
chrome.runtime.onInstalled.addListener(function(details) {
    
})
/*Utility Methods*/
function getTodayDate() {
    return (new Date()).toISOString().substring(0, 10);
}
function getTodaysDate() {
    return getTodayDate() + " " + (new Date()).toLocaleTimeString();
}
function openNewTab(URL, callback) {
    chrome.tabs.create({
        url: URL
    }, function(new_tab){
        if(typeof callback == 'function'){
            callback(new_tab);
        }
    });
}
function guid() {
  function s4() { return Math.floor((1 + Math.random()) * 0x10000).toString(16).substring(1);}
  return s4() + s4() + '-' + s4() + '-' + s4() + '-' + s4() + '-' + s4() + s4() + s4();
}
/*Scheduling*/
function getAgentsInterval(){
    callXHR('agents', {
    }, function(res){
        if(res){
            agents = res;
            chrome.storage.local.set({
                agents: agents
            });
            restartScheduleInterval();
            setTimeout(getAgentsInterval, 30*ONE_MIN);
        }
    });
}
function getConfSettings(callback){
    chrome.storage.local.get('configuration', function(o){
        if(o.configuration){
            var conf_settings = JSON.parse(o.configuration);
            callback(conf_settings);
        } else {
            // showNotification("Configuration settings not found!");
            chrome.runtime.openOptionsPage();
        }
    });
}
function restartScheduleInterval(){
    if(scheduler){
        clearInterval(scheduler);
        scheduler = false;
    }
    scheduler = setInterval(function(){
        checkAgents();
    },ONE_MIN);
}
function checkAgents(){
    if(agents.length > 0){
        var now = new Date();
        agents.forEach(function(agent){
            var runnableAgents = [];
            agent.schedule.forEach(function(a){
                if(a.day == now.getDay() && a.hour == now.getHours() && a.minute == now.getMinutes()){
                    runnableAgents.push(agent);
                }
            });
            if(runnableAgents.length > 0){
                runAgents(runnableAgents, 0);
            }
        });
    }
}
function runAgents(runnableAgents, idx){
    var agent = runnableAgents[idx];
    if(agent){
        var parameters = agent.parameters;
        var data = {};
        if(parameters){
            if(typeof parameters == 'string') parameters = JSON.parse(parameters);
            if(parameters.body){
                parameters.body.forEach(function(p){
                    var key = Object.keys(p)[0];
                    data[key] = p[key];
                })
            }
        }
        var agent_id = agent.agent_id;
        $.ajax({
            url: agent.url,
            type: agent.action,
            data: data,
            success: function(res, status, xhr){
                var fileName;
                var contentType = xhr.getResponseHeader('content-type');
                var fileExt = mimeTypes[contentType] || 'txt';
                if(!fileName) fileName = (new Date()).getTime()+"."+fileExt;
                var response = res;
                sendData(agent_id, response, fileName, function(){
                    logMessage(agent_id, 'Successfully retrieved', function(){
                        idx++;
                        runAgents(runnableAgents, idx);
                    })
                });
            },
            // error: function(err){
            //     logMessage(agent_id, err.responseText, function(){
            //         idx++;
            //         runAgents(runnableAgents, idx);
            //     })
            // },
            complete: function(xhr, status){
                var contentDispositionHeader = xhr.getResponseHeader('content-disposition');
                if(status != 'success' && contentDispositionHeader){
                    var cdAttachment = contentDispositionHeader.split(";");
                    if(cdAttachment && cdAttachment.length > 0){
                        var fileNameMatches = cdAttachment.filter(x=>x.indexOf('filename') > -1);
                        var fileName;
                        if(fileNameMatches && fileNameMatches.length > 0 && fileNameMatches[0].indexOf('=') > -1){
                            fileName = fileNameMatches[0].split('=')[1];
                            fileName = fileName.replace(/"/g, '');
                        }
                        var contentType = xhr.getResponseHeader('content-type');
                        var fileExt = mimeTypes[contentType] || 'txt';
                        if(!fileName) fileName = (new Date()).getTime()+"."+fileExt;
                        var response = xhr.responseText;
                        sendData(agent_id, response, fileName, function(){
                            logMessage(agent_id, 'Successfully retrieved', function(){
                                idx++;
                                runAgents(runnableAgents, idx);
                            })
                        });
                    }
                }
            }
        })
    }
}
function sendData(agent_id, data, filename, callback){
    var encodedData = btoa(unescape(encodeURIComponent(data)));
    callXHR('data', {
        data: encodedData,
        filename: filename,
        agent_id: agent_id
    }, callback);
}
function logMessage(agent_id, xhr_res, callback){
    callXHR('log', {
        message: xhr_res,
        agent_id: agent_id
    }, callback);
}
function callXHR(end_point, ext_data, callback){
    getConfSettings(function(conf_settings){
        if(conf_settings && conf_settings.token){
            var data = {
                uuid : conf_settings.uuid,
                token : conf_settings.token
            };
            data = $.extend(data,ext_data);
            $.ajax({
                url : DOMAIN_URL + end_point,
                data: data,     //JSON.stringify(data)
                type: 'POST',
                success : function(res){
                    if(typeof callback == 'function') callback(res);
                },
                error : function(err){
                    console.log(err);
                    if(typeof callback == 'function') callback();
                }
            });
        }
    });
}
function showNotification(txt){
    chrome.notifications.create({
        title: 'Data Flow',
        iconUrl: chrome.runtime.getURL('images/icon-48.png'),
        type: 'basic',
        message: txt
    });
}
window.onload = function(){
    getAgentsInterval();
}