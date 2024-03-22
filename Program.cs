
using famiCCV1.Server.Models;
using famiCCV1.Server.Servicios.IServices;
using famiCCV1.Server.Servicios;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddControllersWithViews();


// CONTEXT ENTITY FRAEMWORK

builder.Services.AddDbContext<famiCC_v1Context>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("cadenaSQL"))
);

// CORS
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.WithOrigins("http://localhost:3000") // Reemplaza con el origen de tu aplicación React
                .AllowAnyHeader()
                .AllowAnyMethod()
                .AllowCredentials();
    });
});

//INYECCION SERVICIO


builder.Services.AddScoped<IAdjuntDocumentService, AdjuntDocumentService>();
builder.Services.AddScoped<IProponentDocumentService, ProponentDocumentService>();

builder.Services.AddScoped<IDocumentTypeService, DocumentTypeService>();
builder.Services.AddScoped<IRepresentativeService, RepresentativeService>();
builder.Services.AddScoped<IProponentTypeService, ProponentTypeService>();
builder.Services.AddScoped<IProponentService, ProponentService>();

builder.Services.AddScoped<IProposedValueService, ProposedValueService>();
builder.Services.AddScoped<IProposedService, ProposedService>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// CORS
app.UseCors();


app.UseDefaultFiles();
app.UseStaticFiles();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapFallbackToFile("/index.html");

app.Run();
