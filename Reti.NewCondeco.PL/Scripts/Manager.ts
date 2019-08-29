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




