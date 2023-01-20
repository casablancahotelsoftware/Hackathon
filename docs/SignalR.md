# SignalR

SignalR ist eine Echtzeit-Kommunikationsbibliothek für .NET, die eine einfache, bidirektionale Kommunikation zwischen einem Server und einem oder mehreren Clients ermöglicht. SignalR verwendet WebSockets, um eine Kommunikation mit niedriger Latenz und hoher Frequenz zu ermöglichen, und greift automatisch auf andere Techniken wie Long Polling zurück, wenn WebSockets nicht verfügbar sind.

Hier ein Beispiel für die Einrichtung eines einfachen SignalR-Servers und -Clients in C#:

1. Auf der Serverseite müssen Sie die SignalR-Bibliothek mit NuGet zu Ihrem Projekt hinzufügen. Sobald das Paket installiert ist, können Sie eine neue Hub-Klasse erstellen, die die serverseitige Logik für Ihre Echtzeitkommunikation übernimmt. In der Hub-Klasse definieren Sie die Methoden, die der Client aufrufen kann, und die Methoden, die der Server auf dem Client aufrufen kann.

    ```csharp

    public class ChatHub : Hub
    {
        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }
    }


    ```

2. In der Startup-Klasse müssen Sie SignalR zur Pipeline hinzufügen und es dem oben erstellten Hub zuordnen.

    ```csharp

    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSignalR();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapHub<ChatHub>("/chat");
            });
        }
    }

    ```

3. Auf der Client-Seite müssen Sie die SignalR-Client-Bibliothek zu Ihrem Projekt hinzufügen. Sobald das Paket installiert ist, können Sie eine Verbindung zum Server herstellen und die Methoden des Hubs aufrufen.

    ```csharp

    private HubConnection connection;

    private async Task Connect()
    {
        connection = new HubConnectionBuilder()
            .WithUrl("http://localhost:5000/chat")
            .Build();

        // NOTE: This call has to be before connection.StartAsycn();
        connection.On<string, string>("ReceiveMessage", (user, message) =>
        {
            Console.WriteLine($"{user}: {message}");
        });

        await connection.StartAsync();
    }

    private async Task SendMessage(string user, string message)
    {
        await connection.InvokeAsync("SendMessage", user, message);
    }

    ```

In diesem Beispiel hat der Server eine ChatHub-Klasse mit einer einzigen Methode namens SendMessage. Der Client kann diese Methode aufrufen, indem er die Funktion "SendMessage" auf der Hub-Verbindung aufruft. Der Server kann eine Methode auf dem Client aufrufen, indem er die Eigenschaft Clients auf dem Hub verwendet, die es dem Server ermöglicht, eine Nachricht an alle verbundenen Clients, einen bestimmten Client oder eine Gruppe von Clients zu senden. In diesem Beispiel ruft der Server die ReceiveMessage-Methode auf allen verbundenen Clients auf und übergibt dabei den Benutzer und die Nachricht.

Es ist erwähnenswert, dass SignalR auch eine Gruppenverwaltung unterstützt, die es dem Server ermöglicht, Clients zu einer bestimmten Gruppe hinzuzufügen oder zu entfernen und Methoden für diese Gruppenmitglieder aufzurufen.