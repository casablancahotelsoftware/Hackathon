# Controllers

In ASP.NET Core ist ein Controller eine Klasse, die HTTP-Anforderungen verarbeitet und eine HTTP-Antwort zurückgibt. Controller sind für die Verarbeitung von Benutzereingaben, die Interaktion mit dem Modell und die Rückgabe der entsprechenden Ansicht oder Daten verantwortlich.

Das ```ApiController-Attribut``` ist ein Attribut, das auf eine Controller-Klasse angewendet werden kann, um bestimmte Verhaltensweisen zu aktivieren, die für die Erstellung von API-Controllern nützlich sind. Wenn es angewandt wird, ermöglicht es die automatische Modellvalidierung, automatische HTTP 400 Antworten und die automatische Behandlung von allgemeinen API Problemen wie ungültige Modellzustände, null Modellzustände, usw.

Die Klasse ControllerBase ist eine Basisklasse für Controller, die die grundlegende Funktionalität für die Bearbeitung von HTTP-Anfragen und die Rückgabe von HTTP-Antworten bereitstellt. Sie ist die Basisklasse für die Controller-Klasse und es wird empfohlen, sie für die Erstellung von API-Controllern zu verwenden, da sie leichtgewichtig ist und einen geringeren Speicherbedarf hat als die Controller-Klasse.

Hier ist ein Beispiel für einen Controller, der ein ProductRepository verwendet und von der ControllerBase-Klasse erbt:

```csharp

[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
    private readonly IProductRepository _productRepository;

    public ProductsController(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var products = _productRepository.GetAll();
        return Ok(products);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var product = _productRepository.GetById(id);
        if (product == null)
        {
            return NotFound();
        }
        return Ok(product);
    }

    [HttpPost]
    public IActionResult Add([FromBody] Product product)
    {
        _productRepository.Add(product);
        return CreatedAtAction(nameof(GetById), new { id = product.Id }, product);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, [FromBody] Product product)
    {
        var existingProduct = _productRepository.GetById(id);
        if (existingProduct == null)
        {
            return NotFound();
        }
        _productRepository.Update(product);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var product = _productRepository.GetById(id);
        if (product == null)
        {
            return NotFound();
        }
        _productRepository.Delete(product);
        return NoContent();
    }
}

```

In diesem Beispiel ist die ProductsController-Klasse mit dem Attribut ```[ApiController]``` dekoriert und für die Bearbeitung von Anfragen für die Route ```/api/products``` definiert. Die ProductsController-Klasse hat auch ein privates Feld ```_productRepository``` vom Typ ```IProductRepository```, das über den Konstruktor injiziert wird.

## Attribute
Die Methoden im Controller sind mit verschiedenen Attributen wie ```[HttpGet]```, ```[HttpPost]```, ```[HttpPut]```, ```[HttpDelete]``` usw. ausgestattet. Diese Attribute geben die HTTP-Verben an, die die Methoden verarbeiten. Das ```[HttpGet]-Attribut``` zeigt beispielsweise an, dass die Methode HTTP-GET-Anfragen bearbeitet, das ```[HttpPost]-Attribut``` zeigt an, dass die Methode HTTP-POST-Anfragen bearbeitet und so weiter.

Das Attribut ```[Route("api/[controller]")]``` wird verwendet, um die Route für den Controller zu definieren. Es wird verwendet, um die Basisroute für die Aktionen des Controllers zu definieren. In diesem Beispiel ist die Basis-Route ```api/[controller]``` , und sie wird verwendet, um Anfragen an die ```/api/products```-Route zu behandeln.

Das ```[FromBody]-Attribut``` wird verwendet, um anzugeben, dass der Parameter an den Body der Anfrage gebunden werden soll. In diesem Beispiel nimmt die Add-Methode ein Product-Objekt als Parameter an und ist mit dem Attribut ```[FromBody]``` versehen. Dies zeigt an, dass das Product-Objekt an den Body der Anfrage gebunden werden soll.

## REST
REST (Representational State Transfer) ist ein Architekturmuster, das für die Entwicklung von Webdiensten verwendet wird. Es definiert eine Reihe von Einschränkungen, die bei der Erstellung von Webdiensten befolgt werden müssen. Zu diesen Einschränkungen gehören die Verwendung von HTTP-Verben (GET, POST, PUT, DELETE usw.), um die Art der auszuführenden Operation anzugeben, die Verwendung von URLs zur Identifizierung von Ressourcen und die Verwendung von Standard-HTTP-Statuscodes zur Angabe des Status der Anfrage. Im vorliegenden Beispiel folgt der Controller dem REST-Architekturmuster, indem er Standard-HTTP-Verben verwendet, um die Art des auszuführenden Vorgangs anzugeben, URLs zur Identifizierung von Ressourcen verwendet und Standard-HTTP-Statuscodes zur Angabe des Status der Anfrage verwendet.