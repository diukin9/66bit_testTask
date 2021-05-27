const hubConnection = new signalR.HubConnectionBuilder()
    .withUrl("/PlayerHub")
    .build();
hubConnection.start();
try {
    hubConnection.on("putToList", function (name, surname, gender, team, nation, birthdate) {
        console.log("recieved");
        var tbody = document.getElementById("PlayersTable");
        var tr = document.createElement("tr");
        tbody.appendChild(tr);
        var td = document.createElement("td");
        tr.appendChild(td);
        td.textContent = name;
        td.style.borderTop = "1px solid rgba(255, 255, 255, 0.05)"
        td.style.textAlign = "center";

        td = document.createElement("td");
        tr.appendChild(td);
        td.textContent = surname;
        td.style.textAlign = "center";
        td.style.borderTop = "1px solid rgba(255, 255, 255, 0.05)";

        td = document.createElement("td");
        tr.appendChild(td);
        td.textContent = gender;
        td.style.textAlign = "center";
        td.style.borderTop = "1px solid rgba(255, 255, 255, 0.05)";

        td = document.createElement("td");
        tr.appendChild(td);
        td.textContent = team;
        td.style.textAlign = "center";
        td.style.borderTop = "1px solid rgba(255, 255, 255, 0.05)";

        td = document.createElement("td");
        tr.appendChild(td);
        td.textContent = nation;
        td.style.textAlign = "center";
        td.style.borderTop = "1px solid rgba(255, 255, 255, 0.05)";

        td = document.createElement("td");
        tr.appendChild(td);
        td.textContent = birthdate;
        td.style.textAlign = "center";
        td.style.borderTop = "1px solid rgba(255, 255, 255, 0.05)";
    });
} catch (err) {
    console.log(err);
    console.log("huy");
}