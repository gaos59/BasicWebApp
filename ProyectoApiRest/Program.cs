using ProyectoApiRest.Servicios;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<IClienteService, ClienteService>();
builder.Services.AddSingleton<IEmpleadoService, EmpleadoService>();
builder.Services.AddSingleton<IVehiculoService, VehiculoService>();
builder.Services.AddSingleton<ILavadoService, LavadoService>();
builder.Services.AddSingleton<IReporteService, ReporteService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
