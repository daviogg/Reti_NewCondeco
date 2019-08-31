var webApiUri = 'https://localhost:44394/api/';

//#region Page code
$(document).ready(() => {
    // Retrieve the lists of Users and UserTitles
    this.activeNav(ElementType.risorse);
});
//#endregion

//#region enums
enum ElementType {
    risorse = 0,
    aule = 1,
    edifici = 2,
    prenotazioni = 3
}
//#endregion

function activeNav(type: ElementType) {
    switch (type) {
        case ElementType.risorse:
            resetNavActiveClass();
            hideAllSections();
            $("#resources-nav").addClass("Active");
            $("#resources-section").show();
            break;
        case ElementType.aule:
            resetNavActiveClass();
            hideAllSections();
            $("#rooms-nav").addClass("Active");
            $("#rooms-section").show();
            _self.getAllBuildings();
            _self.getAllRooms();
            break;
        case ElementType.edifici:
            resetNavActiveClass();
            hideAllSections();
            $("#buildings-nav").addClass("Active");
            $("#buildings-section").show();
            _self.getAllBuildings();
            break;
        case ElementType.prenotazioni:
            resetNavActiveClass();
            hideAllSections() 
            $("#booking-nav").addClass("Active");
            $("#booking-section").show();
            $("#end-booking-section").hide();

            $('#select-room-booking').empty();
            $('#select-resource-booking').empty();

            _self.getAllBookings();
            _self.getAll();
            //_self.getAllRooms();
            break;
        default:
    }
}

function resetNavActiveClass() {
    $("#resources-nav").removeClass("Active");
    $("#rooms-nav" ).removeClass("Active");
    $("#buildings-nav").removeClass("Active"); 
    $("#booking-nav").removeClass("Active");
}

function hideAllSections() {
    $("#resources-section").hide();
    $("#buildings-section").hide();
    $("#rooms-section").hide();
    $("#booking-section").hide();
}




