//#region Page code
$(document).ready(function () {
    // Retrieve the lists of Users and UserTitles
    _self.getAll();
});
//#endregion
//var webApiUri = 'https://localhost:44394/api/';
var Resource = /** @class */ (function () {
    function Resource() {
    }
    return Resource;
}());
var _self = this;
function getAll() {
    $('#list-of-resources').empty();
    $.getJSON(webApiUri + 'resources/GetAll/').done(function (resource) {
        $.each(resource, function (key, item) {
            $('#list-of-resources').append("<button type=\"button\" class=\"list-group-item\"  onclick=\"getResourceDetails(" + item.ResourceID + ")\">" + item.UserName + "</button>");
        });
    });
}
function createResource() {
    //$('#frmUser').empty();
    var name = $('#user-name').val().toString();
    var surname = $('#user-surname').val().toString();
    var username = "";
    if (surname.length >= 4) {
        username = surname.substr(0, 4);
        if (name.length >= 2)
            username += name.substr(0, 2);
        else
            username += name;
    }
    else {
        if (surname.length < 4)
            username = name + surname;
        else
            username = name + surname.substr(0, 4);
    }
    $.ajax({
        type: "POST",
        url: webApiUri + 'resources/PostResource',
        contentType: 'application/json',
        data: JSON.stringify({
            ResourceID: -1,
            UserName: username,
            SurName: $('#user-surname').val(),
            Name: $('#user-name').val(),
            Mail: $('#email').val(),
            IsAvaible: true,
            Booking: [],
        })
    }).done(function (data) {
        console.log(JSON.stringify(data));
        $('#frmUser').append("<label>Utente Creato! Username : " + username + "</label>");
        _self.getAll();
    }).fail(function (jqXHR, textStatus, errorThrown) {
        alert("An error has occurred while creating resource");
    });
}
function getResourceDetails(resourceId) {
    $('#resource-detail').empty();
    $.getJSON(webApiUri + 'resources/GetResource/' + resourceId)
        .done(function (data) {
        var isAvaible = data.IsAvaible ? "Si" : "No";
        $('#resource-detail').append("<label>DETTAGLIO RISORSA <a style=\"margin-left:5px;\" onclick=\"deleteResource(" + data.ResourceID + ")\">Delete</a></label>\n                    <div class=\"row\" id=\"username-detail\">\n                        <p class=\"col-md-6\">Username:</p>\n                        <p> " + data.UserName + " </p>\n                    </div>\n                    <div class=\"row\" id=\"name-detail\">\n                        <p class=\"col-md-6\">Nome:</p>\n                        <p> " + data.Name + " </p>\n                    </div>\n                    <div class=\"row\" id=\"surname-detail\">\n                        <p class=\"col-md-6\">Cognome:</p>\n                        <p> " + data.SurName + " </p>\n                    </div>\n                    <div class=\"row\" id=\"mail-detail\">\n                        <p class=\"col-md-6\">Mail:</p>\n                        <p> " + data.Mail + " </p>\n                    </div>\n                    <div class=\"row\" id=\"avaible-detail\">\n                        <p class=\"col-md-6\">Disponibile:</p>\n                        <p> " + isAvaible + " </p>\n                    </div>");
    })
        .fail(function (jqXHR, textStatus, err) {
        alert('An error occurred while retrieving Resource details');
    });
}
function deleteResource(resourceId) {
    $.ajax({
        type: "DELETE",
        url: webApiUri + 'resources/DeleteResource/' + resourceId,
        contentType: 'application/json'
    }).done(function (data) {
        $('#resource-detail').empty();
        _self.getAll();
    }).fail(function (jqXHR, textStatus, errorThrown) {
        alert("An error has occurred while deleting UserTitle");
    });
}
//# sourceMappingURL=Resources.js.map