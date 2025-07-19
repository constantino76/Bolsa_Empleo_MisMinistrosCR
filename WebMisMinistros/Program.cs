using WebMisMinistros.Repositorios.implementacion;
using WebMisMinistros.Repositorios.Interfaces;
using WebMisMinistros.Repositorios.Services;
using WebMisMinistros.ManejadorRutas;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews(options =>
{
    options.Filters.Add<FilterTokenView>();
});
builder.Services.AddScoped<IUsuario,UsuarioService>();
builder.Services.AddScoped<ILogin, LoginService>();
builder.Services.AddScoped<IJwtokenReader,JwtokenReaderService>();
builder.Services.AddScoped<IRol, RolService>();

//configuracion de jwt
builder.Services.AddSession();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(25); // Duración de la sesión inactiva
    options.Cookie.HttpOnly = true; // Seguridad básica
    options.Cookie.IsEssential = true; // Necesario para funcionar sin consentimiento de cookies
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();


app.UseSession();
app.UseRouting();




app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Acceso}/{action=Login}/");

app.Run();
