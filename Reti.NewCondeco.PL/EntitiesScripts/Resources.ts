//#region Page code
$(document).ready(() => {
    // Retrieve the lists of Users and UserTitles
    _self.getAll();

});
//#endregion

//var webApiUri = 'https://localhost:44394/api/';


class Resource {
    public ResourceID: number;
    public Name: string;
    public SurName: string;
    public UserName: string;
    public Mail: string;
    public IsAvaible: boolean;
}

let _self = this;


function getAll() {
    $('#list-of-resources').empty();
    $('#select-resource-booking').empty();

    $.getJSON(webApiUri + 'resources/GetAll/').done(resource => {

        $.each(resource, (key, item: Resource) => {
            $('#list-of-resources').append(`<button type="button" class="list-group-item"  onclick="getResourceDetails(${item.ResourceID})">${item.UserName}</button>`);
            if (item.IsAvaible)
                $('#select-resource-booking').append(`<option value="${item.ResourceID}">${item.Name} ${item.SurName}</option>`);
        });

    });
}

function createResource(): void {

    
    let name: string = $('#user-name').val().toString();
    let surname: string = $('#user-surname').val().toString();
    let username: string = "";

    if (surname.length >= 4) {
        username = surname.substr(0, 4);
        if (name.length >= 2)
            username += name.substr(0, 2);
        else
            username += name;
    } else {
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
        $('#frmUser').append(`<label>Utente Creato! Username : ${username}</label>`);
        _self.getAll();
    }).fail(function (jqXHR, textStatus, errorThrown) {
        alert("An error has occurred while creating resource");
    });

}

function getResourceDetails(resourceId: number) {
    $('#resource-detail').empty();
    $.getJSON(webApiUri + 'resources/GetResource/' + resourceId)
        .done(function (data: Resource) {
            
            let isAvaible: string = data.IsAvaible ? "Si" : "No";

            $('#resource-detail').append(`<label>DETTAGLIO RISORSA <a style="margin-left:5px;" onclick="deleteResource(${data.ResourceID})">Delete</a></label>
                    <div class="row" id="username-detail">
                        <p class="col-md-6">Username:</p>
                        <p class="col-md-6"> ${data.UserName} </p>
                    </div>
                    <div class="row" id="name-detail">
                        <p class="col-md-6">Nome:</p>
                        <p class="col-md-6"> ${data.Name} </p>
                    </div>
                    <div class="row" id="surname-detail">
                        <p class="col-md-6">Cognome:</p>
                        <p class="col-md-6"> ${data.SurName} </p>
                    </div>
                    <div class="row" id="mail-detail">
                        <p class="col-md-6">Mail:</p>
                        <p class="col-md-6"> ${data.Mail} </p>
                    </div>
                    <div class="row" id="avaible-detail">
                        <p class="col-md-6">Disponibile:</p>
                        <p class="col-md-6"> ${isAvaible} </p>
                    </div>`);
        })
        .fail(function (jqXHR, textStatus, err) {
            alert('An error occurred while retrieving Resource details');
        });
}
function deleteResource(resourceId: number) {
  
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
