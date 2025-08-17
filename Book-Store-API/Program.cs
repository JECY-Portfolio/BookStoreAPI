using Book_Store_API.Data;
using Book_Store_API.Repository.AuthorsRepo;
using Book_Store_API.Repository.BooksRepo;
using Book_Store_API.Repository.CategoriesRepo;
using Book_Store_API.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

//Register Repositories
builder.Services.AddScoped<IBooksRepository, BooksRepository>();
builder.Services.AddScoped<IAuthorsRepository, AuthorsRepository>();
//builder.Services.AddScoped<ICategoriesRepository, CategoriesRepository>();


//Register Services
builder.Services.AddScoped<IBooksService, BookService>();
builder.Services.AddScoped<IAuthorsService, AuthorService>();


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
