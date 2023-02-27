using Data.Context;
using Service.Services.Factory;
using Service.Services.Implimentes;
using Service.Services.InterFaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[assembly: ApiController]
var builder = WebApplication.CreateBuilder(args);
var service = builder.Services;
// Add services to the container.
service.AddRazorPages();
service.AddDbContext<MesaggeContext>(opthion =>
{
    opthion.UseSqlite("Data Source = Data\\MessageDb.sqlite");
});
service.AddScoped<IMessageService, MessageService>();
service.AddScoped<IChatService, ChatService>();
service.AddSingleton<IServiceFactory, ServiceFactory>();




var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
app.MapControllers();
app.MapRazorPages();

app.Run();
