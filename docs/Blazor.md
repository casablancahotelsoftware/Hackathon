# Blazor

Blazor ist ein Framework für die Erstellung von Webanwendungen mit C# und WebAssembly. Es ermöglicht Entwicklern, C# sowohl für die clientseitige als auch für die serverseitige Logik zu verwenden, und nutzt WebAssembly, um C#-Code direkt im Browser auszuführen. Dies macht JavaScript überflüssig und ermöglicht eine nahtlose Entwicklung mit einer einzigen Sprache sowohl für den Client als auch für den Server.

Blazor gibt es in zwei Varianten, Blazor WebAssembly und Blazor Server.

Blazor WebAssembly:

Läuft auf der Client-Seite im Browser und kommuniziert mit einer serverseitigen API unter Verwendung von WebAssembly.
Anwendungen werden auf den Client heruntergeladen und lokal ausgeführt, was eine reaktionsschnellere und offline-fähige Erfahrung ermöglicht.
Blazor Server:

Läuft auf der Serverseite und kommuniziert mit dem Client über SignalR.
Bietet eine leichtgewichtige und latenzarme Lösung, erfordert aber eine ständige Verbindung zum Server.
Hier sind einige Beispiele für die wichtigsten Dateien in einer Blazor-Anwendung:

```_Imports.razor```: Diese Datei enthält die using-Anweisungen für alle Namespaces, die in der Anwendung verwendet werden, was die Verwaltung der Abhängigkeiten erleichtert.

```App.razor```: Diese Datei ist die Stammkomponente der Anwendung und dient als Einstiegspunkt für die Anwendung. Sie ist für das Rendern der Navigation und des Routings verantwortlich.

```Index.razor```: Diese Datei ist die Standardroute der Anwendung und dient als Landing Page der Anwendung.

```Shared\MainLayout.razor```: Diese Datei enthält das Layout der Anwendung. Es handelt sich um eine gemeinsame Komponente, die von allen Seiten der Anwendung verwendet wird.

```Pages\Counter.razor```: Diese Datei ist ein Beispiel für eine Seitenkomponente in der Anwendung. Sie enthält die Logik und das Markup für die Zählerseite.

Hier ist ein Beispiel für eine einfache Zählerkomponente:

```csharp

@page "/counter"

<h1>Counter</h1>

<p>Current count: @currentCount</p>

<button class="btn btn-primary" @onclick="IncrementCount">Click me</button>

@code {
    private int currentCount = 0;

    private void IncrementCount()
    {
        currentCount++;
    }
}

```

In diesem Beispiel wird die ```@page-Direktive``` verwendet, um die Route der Seite zu definieren, und der ```@code-Block``` enthält die Logik für die Komponente. Die Komponente hat ein privates Feld currentCount, das dazu dient, die aktuelle Zählung zu verfolgen, und eine Methode IncrementCount, die dazu dient, die Zählung zu erhöhen, wenn die Schaltfläche angeklickt wird.

Es ist erwähnenswert, dass Blazor es erlaubt, wiederverwendbare UI-Komponenten zu erstellen, die in der gesamten Anwendung genutzt werden können, dies kann mit Razor Components geschehen. Entwickler können auch eine Reihe anderer Funktionen wie Dependency Injection, Routing und JavaScript-Interop nutzen, um komplexere Webanwendungen mit C# und Blazor zu erstellen.