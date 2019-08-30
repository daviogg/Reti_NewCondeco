
class Building {
    BuildingId: number;
    Name: string;
    Address: string;
    IsAvaible: boolean;
}




function getAllBuildings() {
    $('#list-of-buildings').empty();
    $('#select-room-building').empty();
    $.getJSON(webApiUri + 'buildings/GetAll/').done(building => {
        $.each(building, (key, item: Building) => {
            $('#list-of-buildings').append(`<button type="button" class="list-group-item"  onclick="getBuildingDetails(${item.BuildingId})">${item.Name}</button>`);
            $('#select-room-building').append(`<option value="${item.BuildingId}">${item.Name}</option>`);
        });
    });
}

function createBuilding(): void {

    //$('#frmBuilding').empty();
    let name: string = $('#building-name').val().toString();
    let address: string = $('#building-address').val().toString();

    $.ajax({
        type: "POST",
        url: webApiUri + 'buildings/PostBuilding',
        contentType: 'application/json',
        data: JSON.stringify({
            BuildingId: null,
            Name: name,
            Address: address,
            IsAvaible: true
        })
    }).done(function (data) {
        console.log(JSON.stringify(data));
        $('#frmBuilding').append(`<label>Edificio Creato! Nome : ${name}, Indirizzo: ${address}</label>`);
        _self.getAllBuildings();
    }).fail(function (jqXHR, textStatus, errorThrown) {
        alert("An error has occurred while creating building");
    });

}

function getBuildingDetails (buildingId: number) {
    $('#building-detail').empty();
    $.getJSON(webApiUri + 'buildings/GetBuilding/' + buildingId)
        .done(function (data: Building) {

            let isAvaible: string = data.IsAvaible ? "Si" : "No";

            $('#building-detail').append(`<label>DETTAGLIO EDIFICIO <a style="margin-left:5px;" onclick="deleteBuilding(${data.BuildingId})">Delete</a></label>
                    <div class="row" id="name-detail">
                        <p class="col-md-6">Nome:</p>
                        <p class="col-md-6"> ${data.Name} </p>
                    </div>
                    <div class="row" id="address-detail">
                        <p class="col-md-6">Indirizzo:</p>
                        <p class="col-md-6"> ${data.Address} </p>
                    </div>
                    <div class="row" id="avaible-detail">
                        <p class="col-md-6">Disponibile:</p>
                        <p class="col-md-6"> ${isAvaible} </p>
                    </div>`);
            return data
        })
        .fail(function (jqXHR, textStatus, err) {
            alert('An error occurred while retrieving building details');
        });
}


function deleteBuilding(buildingId: number) {

    $.ajax({
        type: "DELETE",
        url: webApiUri + 'buildings/DeleteBuilding/' + buildingId,
        contentType: 'application/json'
    }).done(function (data) {
        $('#building-detail').empty();
        _self.getAllBuildings();
    }).fail(function (jqXHR, textStatus, errorThrown) {
        alert("An error has occurred while deleting building");
    });
}
