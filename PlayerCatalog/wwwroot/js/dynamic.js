let baseUrl = window.location.href.toLowerCase();
let rootRoute = getRootRoute(baseUrl);
let page = findCurrentPage(baseUrl);
let ref = document.getElementById("about");

if (page === 'editplayer') {
    let culture = '';
    document.cookie.split(';').forEach(x => {
        if (x.includes('.AspNetCore.Culture')) {
            culture = x.slice(-2);
        }
    });
    let button = document.getElementById('customBtn');
    if (culture === 'de')
        button.innerHTML = '<i>─</i>Rücken an Rücken<i>─</i>';
    else if (culture === 'en')
        button.innerHTML = '<i>─</i>Go back<i>─</i>';
    else button.innerHTML = '<i>─</i>Вернуться назад<i>─</i>';
}
let background = document.getElementById("bg");
background.style.background = findBackground(page);
ref.href = getRef(page, rootRoute);

function findCurrentPage(baseUrl) {
    let result = null;
    let defaultPages = ['index', 'addplayer', 'playerlist', 'editplayer'];
    for (let route of baseUrl.split('/')) {
        if (route.includes('?')) route = route.split('?')[0];
        if (defaultPages.includes(route.toLowerCase())) {
            result = route;
            break;
        }
    }
    return result ? result : 'index';
}

function getRootRoute(baseUrl) {
    let result = [];
    let flag = false;
    let defaultPages = ['home', 'player'];
    for (let route of baseUrl.split('/')) {
        if (route.includes('?')) route = route.split('?')[0];
        for (let defaultPage of defaultPages)
            if (route && route.includes(defaultPage)) flag = true;
        if (flag) break;
        result.push(route);
    }
    return result.join('/');
}

function findBackground(page) {
    if (page === 'playerlist') return 'url(/images/bg-empty.jpg)';
    else return 'url(/images/bg.jpg)';
}

function getRef(page, rootRoute) {
    if (page === 'index' || page === 'playerlist')
        return connectLinkParts(rootRoute, 'player/addplayer');
    else if (page === 'addplayer' || page === 'editplayer')
        return connectLinkParts(rootRoute, 'player/playerlist');
    else return rootRoute;
}

function connectLinkParts(rootRoute, remainingRoute) {
    if (rootRoute[rootRoute.length - 1] === '/')
        return `${rootRoute}${remainingRoute}`;
    else return `${rootRoute}/${remainingRoute}`;
}