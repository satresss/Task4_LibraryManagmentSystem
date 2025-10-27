using Task4_LibraryManagmentSystem.Interfaces;
using Task4_LibraryManagmentSystem.Models;
using Task4_LibraryManagmentSystem.Repositories;
using Task4_LibraryManagmentSystem.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<List<Author>>();
builder.Services.AddSingleton<List<Book>>();

builder.Services.AddSingleton<IAuthorRepository, AuthorRepository>();
builder.Services.AddSingleton<IBookRepository, BookRepository>();

builder.Services.AddSingleton<IAuthorService, AuthorService>();
builder.Services.AddSingleton<IBookService, BookService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();
app.Run();
