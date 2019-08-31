
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
    $('#select-room-booking').empty();

    

    $.getJSON(webApiUri + 'booking/GetAll/').done(booking => {
        bookingArray = booking;
        $.each(booking, (key, item: Booking) => {
            $('#list-of-booking').append(`<button type="button" class="list-group-item"  onclick="getBookingDetails(${item.BookingId})">${item.Description}</button>`);
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
        $('#frmBooking').append(`<label>Prenotazione Creata! Descrizione : ${description}, risorsa: ${resourceId}, stanza: ${roomId}, dalle: ${startDate} alle: ${endDate}</label>`);
        _self.getAllBookings();
    }).fail(function (jqXHR, textStatus, errorThrown) {
        alert("An error has occurred while creating booking");
    });

}

function getBookingDetails(bookingId: number) {
    $('#booking-detail').empty();
    $.getJSON(webApiUri + 'booking/GetBooking/' + bookingId)
        .done(function (data: Booking) {

            $('#booking-detail').append(`<label>DETTAGLIO PRENOTAZIONE </label>
                    <div class="row" id="description-detail">
                        <p class="col-md-6">Descrizione:</p>
                        <p class="col-md-6"> ${data.Description} </p>
                    </div>
                    <div class="row" id="room-detail">
                        <p class="col-md-6">Aula:</p>
                        <p class="col-md-6"> ${data.BRoomId} </p>
                    </div>
                    <div class="row" id="resource-detail">
                        <p class="col-md-6">Risorsa:</p>
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

//function filter() {
//    var input, filter, ul, li, a, i, txtValue;

//    input = $("#filterList").val();
//    filter = input.value.toUpperCase();
//    $.each(bookingArray)
//}
