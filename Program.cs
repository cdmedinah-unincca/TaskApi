var builder = WebApplication.CreateBuilder(args);

// Agrega soporte para controladores
builder.Services.AddControllers();

var app = builder.Build();

// Habilita enrutamiento
app.UseRouting();

// Registra los controladores (¡esencial!)
app.MapControllers();

// NO usar HTTPS en desarrollo local para evitar problemas
// app.UseHttpsRedirection(); ← ¡COMENTADO O ELIMINADO!

app.Run();