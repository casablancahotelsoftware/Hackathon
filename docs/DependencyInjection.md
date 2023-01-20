# Dependency Injection

Dependency Injection (DI) ist ein Entwurfsmuster, das die Verwaltung von Abhängigkeiten zwischen Komponenten in einer Softwareanwendung ermöglicht. Es ist eine Möglichkeit, einer Komponente ihre Abhängigkeiten zur Verfügung zu stellen, anstatt sie von der Komponente erstellen oder lokalisieren zu lassen. Dies ermöglicht ein stärker entkoppeltes Design, bei dem die Komponenten nicht eng an die spezifische Implementierung ihrer Abhängigkeiten gekoppelt sind.

Hier ist ein Beispiel dafür, wie Dependency Injection in C# mithilfe der integrierten Dependency Injection-Funktion in ASP.NET Core implementiert werden kann:

```csharp
// Example service interface
public interface IService {
    void DoSomething();
}

// Example service implementation
public class Service : IService {
    public void DoSomething() {
        // Do something
    }
}

// Example controller
public class MyController {
    private readonly IService _service;

    public MyController(IService service) {
        _service = service;
    }

    public void DoSomething() {
        _service.DoSomething();
    }
}

// Register the service in the Startup class
public void ConfigureServices(IServiceCollection services) {
    services.AddTransient<IService, Service>();
}

```

In diesem Beispiel hat die Klasse ```MyController``` eine Abhängigkeit von der Schnittstelle ```IService```. Anstatt dass der Controller eine Instanz des Dienstes erstellt, wird der Dienst über seinen Konstruktor in den Controller injiziert. Der Dienst wird in der ```ConfigureServices-Methode``` der ```Startup-Klasse``` registriert, wodurch das Dependency Injection-System angewiesen wird, die Service-Klasse zu verwenden, wenn eine Instanz der ```IService-Schnittstelle``` benötigt wird.

Die ```AddTransient-Methode``` wird verwendet, um den Dienst zu registrieren, was bedeutet, dass jedes Mal, wenn er angefordert wird, eine neue Instanz des Dienstes erstellt wird. Es gibt noch weitere Methoden wie ```AddSingleton``` und ```AddScoped```, die eine einzelne Instanz des Dienstes für die gesamte Anwendung bzw. für jede Anforderung erstellen.

Auf diese Weise kann der Controller lockerer an die spezifische Implementierung des Dienstes gekoppelt werden, so dass es einfacher ist, die Implementierung des Dienstes zu ändern, ohne den Controller zu beeinflussen. Auch das Testen des Controllers wird dadurch erleichtert, da ein Mock-Service zu Testzwecken einfach injiziert werden kann.

Dependency Injection ist ein leistungsfähiges Muster, das das Design und die Wartbarkeit einer Softwareanwendung erheblich verbessern kann. Es ermöglicht ein stärker entkoppeltes Design, wodurch es einfacher wird, die Implementierung von Komponenten zu ändern und die Anwendung zu testen.

## Lifetimes

ASP.NET Core Dependency Injection ermöglicht die Registrierung von Diensten mit unterschiedlichen Lebensdauern, die bestimmen, wie lange die Dienstinstanz im Speicher gehalten und wiederverwendet wird. Die verfügbaren Service-Lebensdauern sind:

### Transient 
Eine neue Instanz wird jedes Mal erstellt, wenn der Dienst angefordert wird.

### Scoped 
Für jeden Bereich, der in der Regel einer einzigen Anforderung entspricht, wird eine neue Instanz erstellt.

### Singleton
Es wird eine einzige Instanz erstellt und für alle Anfragen wiederverwendet.

Bei der Registrierung eines Dienstes kann seine Lebensdauer mit der entsprechenden Methode der Dienstesammlung angegeben werden, wie ```services.AddTransient<T>()```, ```services.AddScoped<T>()``` und ```services.AddSingleton<T>()```. Wenn keine Lebensdauer angegeben wird, ist der Standardwert Transient.

## Warum ist Dependency Injection so wichtig?

Dependency Injection kann dazu beitragen, die Tests von Software zu verbessern, indem sie die Erstellung isolierter, testbarer Codeeinheiten ermöglicht. Dies kann durch die Verwendung von Dependency-Injection-Frameworks wie der integrierten Dependency Injection (DI) in ASP.NET Core erreicht werden, um die Abhängigkeiten einer Klasse zur Laufzeit zu erstellen und zu konfigurieren, anstatt die Klasse ihre eigenen Abhängigkeiten erstellen oder anderweitig verwalten zu lassen.

Hier ist ein Beispiel für eine Klasse ```CustomerService```, die eine Abhängigkeit von einer Datenzugriffsklasse ```ICustomerRepository``` hat:

```csharp

public class CustomerService
{
    private ICustomerRepository _repository;

    public CustomerService(ICustomerRepository repository)
    {
        _repository = repository;
    }

    public void AddCustomer(Customer customer)
    {
        _repository.Add(customer);
    }
}
```

Das folgende Beispiel zeigt, wie Sie die integrierte DI verwenden, um die __ICustomerRepository-Abhängigkeit__ zu registrieren und eine Instanz der Klasse __CustomerService__ zu erstellen:

```csharp

// In Startup.cs
public void ConfigureServices(IServiceCollection services)
{
    services.AddTransient<ICustomerRepository, CustomerRepository>();
    services.AddTransient<CustomerService>();
}

```

In der Testklasse können wir nun den DI-Container verwenden, um ein Mock von __ICustomerRepository__ zu erstellen und damit die AddCustomer-Methode zu testen, etwa so:

````csharp

[Test]
public void TestAddCustomer()
{
    var mockRepository = new Mock<ICustomerRepository>();
    var customerService = new CustomerService(mockRepository.Object);
    customerService.AddCustomer(new Customer());
    mockRepository.Verify(r => r.Add(It.IsAny<Customer>()), Times.Once);
}

```

Durch die Verwendung von Dependency Injection kann die CustomerService-Klasse isoliert getestet werden, ohne dass eine echte Implementierung der ICustomerRepository-Klasse verwendet werden muss. Dies macht den Test schneller und zuverlässiger und ermöglicht außerdem das Testen verschiedener Szenarien durch die Verwendung verschiedener Mock-Implementierungen des Repositorys.
