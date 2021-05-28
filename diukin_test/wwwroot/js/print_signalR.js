const hubConnection = new signalR.HubConnectionBuilder()
    .withUrl("/PlayerHub")
    .build();
hubConnection.start();
try {
    hubConnection.on("putToList", function (name, surname, gender, team, nation, birthdate) {
        var tbody = document.getElementById("PlayersTable");
        var tr = document.createElement("tr");
        tbody.appendChild(tr);
        var td = null;
        for (let item of [name, surname, gender, team, nation, birthdate, ""]) {
            td = document.createElement("td");
            tr.appendChild(td);
            td.textContent = item;
            td.style.borderTop = "1px solid rgba(255, 255, 255, 0.05)"
            td.style.textAlign = "center";
        }
    });
} catch (err) {
    console.log(err);
}