using AutoMapper;
using Drones.Jobs;
using Drones.Mappers;
using Drones.Model.Context;
using Drones.Model.Repository;
using Drones.Model.Repository.Interface;
using Drones.Model.UnitOfWork;
using Drones.Model.UnitOfWork.Interfaces;
using Drones.Services;
using Drones.Services.Interfaces;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .Enrich.FromLogContext()
    .CreateLogger();
builder.Logging.ClearProviders();
builder.Logging.AddSerilog(logger);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped( _ => new DroneContext());
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IDroneService, DroneService>();
builder.Services.AddScoped<IMedicationService, MedicationService>();
builder.Services.AddScoped<ILoadService, LoadService>();
builder.Services.AddHostedService<CheckDronesHostedService>();


var mapperConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new MappingProfile());    
    mc.ReplaceMemberName("_", "");
});
IMapper mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();  
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
