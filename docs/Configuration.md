# Konfiguration

ASP.NET Core bietet ein flexibles Konfigurationssystem, mit dem Entwickler die Anwendungseinstellungen einfach verwalten können. Konfigurationsdaten können in einer Vielzahl von Quellen gespeichert werden, z. B. in JSON-Dateien, XML-Dateien oder Umgebungsvariablen, und können mithilfe des Microsoft.Extensions.Configuration-Namensraums einfach abgerufen und bearbeitet werden.

Das Konfigurationssystem basiert auf einem hierarchischen Key-Value-Store, in dem die Konfigurationsdaten in Abschnitten und Key-Value-Paaren organisiert sind. Das Konfigurationssystem ermöglicht Entwicklern den Zugriff auf Konfigurationsdaten über eine stark typisierte API, die Typkonvertierung unterstützt, oder über eine dynamische API, die einen einfachen Zugriff auf verschachtelte Konfigurationsdaten ermöglicht.

Im Folgenden finden Sie einige Beispiele für die Verwendung des Konfigurationssystems in einer ASP.NET Core-Anwendung:

```csharp

// Accessing Configuration Data in Code
public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }
    public IConfiguration Configuration { get; }
    public void ConfigureServices(IServiceCollection services)
    {
        var mySetting = Configuration["MySetting"];
    }
}

// Using the Options pattern
public class MyOptions
{
    public string Option1 { get; set; }
    public int Option2 { get; set; }
}

public void ConfigureServices(IServiceCollection services)
{
    services.Configure<MyOptions>(Configuration);
}


// Adding JSON file as configuration source
public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {
        Configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
            .Build();
    }
}

// Adding Environment Variable as configuration source
public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {
        Configuration = new ConfigurationBuilder()
            .AddEnvironmentVariables()
            .Build();
    }
}


```

In diesen Beispielen nimmt der Konstruktor der Startup-Klasse ein IConfiguration-Objekt auf, das für den Zugriff auf die Konfigurationsdaten in der gesamten Anwendung verwendet wird. Die Datei appsettings.json wird als Konfigurationsquelle hinzugefügt, und der Zugriff auf ihre Werte erfolgt dann über das Objekt Configuration. Das Optionsmuster wird ebenfalls demonstriert, wobei eine benutzerdefinierte Optionsklasse für den Zugriff auf Konfigurationsdaten mit stark typisiertem Zugriff verwendet wird.