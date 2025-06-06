using Microsoft.EntityFrameworkCore;
using ZAlert.Api.Infrastructure.Persistence;
using ZAlert.Api.Infrastructure.Repository;
using ZAlert.Api.Application.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ZAlertContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IAlertaRepository, AlertaRepository>();
builder.Services.AddScoped<IDependenteRepository, DependenteRepository>();
builder.Services.AddScoped<IDispositivoRepository, DispositivoRepository>();
builder.Services.AddScoped<ILocalizacaoRepository, LocalizacaoRepository>();
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();

builder.Services.AddScoped<AlertaService>();
builder.Services.AddScoped<DependenteService>();
builder.Services.AddScoped<DispositivoService>();
builder.Services.AddScoped<LocalizacaoService>();
builder.Services.AddScoped<UsuarioService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllers();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();

app.Run();
