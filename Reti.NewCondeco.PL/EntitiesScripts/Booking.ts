
class Booking {
    BookingId: number;
    Description: string;
    BResourceId: number;
    DateStart: Date;
    DateEnd: Date;
    BRoomId: number;
}


let bookingArray: Array<Booking> = [];

function getAllBookings() {
    $('#list-of-booking').empty();
    $.getJSON(webApiUri + 'booking/GetAll/').done(booking => {
        bookingArray = booking;
        $.each(booking, (key, item: Booking) => {
            $('#list-of-booking').append(`<button type="button" class="list-group-item"  onclick="getBookingDetails(${item.BookingId})">${item.Description} - Id: ${item.BookingId} </button>`);
        });
    });
}

function createBooking(): void {

    let description: string = $('#booking-description').val().toString();
    let resourceId: number = <number>$('#select-resource-booking').val();
    let roomId: number = <number>$('#select-room-booking').val();
    let startDate: Date = $('#start-booking-date').data('date');
    let endDate: Date = $('#end-booking-date').data('date');
    $.ajax({
        type: "POST",
        url: webApiUri + 'booking/PostBooking',
        contentType: 'application/json',
        data: JSON.stringify({
            BookingId: null,
            Description: description,
            BResourceId: resourceId,
            DateStart: startDate,
            DateEnd: endDate,
            BRoomId: roomId
        })
    }).done(function (data) {
        console.log(JSON.stringify(data));
        $('#booking-created').empty();
        $('#booking-created').append(`<label>Prenotazione Creata! Descrizione : ${description}, risorsa: ${resourceId}, stanza: ${roomId}, dalle: ${startDate} alle: ${endDate}</label>`);
        $("#end-booking-section").hide();
        _self.getAllBookings();
    }).fail(function (jqXHR, textStatus, errorThrown) {
        alert("An error has occurred while creating booking");
    });

}

function getBookingDetails(bookingId: number) {
    $('#booking-detail').empty();
    $.getJSON(webApiUri + 'booking/GetBooking/' + bookingId)
        .done(function (data: Booking) {

            $('#booking-detail').append(`<label>DETTAGLIO PRENOTAZIONE <a style="margin-left:5px;" onclick="deleteBooking(${data.BookingId})">Delete</a> </label>
                    <div class="row" id="description-detail">
                        <p class="col-md-6">Descrizione:</p>
                        <p class="col-md-6"> ${data.Description} </p>
                    </div>
                    <div class="row" id="room-detail">
                        <p class="col-md-6">IdAula:</p>
                        <p class="col-md-6"> ${data.BRoomId} </p>
                    </div>
                    <div class="row" id="resource-detail">
                        <p class="col-md-6">IdRisorsa:</p>
                        <p class="col-md-6"> ${data.BResourceId} </p>
                    </div>
                    <div class="row" id="start-date-detail">
                        <p class="col-md-6">Dalle:</p>
                        <p class="col-md-6"> ${data.DateStart} </p>
                    </div>
                    <div class="row" id="end-date-detail">
                        <p class="col-md-6">Alle:</p>
                        <p class="col-md-6"> ${data.DateEnd} </p>
                    </div>
                    `);
            return data
        })
        .fail(function (jqXHR, textStatus, err) {
            alert('An error occurred while retrieving booking details');
        });
}


function deleteBooking(bookingId: number) {

    $.ajax({
        type: "DELETE",
        url: webApiUri + 'booking/DeleteBooking/' + bookingId,
        contentType: 'application/json'
    }).done(function (data) {
        $('#booking-detail').empty();
        _self.getAllBookings();
    }).fail(function (jqXHR, textStatus, errorThrown) {
        alert("An error has occurred while deleting booking");
    });
}

function checkAvaible() {
    let startDate: Date = $('#start-booking-date').data('date');
    let endDate: Date = $('#end-booking-date').data('date');

    $("#end-booking-section").show();
    $.ajax({
        type: "POST",
        url: webApiUri + `booking/CheckAvaibleRooms`,
        contentType: 'application/json',
        data: JSON.stringify({
            DateStart: startDate,
            DateEnd: endDate
        })
    }).done(function (data) {
        _self.getAllRooms();
    });

    $.ajax({
        type: "POST",
        url: webApiUri + `booking/CheckAvaibleResources`,
        contentType: 'application/json',
        data: JSON.stringify({
            DateStart: startDate,
            DateEnd: endDate
        })
    }).done(function (data) {
        _self.getAll();
    });

}

function filter() {
    var searchKey: string = $("#filterList").val().toString().toLowerCase();
    $('#list-of-booking').empty();
    let ba = bookingArray.filter(b => b.Description.toLowerCase().indexOf(searchKey) >= 0 || b.BookingId.toString().indexOf(searchKey) >= 0);
    ba.forEach(b => {
        $('#list-of-booking').append(`<button type="button" class="list-group-item"  onclick="getBookingDetails(${b.BookingId})">${b.Description} - Id: ${b.BookingId}</button>`);
    });
}
