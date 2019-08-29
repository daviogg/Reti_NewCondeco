var _this = this;
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
            break;
        case ElementType.aule:
            break;
        case ElementType.edifici:
            break;
        case ElementType.prenotazioni:
            break;
        default:
    }
}
//# sourceMappingURL=Manager.js.map