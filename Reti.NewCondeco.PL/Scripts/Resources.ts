
var webApiUri = 'http://localhost:8089/api';


class Resource {
    public ResourceId: number;
    public Username: string;
    public Surname: string;
    public Mail: string;
    public IsAvaible: boolean;
}

let _self = this;
//#endregion

//#region Page code
$(document).ready(() => {
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

    $.getJSON(webApiUri + '/resource/GetAllResources').done(resource => {

        $.each(resource, (key, item: Resource) => {
            $('#list-of-user-titles').append('<li class="list-group-item">' + item.Username + '<a style="margin-left:5px;" href="#" onclick="viewUserTitleDetails(' + item.ResourceId + ')">(View)</a><a style="margin-left:5px;" href="#" onclick="updateUserTitle(' + item.ResourceId + ');">(Update)</a><a style="margin-left:5px;" href="#" onclick="deleteUserTitle(' + item.ResourceId + ');">(Delete)</a></li>');
            $('#select-user-titles').append('<option value="' + item.ResourceId + '">' + item.Surname + '</option>');
        });

    });
}