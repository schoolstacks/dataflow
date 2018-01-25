$(document).ready(function(){
	chrome.storage.local.get('configuration', function(o){
		if(o.configuration){
			var conf_settings = JSON.parse(o.configuration);
			$("#url").val(conf_settings.url);
			if(conf_settings.token){
				$("#token").text(conf_settings.token);
				$("#token-cont").show();
			}
			if(conf_settings.uuid){
				$("#uuid").text(conf_settings.uuid);
				$("#uuid-cont").show();
			}
		}
	});
	$("#conf_form").on("submit", function(){
		$("#saveBtn").attr("disabled",true);
		$("#loading").show();
		var url = $("#url").val();
		var configuration_settings = {url : url};
		chrome.runtime.sendMessage({
			register: true
		}, function(res){
			if(res){
				var token = res.token;
				configuration_settings = {
					url: url,
					uuid: res.uuid,
					token: token
				}
				//debug
				configuration_settings = {
					url: 'https://dataflow-xm4.azurewebsites.net/',
					uuid: '61714bf2-613a-4357-b805-39e3e0f66416',
					token: '0b867cd4-7df6-40dc-8366-3ad136c7d794'
				}
				chrome.storage.local.set({'configuration': JSON.stringify(configuration_settings)});
				chrome.runtime.sendMessage({getAgents: true}, function(){
					location.reload();
				});
			} else {
				$("#saveBtn").removeAttr("disabled");
			}
		})
		return false;
	});
	showWebsites()
});

function showWebsites(){
	chrome.storage.local.get('agents', function(o){
		if(o && o.agents){
			var agents = o.agents;
			var row_template = '<tr><td>{{name}}</td><td class="chars_50">{{url}}</td><td>{{NEXT_SCHEDULE}}</td><td><button data-idx="{{idx}}" data-agent-id="{{agent_id}}">RUN NOW</button></td></tr>';
			// console.log(agents);
			agents.forEach(function(a,i){
				var agent_row = row_template.slice(0);
				agent_row.match(/{{(.*?)}}/g).forEach(function(m){
					var a_key = m.replace(/\W/g,'');
					if(a[a_key]){
						agent_row = agent_row.replace(m,a[a_key])
					} else if(a_key == 'NEXT_SCHEDULE'){
						agent_row = agent_row.replace(/{{NEXT_SCHEDULE}}/,getNextSchedule(a['schedule']));
					} else if(a_key == 'idx'){
						agent_row = agent_row.replace(m,i)
					}
				})
				// console.log(agent_row);
				$("#schedule_table").append(agent_row);
			});
			$("#schedule_table button").bind("click", function(){
				var that = this;
				$(this).attr("disabled",true).text("RUNNING");
				var agent_id = $(this).attr("data-agent-id");
				chrome.runtime.sendMessage({runAgent: true, agent_id: agent_id});
				var clickedAgent = agents.filter(x=>x.agent_id == agent_id)[0];
				$("#notification_alert").hide(0).remove();
				var alert = $("<div />",{id:'notification_alert'});
				alert.text("Running agent : "+clickedAgent.name);
				alert.appendTo($("body"));
				setTimeout(function(){
					$("#notification_alert").hide(500).remove();
					$(that).removeAttr("disabled").text("RUN NOW");
				},3000);
			})
			$("#schedule_table").removeAttr("hidden");
		} else {
			$("#schedule_table").hide();
		}
	})
}

function getNextSchedule(schedule){
	function getScheduledDate(a, add_7){
		var d;
		var x = new Date();
		if(add_7){
			d = new Date(x.setDate(x.getDate()+(7-a.day)%7));
		} else {
			d = new Date(x.setDate(x.getDate()+((7-x.getDay() + a.day)%7)));
		}
		d.setHours(a.hour);
		d.setMinutes(a.minute);
		d.setSeconds(0);
		return d;
	}
	var finalDate = false;
	schedule.forEach(function(a){
		var d = getScheduledDate(a);
		if(d.getTime() - Date.now() < 0){
			d = getScheduledDate(a, true)
		}
		finalDate = d;
	});
	if(finalDate){
		return finalDate.toDateString() + " at " + finalDate.toLocaleTimeString()
	}
}

/*
var x = new Date();
var d = new Date(x.setDate(x.getDate()+(7-0%7)))
d.setHours(10);
d.setMinutes(0);
d.setSeconds(0);
console.log(d)
*/