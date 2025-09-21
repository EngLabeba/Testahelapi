using Persistence;
using Presentation.Services;
using Application;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add Application services
builder.Services.ConfigureApplication();

// Add Persistence services
builder.Services.ConfigurePersistence(builder.Configuration);



// Add QR Code service
builder.Services.AddScoped<Application.Common.Services.IQrCodeService, QrCodeService>();
builder.Services.AddScoped<IQrCodeService, QrCodeService>();

// Add Offer Share service
builder.Services.AddScoped<Application.Common.Services.IOfferShareService, Persistence.Services.OfferShareService>();

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
