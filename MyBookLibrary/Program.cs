using MyBookLibrary.Models;
using MyBookLibrary.Repositories;
using MyBookLibrary.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


// Register your repository interface and implementation
builder.Services.AddSingleton<IBookRepository, BookRepository>(); // Register as singleton for simplicity, can be scoped or transient depending on requirements

// Optionally, specify the path to save the data
string dataFilePath = Path.Combine(Environment.CurrentDirectory, "data", "books.json");
builder.Services.AddSingleton(new DataSettings { FilePath = dataFilePath });

builder.Services.AddScoped<IBookService, BookService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Books}/{action=Index}/{id?}");

app.Run();
