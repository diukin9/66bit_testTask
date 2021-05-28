const hubConnection = new signalR.HubConnectionBuilder()
    .withUrl("/PlayerHub")
    .build();
hubConnection.start();

document.getElementById("sendButton").addEventListener("click", function (e) {
    var name = document.getElementById("name").value;
    var surname = document.getElementById("surname").value;
    var gender = document.getElementById("gender").value;
    var team = document.getElementById("team").value;
    var nation = document.getElementById("nation").value;
    var birthdate = document.getElementById("birthdate").value;
    hubConnection.invoke("SendToList", name, surname,
        gender, team, nation, birthdate);
});
