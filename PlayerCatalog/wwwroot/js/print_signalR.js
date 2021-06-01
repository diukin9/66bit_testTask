function fillTD(tr, td) {
    td = document.createElement("td");
    tr.appendChild(td);
    td.style.borderTop = "1px solid rgba(255, 255, 255, 0.05)"
    td.style.textAlign = "center";
    return td;
}

const hubConnection = new signalR.HubConnectionBuilder()
    .withUrl("/PlayerHub")
    .build();
hubConnection.start();
try {
    hubConnection.on("putToList", function (name, surname, gender, team, nation, birthdate, id) {
        let tbody = document.getElementById("PlayersTable");
        let tr = document.createElement("tr");
        tbody.appendChild(tr);
        let td = null;
        for (let item of [name, surname, gender, team, nation, birthdate]) {
            td = fillTD(tr, td);
            td.textContent = item;
        }
        td = fillTD(tr, td);
        let a = document.createElement("a");
        a.href = '/player/editplayer/' + id;
        a.textContent = "Редактировать";
        td.appendChild(a);
    });
} catch (err) {
    console.log(err);
}

