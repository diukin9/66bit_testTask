let urlurlurl = window.location.href.split("/");
let flag = -1;
let page = null;
for (let item of urlurlurl) {
    if (item.toLowerCase() === "home") {
        flag = 0;
    } else if (item.toLowerCase() === "list" || item.toLowerCase() === "index" || item.toLowerCase() === "edit") {
        flag = 1;
        page = item.toLowerCase();
    }
}
if (flag === -1) {
    document.getElementById("bg").style.backgroundImage = "url(/images/bg.jpg)";
    let newUrl = urlurlurl.join("/");
    if (newUrl[newUrl.length - 1] !== "/") {
        newUrl += "/";
    }
    document.getElementById("about").href = newUrl + "home/list";
} else if (flag === 0) {
    document.getElementById("bg").style.backgroundImage = "url(/images/bg.jpg)";
    let newUrl = urlurlurl.join("/");
    if (newUrl[newUrl.length - 1] !== "/") {
        newUrl += "/";
    }
    document.getElementById("about").href = newUrl + "list";
} else {
    let newUrl = "";
    let array = [];
    for (let i = 0; i < urlurlurl.length; i++) {
        if (urlurlurl[i].toLowerCase() !== "list" && urlurlurl[i].toLowerCase() !== "index" && urlurlurl[i].toLowerCase() !== "edit") {
            array.push(urlurlurl[i]);
        }
        else break;
    }
    newUrl = array.join("/");
    if (newUrl[newUrl.length - 1] !== "/") {
        newUrl += "/";
    }
    if (page === "list") {
        document.getElementById("bg").style.backgroundImage = "url(/images/bg-empty.jpg)";
        document.getElementById("about").href = newUrl + "index";
    } else if (page === "edit") {
        document.getElementById("bg").style.backgroundImage = "url(/images/bg-empty.jpg)";
        document.getElementById("about").href = newUrl + "list";
        document.getElementById("customBtn").innerHTML = "<i>&boxh;</i>вернуться назад<i>&boxh;</i>";
    } else {
        document.getElementById("bg").style.backgroundImage = "url(/images/bg.jpg)";
        document.getElementById("about").href = newUrl + "list";
    }
}