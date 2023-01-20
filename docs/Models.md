# Models
In ASP.NET Core ist ein Modell ein Objekt, das die Daten in einer Anwendung darstellt. Es kann eine einfache POCO-Klasse (Plain Old CLR Object) oder ein komplexeres Objekt sein, das Validierungslogik und andere Geschäftsregeln enthält. Modelle werden verwendet, um die Daten darzustellen, die von den Ansichten in einer Anwendung angezeigt oder gesammelt werden, und sie werden in der Regel zwischen den Controllern und Ansichten weitergegeben.

Im Domain-Driven Design (DDD) ist ein Modell ein Objekt, das die Daten und das Verhalten einer bestimmten Domain darstellt. Es ist die Darstellung der Konzepte, Regeln und Daten einer bestimmten Geschäftsdomäne. In DDD werden Modelle in der Regel so entworfen, dass sie die realen Konzepte und Beziehungen der Domäne widerspiegeln, anstatt sich auf die technischen Details der Anwendung zu konzentrieren. Das Ziel von DDD-Modellen ist es, eine reichhaltige, aussagekräftige und genaue Darstellung der Domäne zu liefern, die zur Entwicklung der Anwendung verwendet werden kann.

Hier sind einige Beispiele für in C# implementierte Modelle:

```csharp

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public string Description { get; set; }
    public int CategoryId { get; set; }
    public Category Category { get; set; }
}

public class Order
{
    public int Id { get; set; }
    public DateTime OrderDate { get; set; }
    public decimal Total { get; set; }
    public int CustomerId { get; set; }
    public Customer Customer { get; set; }
    public List<OrderLine> OrderLines { get; set; }
    public void CalculateTotal()
    {
        Total = OrderLines.Sum(l => l.Quantity * l.UnitPrice);
    }
}

public class Customer
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string Address { get; set; }
    public List<Order> Orders { get; set; }
}

```

In diesem Beispiel sind die Klassen "Product", "Order" und "Customer" Modelle, die die Konzepte der Geschäftsdomäne, wie Produkte, Aufträge und Kunden, darstellen. Sie enthalten Eigenschaften, die die Daten darstellen, die von der Anwendung verwendet werden, und Methoden, die das Verhalten des Modells darstellen.

Die DDD-Modelle sind von der Anwendungsschicht entkoppelt und können in verschiedenen Anwendungen wiederverwendet werden. Dies ermöglicht eine bessere Trennung von Belangen, erhöht die Flexibilität und Wartbarkeit und verbessert die Gesamtqualität des Codes.