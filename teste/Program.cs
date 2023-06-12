using CloudinaryDotNet;

var builder = WebApplication.CreateBuilder(args);
var cloudinaryConnectionString = builder.Configuration.GetConnectionString("CLOUDINARY_URL");
var cloudinary = new Cloudinary(cloudinaryConnectionString);
cloudinary.Api.Secure = true;

builder.Services.AddSingleton(cloudinary);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
