let windowInnerWidth = document.documentElement.clientWidth;
let url = window.location.href.split("/");
for (let item of url) {
    if (item.toLowerCase() === "edit") {
        document.getElementById("half-contact").style.marginTop = "10%";
    }
}
if (document.getElementById("contact") !== null && document.getElementById("randomText") !== null) {
    if (windowInnerWidth < 1170) {
        document.getElementById("contact").style.padding = "0";
        document.getElementById("randomText").style.fontsize = "24px";
    } else {
        document.getElementById("contact").style.padding = "0 33%";
        document.getElementById("randomText").style.fontsize = "42px";
    }
}