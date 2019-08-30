
class Room {
    RoomId: number;
    Name: string;
    AvaiableSeats: number;
    RoomBuildingId : number;
    IsAvaible: true;
}




function getAllRooms() {
    $('#list-of-rooms').empty();
    $.getJSON(webApiUri + 'rooms/GetAll/').done(room => {
        $.each(room, (key, item: Room) => {
            $('#list-of-rooms').append(`<button type="button" class="list-group-item"  onclick="getRoomDetails(${item.RoomId})">${item.Name}</button>`);
        });
    });
}

function createRoom(): void {

    //$('#frmRoom').empty();
    let name: string = $('#room-name').val().toString();
    let avaiableSeats: number = <number>$('#room-avaiable-seats').val();
    let buildingId: number = <number>$('#select-room-building').val();

    $.ajax({
        type: "POST",
        url: webApiUri + 'rooms/PostRoom',
        contentType: 'application/json',
        data: JSON.stringify({
            RoomId: null,
            Name: name,
            AvaiableSeats: avaiableSeats,
            RoomBuildingId: buildingId,
            IsAvaible: true
        })
    }).done(function (data) {
        console.log(JSON.stringify(data));
        $('#frmRoom').append(`<label>Aula Creata! Nome : ${name}, Posti disponibili: ${avaiableSeats}</label>`);
        _self.getAllRooms();
    }).fail(function (jqXHR, textStatus, errorThrown) {
        alert("An error has occurred while creating room");
    });

}

function getRoomDetails(roomId: number) {
    $('#room-detail').empty();
    $.getJSON(webApiUri + 'rooms/GetRoom/' + roomId)
        .done(function (data: Room) {

            let isAvaible: string = data.IsAvaible ? "Si" : "No";

            $('#room-detail').append(`<label>DETTAGLIO AULA <a style="margin-left:5px;" onclick="deleteRoom(${data.RoomId})">Delete</a></label>
                    <div class="row" id="name-detail">
                        <p class="col-md-6">Nome:</p>
                        <p class="col-md-6"> ${data.Name} </p>
                    </div>
                    <div class="row" id="avaiable-seats-detail">
                        <p class="col-md-6">Posti disponibili:</p>
                        <p class="col-md-6"> ${data.AvaiableSeats} </p>
                    </div>
                    <div class="row" id="avaible-detail">
                        <p class="col-md-6">Disponibile:</p>
                        <p class="col-md-6"> ${isAvaible} </p>
                    </div>`);
        })
        .fail(function (jqXHR, textStatus, err) {
            alert('An error occurred while retrieving room details');
        });
}
function deleteRoom(roomId: number) {

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
