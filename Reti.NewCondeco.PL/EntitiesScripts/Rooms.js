var Room = /** @class */ (function () {
    function Room() {
    }
    return Room;
}());
function getAllRooms() {
    $('#list-of-rooms').empty();
    $('#select-room-booking').empty();
    $.getJSON(webApiUri + 'rooms/GetAll/').done(function (room) {
        $.each(room, function (key, item) {
            $('#list-of-rooms').append("<button type=\"button\" class=\"list-group-item\"  onclick=\"getRoomDetails(" + item.RoomId + ")\">" + item.Name + " - Id: " + item.RoomId + "</button>");
            if (item.IsAvaible)
                $('#select-room-booking').append("<option value=\"" + item.RoomId + "\">" + item.Name + " IdStanza: " + item.RoomId + "</option>");
        });
    });
}
function createRoom() {
    var name = $('#room-name').val().toString();
    var avaiableSeats = $('#room-avaiable-seats').val();
    var buildingId = $('#select-room-building').val();
    $.ajax({
        type: "POST",
        url: webApiUri + 'rooms/PostRoom',
        contentType: 'application/json',
        data: JSON.stringify({
            RoomId: null,
            Name: name,
            AvaiableSeats: avaiableSeats,
            RoomBuildingId: buildingId,
            IsAvaible: true,
            OriginalAvaibleSeats: avaiableSeats
        })
    }).done(function (data) {
        console.log(JSON.stringify(data));
        $('#room-created').empty();
        $('#room-created').append("<label>Aula Creata! Nome : " + name + ", Posti disponibili: " + avaiableSeats + "</label>");
        _self.getAllRooms();
    }).fail(function (jqXHR, textStatus, errorThrown) {
        alert("An error has occurred while creating room");
    });
}
function getRoomDetails(roomId) {
    $('#room-detail').empty();
    $.getJSON(webApiUri + 'rooms/GetRoom/' + roomId)
        .done(function (data) {
        var isAvaible = data.IsAvaible ? "Si" : "No";
        $('#room-detail').append("<label>DETTAGLIO AULA </label>\n                    <div class=\"row\" id=\"name-detail\">\n                        <p class=\"col-md-6\">Nome:</p>\n                        <p class=\"col-md-6\"> " + data.Name + " </p>\n                    </div>\n                    <div class=\"row\" id=\"avaiable-seats-detail\">\n                        <p class=\"col-md-6\">Posti disponibili:</p>\n                        <p class=\"col-md-6\"> " + data.AvaiableSeats + " </p>\n                    </div>\n                    ");
    })
        .fail(function (jqXHR, textStatus, err) {
        alert('An error occurred while retrieving room details');
    });
}
function deleteRoom(roomId) {
    $.ajax({
        type: "DELETE",
        url: webApiUri + 'rooms/DeleteRoom/' + roomId,
        contentType: 'application/json'
    }).done(function (data) {
        $('#room-detail').empty();
        _self.getAllRooms();
    }).fail(function (jqXHR, textStatus, errorThrown) {
        alert("An error has occurred while deleting room");
    });
}
//# sourceMappingURL=Rooms.js.map