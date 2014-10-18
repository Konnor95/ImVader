var user_id = null;

function initializeVk() {
    console.log("Page loaded");
    VK.init({
        apiId: 4575060
    });
    VK.Auth.getLoginStatus(authInfo);
    VK.UI.button('login_button');
}
function authInfo(response) {
    if (response.session) {
        //Hiding vk auth button
        $("#login_button").hide();
        $("#demo-content").removeClass("hidden");
        user_id = response.session.mid;
        VK.Api.call('users.get', { uids: response.session.mid, fields: "photo_200_orig,sex" }, function (r) {
            if (r.response) {
                var user = r.response[0];
                addNode(user);
                showUserInfo(user);
            }
        });

    } else {
        console.log('not auth');
    }
}

function getFriends() {

    var time = 0;
    //Getting user friends
    if (user_id != null) {
        if (checkHasNoFriends(user_id)) {
            startSpinner();
            VK.Api.call('friends.get', { user_id: user_id, fields: "photo_200_orig,sex" }, function (r) {
                if (r.response) {
                    var friends = r.response;
                    time = friends.length;
                    addFriends(friends);
                    stopSpinner(time);
                }
            }, function () { stopSpinner(time); });
        } else {
            console.log('already has friends');
        }
    }
    else {
        console.log('not auth');
    }

}
