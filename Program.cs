using CIS106ExceptionHandling.configurations;
using CIS106ExceptionHandling.repositories;
using CIS106ExceptionHandling.services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Adds our Controllers to our container and configures our [ApiController] behavior.
builder.Services.AddControllers().ConfigureApiBehaviorOptions(options =>
    {
        // Don't automatically validate request bodies, as we will do our own validation.
        options.SuppressModelStateInvalidFilter = true;
    }
);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// This will add all of the below classes to .NET's dependency injection container.
// Allowing it to provide your other classes with these classes when injected into the Constructor for those classes.
builder.Services.AddScoped<EhDbContext>();
builder.Services.AddScoped<ProductService>();

// Exception Handler
builder.Services.AddExceptionHandler<GlobalExceptionHandler>();

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

// This tells .NET to use our exception handler defined in the builder.Services.AddExceptionHandler code above. 
// We use (_ => {}) to provide it with the default configurations.
app.UseExceptionHandler(_ => { });

app.Run();
