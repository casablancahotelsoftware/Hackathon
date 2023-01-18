using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using VirtualReception.Server.Hubs;
using VirtualReception.Server.Infrastructure;
using VitualReception.Domain.Model;

var builder = WebApplication.CreateBuilder(args);

/*
 * Here you can register dependencies in the dependency injection container.
 * 
 * Service lifetimes
 * 
 * Transient lifetime services are created each time they're requested from the service container. 
 * This lifetime works best for lightweight, stateless services. 
 * Register transient services with AddTransient.
 * In apps that process requests, transient services are disposed at the end of the request.
 * 
 * For web applications, a scoped lifetime indicates that services are created once per client request (connection). 
 * Register scoped services with AddScoped. In apps that process requests, scoped services are disposed at the end of the request.
 * When using Entity Framework Core, the AddDbContext extension method registers DbContext types with a scoped lifetime by default.
 * By default, in the development environment, resolving a service from another service with a longer lifetime throws an exception. 
 * For more information, see Scope validation.
 * 
 * Singleton lifetime services are created either:
 * The first time they're requested. By the developer, when providing an implementation instance directly to the container. This approach is rarely needed. 
 * Every subsequent request of the service implementation from the dependency injection container uses the same instance. 
 * If the app requires singleton behavior, allow the service container to manage the service's lifetime. 
 * Don't implement the singleton design pattern and provide code to dispose of the singleton. 
 * Services should never be disposed by code that resolved the service from the container. 
 * If a type or factory is registered as a singleton, the container disposes the singleton automatically. 
 * Register singleton services with AddSingleton. Singleton services must be thread safe and are often used in stateless services. 
 * In apps that process requests, singleton services are disposed when the ServiceProvider is disposed on application shutdown. 
 * Because memory is not released until the app is shut down, consider memory use with a singleton service.
 * 
 */
builder.Services.AddControllers();
builder.Services.AddSignalR();
builder.Services.AddSingleton<IChatRepository, FakeChatRepository>();

builder.Services.AddCors(opt => opt.AddDefaultPolicy(builder =>
{
    builder.SetIsOriginAllowed(_ => true);
    builder.AllowAnyHeader();
    builder.AllowAnyMethod();
    builder.AllowCredentials();
}));

var app = builder.Build();

/*
 * Middleware is software that's assembled into an app pipeline to handle requests and responses. Each component: 
 *   - Chooses whether to pass the request to the next component in the pipeline.
 *   - Can perform work before and after the next component in the pipeline. 
 * Request delegates are used to build the request pipeline. The request delegates handle each HTTP request.
 *   
 */
app.UseRouting();
app.UseCors();
app.MapControllers();
app.MapHub<ChatHub>("hubs/chat");

app.Run();
