using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using VirtualReception.Server.Hubs;
using VirtualReception.Server.Infrastructure;
using VitualReception.Domain.Model;

var builder = WebApplication.CreateBuilder(args);


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


app.UseRouting();
app.UseCors();
app.MapControllers();
app.MapHub<ChatHub>("hubs/chat");

app.Run();
