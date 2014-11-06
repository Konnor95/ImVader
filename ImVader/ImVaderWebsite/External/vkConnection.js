var user_id = null;
var offset = 0;
var offsetArray = new Array();
var friends = null;
var counter = 0;

$(document).ready(function() {

});

function initializeVk() {
    VK.init({
        apiId: 4575060
    });
    VK.Auth.getLoginStatus(authInfo);
}
function authInfo(response) {
    if (response.session) {
        $("#vk-login-section").hide();
        $("#demo-content").removeClass("hidden");
        $("#myModal").modal("show");
        user_id = response.session.mid;
        VK.Api.call('users.get', { uids: response.session.mid, fields: "photo_200_orig,sex" }, function (r) {
            if (r.response) {
                var user = r.response[0];
                if (!isAdded(user.uid))
                    addNode(user);
                showUserInfo(user);
            }
        });
    } else {
        console.log('not auth');
    }
}

function getFriends() {
    startSpinner();
    var time = 0;
    //Getting user friends
    if (user_id != null) {
        if (checkHasNoFriends(user_id)) {
            if (!offsetArray[user_id]) {
                offsetArray[user_id] = 0;
            }
            var code = 'var friends = API.friends.get({ "user_id": ' + parseInt(user_id) + ', "fields": "photo_200_orig,sex", "offset": ' + offsetArray[user_id] + ', "count": 20 });\n' +
                'var i = 0;\n var obj = [];\n' +
                'while (i != parseInt(friends.length) && i <= 20) {\n' +
                'var mutual = API.friends.getMutual({ "source_uid": ' + parseInt(user_id) + ', "target_uid": friends[i].uid });\n' +
                'if (parseInt(mutual.length)!=0){' +
                'obj.push({ "uid": friends[i].uid, "photo_200_orig": friends[i].photo_200_orig, "sex" : friends[i].sex, "first_name": friends[i].first_name, "last_name": friends[i].last_name, "count": mutual.length });\n' +
                '}'+
                'i = i + 1;\n }\n' +
                'return obj;';
            VK.api('execute', {
                code: code
            }, function (resp) {
                resp = resp.response;
                if (resp) {
                    offsetArray[user_id] += 20;
                    time = resp.length;
                    for (var i = 0; i < resp.length; i++) {
                        if (resp[i].count != 0) {
                            if (!isAdded(resp[i].uid)) {
                                addNode(resp[i]);
                            }
                            if (!hasEdge(user_id, resp[i].uid))
                                addEdge(user_id, resp[i].uid, resp[i].count);
                        }
                    }
                }
                stopSpinner(time);
            });
        } else {
            console.log('already has friends');
        }
    }
    else {
        console.log('not auth');
    }
}