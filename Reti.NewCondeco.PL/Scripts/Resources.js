var webApiUri = 'https://localhost:44394/api/';
var Resource = /** @class */ (function () {
    function Resource() {
    }
    return Resource;
}());
var _self = this;
//#endregion
//#region Page code
$(document).ready(function () {
    // Retrieve the lists of Users and UserTitles
    _self.getAll();
});
function getAll() {
    $('#select-resources').empty();
    // Retrieve the list of User Titles
    //$.getJSON(webApiUri + '/usertitles')
    //    .done(function (userTitles) {
    //        // Retrieve the list of Users
    //        $.getJSON(webApiUri + '/users')
    //            .done(function (users) {
    //                retrievedUserTitles = userTitles;
    //                $.each(userTitles, function (key, item) {
    //                    $('#list-of-user-titles').append('<li class="list-group-item">' + formatUserTitle(item) + '<a style="margin-left:5px;" href="#" onclick="viewUserTitleDetails(' + item.Id + ')">(View)</a><a style="margin-left:5px;" href="#" onclick="updateUserTitle(' + item.Id + ');">(Update)</a><a style="margin-left:5px;" href="#" onclick="deleteUserTitle(' + item.Id + ');">(Delete)</a></li>');
    //                    $('#select-user-titles').append('<option value="' + item.Id + '">' + item.Description + '</option>');
    //                });
    //                $.each(users, function (key, item) {
    //                    $('#list-of-users').append('<li class="list-group-item">' + formatUser(item) + '<a style="margin-left:5px;" href="#" onclick="viewUserDetails(' + item.Id + ')">(View)</a><a style="margin-left:5px;" href="#" onclick="updateUser(' + item.Id + ');">(Update)</a><a style="margin-left:5px;" href="#" onclick="deleteUser(' + item.Id + ');">(Delete)</a></li>');
    //                });
    //            })
    //            .fail(function (jqXHR, textStatus, err) {
    //                alert('An error occurred while loading Users and UserTitles');
    //            });
    //    })
    //    .fail(function (jqXHR, textStatus, err) {
    //        alert('An error occurred while loading Users and UserTitles');
    //    });
    $.getJSON(webApiUri + 'resource/GetAllResources/').done(function (resource) {
        $.each(resource, function (key, item) {
            //$('#list-of-resources').append('<li><a href="#">' + item.UserName + '</a></li>');
            $('#list-of-resources').append('<button type="button" class="list-group-item" >' + item.UserName + '</button>');
        });
    });
}
//# sourceMappingURL=Resources.js.map