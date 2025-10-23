using BackEnd_SistemaGestionContable.Context;
using BackEnd_SistemaGestionContable.Service;
using BackEnd_SistemaGestionContable.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var conString = builder.Configuration.GetConnectionString("Connection");
builder.Services.AddDbContext<SistemaGestionContableDBContext>(options => options.UseSqlServer(conString));

//Controller y services 
builder.Services.AddScoped<ICiudadRepository, CiudadRepository>();
builder.Services.AddScoped<ICiudadService, CiudadService>();

builder.Services.AddScoped<IClientesRepository, ClientesRepository>();
builder.Services.AddScoped<IClientesService, ClientesService>();

builder.Services.AddScoped<IDetalleVentaRepository, DetalleVentaRepository>();
builder.Services.AddScoped<IDetalleVentaService, DetalleVentaService>();

builder.Services.AddScoped<IEntradasInventarioRepository, EntradasInventarioRepository>();
builder.Services.AddScoped<IEntradasInventarioService, EntradasInventarioService>();

builder.Services.AddScoped<IGeneroRepository, GeneroRepository>();
builder.Services.AddScoped<IGeneroService, GeneroService>();

builder.Services.AddScoped<IMesasRepository, MesasRepository>();
builder.Services.AddScoped<IMesasService, MesasService>();

builder.Services.AddScoped<IMovimientosFinancierosRepository, MovimientosFinancierosRepository>();
builder.Services.AddScoped<IMovimientosFinancierosService, MovimientosFinancierosService>();

builder.Services.AddScoped<IPermisosRepository, PermisosRepository>();
builder.Services.AddScoped<IPermisosService, PermisosService>();

builder.Services.AddScoped<IPermisosXTipoUsuarioRepository, PermisosXTipoUsuarioRepository>();
builder.Services.AddScoped<IPermisosXTipoUsuarioService, PermisosXTipoUsuarioService>();

builder.Services.AddScoped<IPlanificacionComprasRepository, PlanificacionComprasRepository>();
builder.Services.AddScoped<IPlanificacionComprasService, PlanificacionComprasService>();

builder.Services.AddScoped<IProductoRepository, ProductoRepository>();
builder.Services.AddScoped<IProductosService, ProductosService>();

builder.Services.AddScoped<IProveedoresRepository, ProveedoresRepository>();
builder.Services.AddScoped<IProveedoresService, ProveedoresService>();

builder.Services.AddScoped<IReporteGeneralRepository, ReporteGeneralRepository>();
builder.Services.AddScoped<IReporteGeneralService, ReporteGeneralService>();

builder.Services.AddScoped<ISalidasInventarioRepository, SalidasInventarioRepository>();
builder.Services.AddScoped<ISalidasInventarioService, SalidasInventarioService>();

builder.Services.AddScoped<ITipoIdentificacionRepository, TipoIdentificacionRepository>();
builder.Services.AddScoped<ITipoIdentificacionService, TipoIdentificacionService>();

builder.Services.AddScoped<ITiposUsuarioRepository, TiposUsuarioRepository>();
builder.Services.AddScoped<ITiposUsuarioService, TiposUsuarioService>();

builder.Services.AddScoped<IUsuariosRepository, UsuariosRepository>();
builder.Services.AddScoped<IUsuariosService, UsuariosService>();

builder.Services.AddScoped<IVentasRepository, VentasRepository>();
builder.Services.AddScoped<IVentasService, VentasService>();

builder.Services.AddScoped<ILoginRepository, LoginRepository>();
builder.Services.AddScoped<ILoginService, LoginService>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
    builder => builder
        .AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader());
});

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

//use cors
app.UseCors("AllowAll");

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    // En producción quizá quieras otro middleware de errores…
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();



app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();