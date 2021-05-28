let splitUrl = window.location.href.split("/");
let flag = -1;
let page = null;
for (let item of splitUrl) {
    if (item.toLowerCase() === "home") flag = 0;
    else if (["list", "index", "edit"].includes(item.toLowerCase())) {
        flag = 1;
        page = item.toLowerCase();
    }
}
if (flag === -1) {
    document.getElementById("bg").style.backgroundImage = "url(/images/bg.jpg)";
    let newUrl = addSlash(splitUrl.join("/"));
    document.getElementById("about").href = newUrl + "home/list";
} else if (flag === 0) {
    document.getElementById("bg").style.backgroundImage = "url(/images/bg.jpg)";
    let newUrl = addSlash(splitUrl.join("/"));
    document.getElementById("about").href = newUrl + "list";
} else {
    let newUrl = "";
    let array = [];
    for (let i = 0; i < splitUrl.length; i++) {
        if (!["list", "index", "edit"].includes(splitUrl[i].toLowerCase())) array.push(splitUrl[i]);
        else break;
    }
    newUrl = addSlash(array.join("/"));
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

function addSlash(str) {
    if (str[str.length - 1] !== "/") str += "/";
    return str;
}