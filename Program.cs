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

//This is an endpoint that returns a list of weather forecasts.
//The forecasts are generated using the Enumerable.Range method.
//The forecasts are returned as a JSON array.

app.MapGet("/weatherforecast", () =>
{
    var forecast =  Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast");

app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
