using DotNetEnv; // Aseg�rate de agregar esta l�nea para usar DotNetEnv
using LTSMerchWebApp.Models;
using LTSMerchWebApp.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Carga las variables de entorno desde el archivo .env
Env.Load();

// Configura el contexto de base de datos MySQL utilizando la cadena de conexi�n del archivo .env
builder.Services.AddDbContext<LtsMerchStoreContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("LtsMerchStoreContext") ?? Environment.GetEnvironmentVariable("CONNECTION_STRING"),
    new MySqlServerVersion(new Version(8, 0, 26)))); // Cambia la versi�n a la de tu servidor MySQL

// Agregar servicios de sesi�n
builder.Services.AddHttpContextAccessor();
builder.Services.AddSession();

builder.Services.AddScoped<EmailService>();

// A�adir servicios al contenedor.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configurar el middleware de la solicitud HTTP.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// Configurar el uso de sesiones
app.UseSession();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Products}/{action=ProductsList}/{id?}");

app.Run();
