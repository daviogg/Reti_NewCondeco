var Building = /** @class */ (function () {
    function Building() {
    }
    return Building;
}());
function getAllBuildings() {
    $('#list-of-buildings').empty();
    $('#select-room-building').empty();
    $.getJSON(webApiUri + 'buildings/GetAll/').done(function (building) {
        $.each(building, function (key, item) {
            $('#list-of-buildings').append("<button type=\"button\" class=\"list-group-item\"  onclick=\"getBuildingDetails(" + item.BuildingId + ")\">" + item.Name + "</button>");
            $('#select-room-building').append("<option value=\"" + item.BuildingId + "\">" + item.Name + "</option>");
        });
    });
}
function createBuilding() {
    var name = $('#building-name').val().toString();
    var address = $('#building-address').val().toString();
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
        $('#frmBuilding').append("<label>Edificio Creato! Nome : " + name + ", Indirizzo: " + address + "</label>");
        _self.getAllBuildings();
    }).fail(function (jqXHR, textStatus, errorThrown) {
        alert("An error has occurred while creating building");
    });
}
function getBuildingDetails(buildingId) {
    $('#building-detail').empty();
    $.getJSON(webApiUri + 'buildings/GetBuilding/' + buildingId)
        .done(function (data) {
        var isAvaible = data.IsAvaible ? "Si" : "No";
        $('#building-detail').append("<label>DETTAGLIO EDIFICIO </label>\n                    <div class=\"row\" id=\"name-detail\">\n                        <p class=\"col-md-6\">Nome:</p>\n                        <p class=\"col-md-6\"> " + data.Name + " </p>\n                    </div>\n                    <div class=\"row\" id=\"address-detail\">\n                        <p class=\"col-md-6\">Indirizzo:</p>\n                        <p class=\"col-md-6\"> " + data.Address + " </p>\n                    </div>\n                    <div class=\"row\" id=\"avaible-detail\">\n                        <p class=\"col-md-6\">Disponibile:</p>\n                        <p class=\"col-md-6\"> " + isAvaible + " </p>\n                    </div>");
        return data;
    })
        .fail(function (jqXHR, textStatus, err) {
        alert('An error occurred while retrieving building details');
    });
}
function deleteBuilding(buildingId) {
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
//# sourceMappingURL=Buildings.js.map