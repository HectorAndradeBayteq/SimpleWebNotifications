const connection = new signalR.HubConnectionBuilder()
    .withUrl("https://localhost:7290/notificatorHub")
    .build();


connection.start().then(function () {
    console.log("Connected to hub.");
}).catch(function (err) {
    return console.error(err.toString());
});

 

connection.on("ReceiveMessage", function (message) {
    const messagesList = document.getElementById("messages");
    const messageItem = document.createElement("li");
    messageItem.textContent = message;
    messagesList.appendChild(messageItem);
});

 

document.getElementById("sendButton").addEventListener("click", function (event) {
    const message = document.getElementById("messageInput").value;
    connection.invoke("SendMessage", message).catch(function (err) {
        return console.error(err.toString());
    });
    event.preventDefault();
});