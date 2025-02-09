var builder = WebApplication.CreateBuilder(args);

// Add services to the container.  THIS IS THE KEY FIX FOR THE EXCEPTION
builder.Services.AddControllersWithViews(); // Add this line!
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

//This is an array of strings that contains a list of weather summaries.
//These summaries are used to generate random weather forecasts.
//The summaries are used in the GetWeatherForecast endpoint.
//The summaries are accessed using the Random.Shared.Next(summaries.Length) method.
var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Tasks}/{action=Index}/{id?}"); // Set Tasks/Index as default

app.Run();
