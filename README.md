# Hackathon für Schulen

Willkommen zu unserem Hackathon in Zusammenarbeit mit deiner Schule! Als Unternehmen, das Wert auf Innovation und Technologie legt, freuen wir uns darauf euch die Möglichkeit zu bieten eine innovative Chat-Anwendung zu entwickeln.

Das Ziel dieses Hackathons ist es, euch die Möglichkeit zu geben, neue Technologien kennenzulernen und mit diesen zu arbeiten, insbesondere ASP.NET Core als Backend und Blazor als Framework für den Aufbau der Webanwendung. Dies soll euch die Möglichkeit geben, mit neuen Technologien zu arbeiten und diese zu erlernen, während ihr gleichzeitig eure Fähigkeiten in einer stressigen und herausfordernden Umgebung verbessern könnt.

Während der gesamten Veranstaltung habt ihr Zugang zu Mentoren und Experten auf diesem Gebiet, die euch bei der Umsetzung eurer Ideen unterstützen werden. Diese Veranstaltung bietet dir eine hervorragende Gelegenheit, um zu lernen, zu wachsen und mit anderen zusammenzuarbeiten. Wir sind gespannt auf die kreativen und innovativen Lösungen, die aus dieser Veranstaltung hervorgehen werden!


# Das Skeleton Projekt

Ein Skelettprojekt ist eine vorgefertigte Projektstruktur, die eine grundlegende Basis für die Entwicklung einer Softwareanwendung bietet. In diesem Fall wird das Skelettprojekt auf ASP.NET Core und Blazor basieren und euch einen Ausgangspunkt für die Entwicklung einer Webanwendung bieten.

Das Skelettprojekt enthält die notwendigen Dateien und Verzeichnisse für die Erstellung einer Webanwendung, wie z. B. die Projektdatei, Konfigurationsdateien und die grundlegende Dateistruktur. Es enthält auch ein grundlegendes Layout und Design sowie einige vorgefertigte Komponenten und Funktionen, die euch den schnellen Einstieg erleichtern.

Darüber hinaus enthält es vorkonfigurierte Abhängigkeiten wie das ASP.NET Core-Framework, das Blazor-Framework und alle anderen notwendigen Pakete, die euch bei der Entwicklung eurer Anwendung helfen.

Insgesamt bietet das Skeleton-Projekt eine solide Grundlage für die Entwicklung eurer Webanwendung und hilft euch den Fokus auf die Implementierung eurer spezifischen Merkmale und Funktionen zu konzentrieren, anstatt Zeit auf die Einrichtung der Grundstruktur zu verwenden.

# Der Technologie-Stack

ASP.NET Core in Kombination mit Blazor und SignalR bietet ein leistungsstarkes Framework für die Erstellung von Webanwendungen. Zu den wichtigsten Komponenten dieser Kombination gehören:

## [Dependency Injection](./docs/DependencyInjection.md)
ASP.NET Core bietet integrierte Unterstützung für Dependency Injection, die die einfache Verwaltung von Abhängigkeiten zwischen Komponenten in der Anwendung ermöglicht. Dies erleichtert den Austausch von Komponenten zu Testzwecken oder zur Änderung der Implementierung eines Dienstes.

## [Konfiguration](./docs/Configuration.md) 
ASP.NET Core verwendet ein Konfigurationssystem, das eine einfache Verwaltung von Anwendungseinstellungen wie Datenbankverbindungszeichenfolgen, Anwendungsschlüsseln und anderen Einstellungen ermöglicht. Dieses Konfigurationssystem kann leicht mit verschiedenen Quellen wie json, xml und Umgebungsvariablen integriert werden.

## [Controllers](./docs/Controllers.md) 
ASP.NET Core verwendet Controller, um eingehende HTTP-Anfragen zu verarbeiten und Antworten zurückzugeben. Controller sind für die Handhabung der Logik der Anwendung und die Interaktion mit anderen Komponenten wie Modellen und Diensten verantwortlich.

## [Models](./docs/Models.md) 
Models repräsentieren die Daten und die Geschäftslogik der Anwendung. Sie sind für die Interaktion mit der Datenbank, die Validierung und jede andere Logik im Zusammenhang mit den Daten verantwortlich.

## [DDD (Domain-Driven Design)](./docs/DomainDrivenDesign.md)
DDD ist eine Designphilosophie, die sich auf die Modellierung der Problemdomäne, die Erstellung eines umfassenden Modells des Problemraums und die Konzentration auf die Geschäftslogik der Anwendung konzentriert. Dies hilft dabei, eine klare Trennung von Belangen zu schaffen und den Code besser wartbar und testbar zu machen.

## [SignalR](./docs/SignalR.md) 
SignalR ist eine Open-Source-Bibliothek, die das Hinzufügen von Echtzeitfunktionen zu Webanwendungen erleichtert. Sie ermöglicht die Echtzeit-Kommunikation zwischen Server und Client und bietet Funktionen wie Live-Updates, Benachrichtigungen und Zusammenarbeit in Echtzeit.

## [Blazor](./docs/Blazor.md) 
Blazor ist ein Framework für die Erstellung von Webanwendungen mit C# und Razor. Es ermöglicht die Erstellung von clientseitigen Webanwendungen mit C# und Razor und ermöglicht die Verwendung bestehender .NET-Bibliotheken, wodurch die gemeinsame Nutzung von Code zwischen Client und Server ermöglicht wird.

Insgesamt bietet diese Kombination von Technologien ein leistungsfähiges und flexibles Framework für die Erstellung von Webanwendungen mit vielen integrierten Funktionen und Tools, die die Entwicklung effizienter und effektiver machen.


# Getting Started

Die API kann mit dem nachfolgenden Befehl gestartet werden:

``` sh

$ cd ./src/Server

$ dotnet run  

$ curl --location --request GET 'http://localhost:5000/chat'

```

Der von der API zurügkgeliferte Response:

```json

[
  {
    "id": "1a5d8570-e1c4-43da-9463-f703e5098f38",
    "name": "Maria Mustergast",
    "messages": [
      {
        "id": "b4e62e72-7908-42fe-ab73-e01759483bc0",
        "content": "Sehr geehrte Damen und Herren, ich möchte mich zu meiner Buchung informieren",
        "createdDateTime": "2023-01-20T11:29:09.2393729+01:00",
        "createdByMember": "e77d4178-5e50-419e-8c5f-7d148b7bf5e8"
      },
      {
        "id": "de795c81-cd2b-4a4e-b53f-780e3a93f6a8",
        "content": "Können Sie mir bitte Ihre Buchungnummer zukommen lassen",
        "createdDateTime": "2023-01-20T11:29:09.2446037+01:00",
        "createdByMember": "e77d4178-5e50-419e-8c5f-7d148b7bf5e7"
      }
    ],
    "members": [
      {
        "id": "e77d4178-5e50-419e-8c5f-7d148b7bf5e8",
        "name": "Max Mustergast"
      },
      {
        "id": "e77d4178-5e50-419e-8c5f-7d148b7bf5e7",
        "name": "Maria Muterrezeptionistin"
      }
    ]
  }
]


```

Das Frontend kann mit nachfolgendem Befehl gestartet werden:

``` sh

$ cd ./src/Client

$ dotnet run  

```

Die Applikation kann dann über die Url ```http://localhost:5001``` aufgerufen werden.
