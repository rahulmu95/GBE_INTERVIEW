using BookShelf.BookRepository;
using BookShelf.Models;
using BookShelf.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<BookLibraryDatabaseContext>();
builder.Services.AddTransient<IBookRepository, BookRepository>();
builder.Services.AddScoped<BookService>();


var app = builder.Build();


using (var serviceScope = app.Services.GetRequiredService<IServiceScopeFactory>().CreateScope())
{
    var LibaryDatabseContext = serviceScope.ServiceProvider.GetService<BookLibraryDatabaseContext>();
    LibaryDatabseContext.Database.Migrate();
    using (var conn = LibaryDatabseContext.Database.GetDbConnection())
    {
        conn.Open();
    }
}
    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseStaticFiles();

app.MapGet("/", () =>
{
    return Results.File("wwwroot/index.html");
});

app.Run();

