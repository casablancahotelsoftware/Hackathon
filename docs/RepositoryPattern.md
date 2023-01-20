# Repository Pattern
Das Repository-Muster ist ein Entwurfsmuster, das im Domain-Driven Design (DDD) zur Abstraktion der Persistenzschicht der Anwendung verwendet wird. Es fungiert als Vermittler zwischen dem Domänenmodell und der Datenzugriffsschicht und ermöglicht die Trennung von Belangen zwischen beiden.

Das Repository-Muster definiert einen Vertrag zum Erstellen, Abrufen, Aktualisieren und Löschen von Domänenobjekten. Dieser Vertrag wird von einer konkreten Repository-Klasse implementiert, die für die Interaktion mit dem zugrundeliegenden Datenspeicher (z. B. einer Datenbank) verantwortlich ist, um diese Operationen durchzuführen.

Hier ist ein Beispiel für eine Repository-Schnittstelle und ihre Implementierung in C#:

```csharp

interface IRepository<T>
{
    T GetById(int id);
    IEnumerable<T> GetAll();
    void Add(T entity);
    void Update(T entity);
    void Delete(T entity);
}

class Repository<T> : IRepository<T>
{
    private readonly DbContext _context;

    public Repository(DbContext context)
    {
        _context = context;
    }

    public T GetById(int id)
    {
        return _context.Set<T>().Find(id);
    }

    public IEnumerable<T> GetAll()
    {
        return _context.Set<T>().ToList();
    }

    public void Add(T entity)
    {
        _context.Set<T>().Add(entity);
        _context.SaveChanges();
    }

    public void Update(T entity)
    {
        _context.Set<T>().Update(entity);
        _context.SaveChanges();
    }

    public void Delete(T entity)
    {
        _context.Set<T>().Remove(entity);
        _context.SaveChanges();
    }
}

```

In diesem Beispiel definiert die Schnittstelle ```IRepository<T>``` den Vertrag für das Repository, und die Klasse ```Repository<T>``` implementiert den Vertrag unter Verwendung eines ```DbContext``` zur Interaktion mit dem zugrunde liegenden Datenspeicher.

Im obigen Beispiel ist ```T``` ein generischer Typparameter, der es ermöglicht, das Repository für verschiedene Arten von Domänenobjekten zu verwenden.

Im Domain-Driven Design (DDD) kann ein Repository verwendet werden, um spezifische Abfragen zu definieren, die sich auf das Domänenmodell beziehen. Dadurch kann die Anwendung Daten aus dem Datenspeicher auf eine Weise abrufen, die mit der Geschäftslogik der Domäne übereinstimmt.

Hier ist ein Beispiel für ein Repository, das eine spezifische Abfrage für ein Produktdomänenmodell in C# definiert:

```csharp

interface IProductRepository : IRepository<Product>
{
    IEnumerable<Product> GetProductsByCategory(string category);
}

class ProductRepository : IProductRepository
{
    private readonly DbContext _context;

    public ProductRepository(DbContext context)
    {
        _context = context;
    }

    public IEnumerable<Product> GetById(int id)
    {
        return _context.Set<Product>().Find(id);
    }

    public IEnumerable<Product> GetAll()
    {
        return _context.Set<Product>().ToList();
    }

    public IEnumerable<Product> GetProductsByCategory(string category)
    {
        return _context.Set<Product>().Where(p => p.Category == category).ToList();
    }

    public void Add(Product entity)
    {
        _context.Set<Product>().Add(entity);
        _context.SaveChanges();
    }

    public void Update(Product entity)
    {
        _context.Set<Product>().Update(entity);
        _context.SaveChanges();
    }

    public void Delete(Product entity)
    {
        _context.Set<Product>().Remove(entity);
        _context.SaveChanges();
    }
}

```

In diesem Beispiel erweitert die Schnittstelle ```IProductRepository``` das ```IRepository<Product>``` und definiert eine neue Methode GetProductsByCategory, die einen String-Parameter category annimmt und eine Liste von Produkten zurückgibt, die der Kategorie entsprechen. Die Methode wird in der Klasse ProductRepository implementiert, die den ```DbContext``` zur Interaktion mit dem zugrunde liegenden Datenspeicher verwendet.

Dieses Beispiel zeigt, wie das Repository-Muster verwendet werden kann, um spezifische Abfragen für das Domänenmodell zu definieren, was es der Anwendung erleichtert, Daten auf eine Weise abzurufen, die mit der Geschäftslogik der Domäne übereinstimmt.

Es ist wichtig zu beachten, dass dies nur ein Beispiel dafür ist, wie das Repository-Muster implementiert werden kann, und dass die spezifischen Details der Implementierung je nach den Anforderungen der Anwendung variieren werden.
