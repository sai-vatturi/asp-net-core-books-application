using BloodBankAPI.Models;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllers();

// Configure Swagger with better documentation
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Blood Bank Management API", Version = "v1" });
});

// Add a singleton list to act as the in-memory database
var bloodBankEntries = new List<BloodBankEntry>
{
    new BloodBankEntry
    {
        Id = Guid.NewGuid(),
        DonorName = "Sainadh Vatturi",
        Age = 21,
        BloodType = "O+",
        ContactInfo = "sainadhvatturi@gmail.com",
        Quantity = 500,
        CollectionDate = DateTime.UtcNow.AddDays(-10),
        ExpirationDate = DateTime.UtcNow.AddDays(30),
        Status = "Available"
    },
    new BloodBankEntry
    {
        Id = Guid.NewGuid(),
        DonorName = "Divya Reddy",
        Age = 30,
        BloodType = "A+",
        ContactInfo = "divya.reddy@gmail.com",
        Quantity = 450,
        CollectionDate = DateTime.UtcNow.AddDays(-5),
        ExpirationDate = DateTime.UtcNow.AddDays(25),
        Status = "Requested"
    },
    new BloodBankEntry
    {
        Id = Guid.NewGuid(),
        DonorName = "Harshitha N",
        Age = 28,
        BloodType = "B+",
        ContactInfo = "harshitha.n@gmail.com",
        Quantity = 480,
        CollectionDate = DateTime.UtcNow.AddDays(-7),
        ExpirationDate = DateTime.UtcNow.AddDays(23),
        Status = "Available"
    },
    new BloodBankEntry
    {
        Id = Guid.NewGuid(),
        DonorName = "Suresh Yadav",
        Age = 35,
        BloodType = "AB-",
        ContactInfo = "suresh.yadav@gmail.com",
        Quantity = 520,
        CollectionDate = DateTime.UtcNow.AddDays(-12),
        ExpirationDate = DateTime.UtcNow.AddDays(28),
        Status = "Available"
    },
    new BloodBankEntry
    {
        Id = Guid.NewGuid(),
        DonorName = "Sneha Rao",
        Age = 32,
        BloodType = "O+",
        ContactInfo = "sneha.rao@gmail.com",
        Quantity = 500,
        CollectionDate = DateTime.UtcNow.AddDays(-3),
        ExpirationDate = DateTime.UtcNow.AddDays(27),
        Status = "Requested"
    },
    new BloodBankEntry
    {
        Id = Guid.NewGuid(),
        DonorName = "Vikram Patil",
        Age = 29,
        BloodType = "A-",
        ContactInfo = "vikram.patil@gmail.com",
        Quantity = 470,
        CollectionDate = DateTime.UtcNow.AddDays(-8),
        ExpirationDate = DateTime.UtcNow.AddDays(22),
        Status = "Available"
    },
    new BloodBankEntry
    {
        Id = Guid.NewGuid(),
        DonorName = "Keerthi Varma",
        Age = 26,
        BloodType = "B-",
        ContactInfo = "keerthi.varma@gmail.com",
        Quantity = 460,
        CollectionDate = DateTime.UtcNow.AddDays(-4),
        ExpirationDate = DateTime.UtcNow.AddDays(26),
        Status = "Available"
    },
    new BloodBankEntry
    {
        Id = Guid.NewGuid(),
        DonorName = "Rahul Naidu",
        Age = 40,
        BloodType = "AB+",
        ContactInfo = "rahul.naidu@gmail.com",
        Quantity = 510,
        CollectionDate = DateTime.UtcNow.AddDays(-15),
        ExpirationDate = DateTime.UtcNow.AddDays(25),
        Status = "Requested"
    },
    new BloodBankEntry
    {
        Id = Guid.NewGuid(),
        DonorName = "Anusha K",
        Age = 27,
        BloodType = "O+",
        ContactInfo = "anusha.k@gmail.com",
        Quantity = 495,
        CollectionDate = DateTime.UtcNow.AddDays(-6),
        ExpirationDate = DateTime.UtcNow.AddDays(24),
        Status = "Available"
    },
    new BloodBankEntry
    {
        Id = Guid.NewGuid(),
        DonorName = "Rakesh Singh",
        Age = 33,
        BloodType = "A+",
        ContactInfo = "rakesh.singh@gmail.com",
        Quantity = 505,
        CollectionDate = DateTime.UtcNow.AddDays(-9),
        ExpirationDate = DateTime.UtcNow.AddDays(-4),
        Status = "Expired"
    },
    new BloodBankEntry
    {
        Id = Guid.NewGuid(),
        DonorName = "Meghana Iyer",
        Age = 24,
        BloodType = "B+",
        ContactInfo = "meghana.iyer@gmail.com",
        Quantity = 475,
        CollectionDate = DateTime.UtcNow.AddDays(-2),
        ExpirationDate = DateTime.UtcNow.AddDays(28),
        Status = "Requested"
    },
    new BloodBankEntry
    {
        Id = Guid.NewGuid(),
        DonorName = "Ajay K",
        Age = 31,
        BloodType = "O-",
        ContactInfo = "ajay.k@gmail.com",
        Quantity = 490,
        CollectionDate = DateTime.UtcNow.AddDays(-11),
        ExpirationDate = DateTime.UtcNow.AddDays(19),
        Status = "Available"
    },
};

builder.Services.AddSingleton<List<BloodBankEntry>>(bloodBankEntries);

var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
