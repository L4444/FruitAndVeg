using FruitAndVegApp;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddDbContext<FiveADayContext>(options => options.UseSqlite("Data Source=FiveADay.db"));
Console.WriteLine("FiveADayContext Service added");
builder.Services.AddScoped<FiveADayService>();
Console.WriteLine("FiveADayService Service added");
var app = builder.Build();
Console.WriteLine("Is this a new request???");
using (var scope = app.Services.CreateScope())
{
    Console.WriteLine("Check if we need to create and seed a database.");
    var db = scope.ServiceProvider.GetRequiredService<FiveADayContext>();
    db.Database.EnsureCreated();


    if (!db.FiveADays.Any())
    {

        for (int i = 0; i < 5; i++)
        {
            db.Add(new FiveADay { Name = $"FRUIT{i}", Stars = 4 });
        }

        db.SaveChanges();


    }


}



// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.Use(async (context, next) =>
{
    Console.WriteLine($"{context.Request.Method} {context.Request.Path}");
    await next();
    //Console.WriteLine($"{context.Request.Method} {context.Request.Path} {context.Response.StatusCode}");

});

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();
app.MapRazorPages()
   .WithStaticAssets();

app.Run();
