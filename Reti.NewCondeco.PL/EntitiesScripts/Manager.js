var _this = this;
var webApiUri = 'https://localhost:44394/api/';
//#region Page code
$(document).ready(function () {
    // Retrieve the lists of Users and UserTitles
    _this.activeNav(ElementType.risorse);
});
//#endregion
//#region enums
var ElementType;
(function (ElementType) {
    ElementType[ElementType["risorse"] = 0] = "risorse";
    ElementType[ElementType["aule"] = 1] = "aule";
    ElementType[ElementType["edifici"] = 2] = "edifici";
    ElementType[ElementType["prenotazioni"] = 3] = "prenotazioni";
})(ElementType || (ElementType = {}));
//#endregion
function activeNav(type) {
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
            hideAllSections();
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
    $("#rooms-nav").removeClass("Active");
    $("#buildings-nav").removeClass("Active");
    $("#booking-nav").removeClass("Active");
}
function hideAllSections() {
    $("#resources-section").hide();
    $("#buildings-section").hide();
    $("#rooms-section").hide();
    $("#booking-section").hide();
}
//# sourceMappingURL=Manager.js.map