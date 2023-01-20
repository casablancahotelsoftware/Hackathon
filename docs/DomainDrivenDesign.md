# Domain Driven Design
Domain-Driven Design (DDD) ist ein Softwareentwicklungsansatz, der die Bedeutung des Verständnisses und der Modellierung der Geschäftsdomäne hervorhebt, um ein effektiveres und besser wartbares Softwaresystem zu schaffen. Das Hauptziel von DDD besteht darin, die technischen und geschäftlichen Aspekte des Systems aufeinander abzustimmen, indem die Bereichslogik in den Mittelpunkt des Entwicklungsprozesses gestellt wird.

DDD besteht aus zwei Teilen: strategische Muster und taktische Muster.

## Strategische Muster
Strategische Muster sind Muster auf hoher Ebene, die eine Anleitung für die Strukturierung der Gesamtarchitektur des Systems und die Definition des Gesamtkontextes, in dem das System arbeitet, bieten. Einige Beispiele für strategische Muster sind:

### Bounded Context 
Ein begrenzter Kontext ist eine Grenze, innerhalb derer ein bestimmtes Domänenmodell gilt. Er definiert den Geltungsbereich des Modells und die Beziehungen zwischen dem Modell und anderen Modellen im System.

### ContextMap
Eine Kontextkarte ist eine visuelle Darstellung der verschiedenen begrenzten Kontexte im System und der Beziehungen zwischen ihnen. Sie hilft zu verstehen, wie sich die verschiedenen Modelle im System zueinander verhalten und wie sie integriert werden sollten.

## Taktische Muster
Taktische Muster sind Muster auf niedrigerer Ebene, die Anleitungen für die Implementierung bestimmter Teile des Systems bieten, wie z. B. die Persistenzschicht, die Benutzeroberfläche oder die Geschäftslogik. Einige Beispiele für taktische Muster sind:

### Entity 
Eine Entität ist ein Domänenobjekt, das eine eindeutige Identität besitzt und zur Modellierung eines Geschäftskonzepts oder einer Geschäftsregel verwendet wird.

### ValueObject
Ein Wertobjekt ist ein Domänenobjekt, das keine eindeutige Identität hat und zur Modellierung eines Wertes oder einer Geschäftsregel verwendet wird.

### Repository 
Ein Repository ist ein Entwurfsmuster, das zur Abstraktion der Persistenzschicht der Anwendung verwendet wird. Es fungiert als Vermittler zwischen dem Domänenmodell und der Datenzugriffsschicht und ermöglicht die Trennung der Belange zwischen beiden.

Hier ist ein Beispiel dafür, wie diese Muster in C# implementiert werden können:

```csharp

public class Order
{
    public int Id { get; set; }
    public string Customer { get; set; }
    public decimal Total { get; set; }
    public OrderStatus Status { get; set; }
}

public class OrderStatus : ValueObject
{
    public string Name { get; set; }
    public string Description { get; set; }
}

public class OrderRepository : IRepository<Order>
{
    private readonly DbContext _context;
    public OrderRepository(DbContext context)
    {
        _context = context;
    }
    public Order GetById(int id)
    {
        return _context.Orders.Find(id);
    }
    public IEnumerable<Order> GetAll()
    {
        return _context.Orders.ToList();
    }
    public void Add(Order entity)
    {
        _context.Orders.Add(entity);
        _context.SaveChanges();
    }
    public void Update(Order entity)
    {
        _context.Orders.Update(entity);
        _context.SaveChanges();
    }
    public void Delete(Order entity)
    {
        _context.Orders.Remove(entity);
        _context.SaveChanges();
    }
}

```

In diesem Beispiel ist die Klasse ```Order``` ein Entity, die das Konzept einer Bestellung in der Geschäftsdomäne modelliert. Die Klasse ```OrderStatus``` ist ein ```ValueObject```, das den Status der Bestellung modelliert. Die Klasse ```OrderRepository``` ist ein Repository, das die Schnittstelle IRepository implementiert und die grundlegende CRUD-Funktionalität für die Entität Order bereitstellt.