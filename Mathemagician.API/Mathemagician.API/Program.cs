using Mathemagician.Domain.Interfaces.Infra;
using Mathemagician.Domain.Interfaces.Services;
using Mathemagician.Infra.External;
using Mathemagician.Services.Operations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("PermitirTudo", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

builder.Services.AddHttpClient<IBacenRepository, BacenRepository>();
builder.Services.AddTransient<IMultiplicationFunctions, MultiplicationFunctions>();
builder.Services.AddTransient<IPercentualServices, PercentualServices>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();

app.UseCors("PermitirTudo");

app.UseAuthorization();

app.MapControllers();

app.Urls.Add("http://0.0.0.0");

app.Run();
