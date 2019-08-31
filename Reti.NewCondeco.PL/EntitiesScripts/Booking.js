var Booking = /** @class */ (function () {
    function Booking() {
    }
    return Booking;
}());
function getAllBookings() {
    $('#list-of-bookings').empty();
    $('#select-room-booking').empty();
    $.getJSON(webApiUri + 'booking/GetAll/').done(function (booking) {
        $.each(booking, function (key, item) {
            $('#list-of-booking').append("<button type=\"button\" class=\"list-group-item\"  onclick=\"getBookingDetails(" + item.BookingId + ")\">" + item.Description + "</button>");
        });
    });
}
function createBooking() {
    var description = $('#booking-description').val().toString();
    var resourceId = $('#select-resource-booking').val();
    var roomId = $('#select-room-booking').val();
    var startDate = $('#start-booking-date').data('date');
    var endDate = $('#end-booking-date').data('date');
    $('#frmBooking').empty();
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
        $('#frmBooking').append("<label>Prenotazione Creata! Descrizione : " + description + ", risorsa: " + resourceId + ", stanza: " + roomId + ", dalle: " + startDate + " alle: " + endDate + "</label>");
        _self.getAllBookings();
    }).fail(function (jqXHR, textStatus, errorThrown) {
        alert("An error has occurred while creating booking");
    });
}
function getBookingDetails(bookingId) {
    $('#booking-detail').empty();
    $.getJSON(webApiUri + 'booking/GetBooking/' + bookingId)
        .done(function (data) {
        $('#booking-detail').append("<label>DETTAGLIO PRENOTAZIONE </label>\n                    <div class=\"row\" id=\"description-detail\">\n                        <p class=\"col-md-6\">Descrizione:</p>\n                        <p class=\"col-md-6\"> " + data.Description + " </p>\n                    </div>\n                    <div class=\"row\" id=\"room-detail\">\n                        <p class=\"col-md-6\">Aula:</p>\n                        <p class=\"col-md-6\"> " + data.BRoomId + " </p>\n                    </div>\n                    <div class=\"row\" id=\"resource-detail\">\n                        <p class=\"col-md-6\">Risorsa:</p>\n                        <p class=\"col-md-6\"> " + data.BResourceId + " </p>\n                    </div>\n                    <div class=\"row\" id=\"start-date-detail\">\n                        <p class=\"col-md-6\">Dalle:</p>\n                        <p class=\"col-md-6\"> " + data.DateStart + " </p>\n                    </div>\n                    <div class=\"row\" id=\"end-date-detail\">\n                        <p class=\"col-md-6\">Alle:</p>\n                        <p class=\"col-md-6\"> " + data.DateEnd + " </p>\n                    </div>\n                    ");
        return data;
    })
        .fail(function (jqXHR, textStatus, err) {
        alert('An error occurred while retrieving booking details');
    });
}
function deleteBooking(bookingId) {
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
//# sourceMappingURL=Booking.js.map