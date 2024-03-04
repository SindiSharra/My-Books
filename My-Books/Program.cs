using My_Books.Data;
using Microsoft.EntityFrameworkCore;
using My_Books.Data.Services;
using My_Books.Data.ViewModels;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(
builder.Configuration.GetConnectionString("DefaultConnectionString")
));
builder.Services.AddTransient<BooksService>();
builder.Services.AddTransient<AuthorsService>();
builder.Services.AddTransient<PublishersSerivce>();

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

// Exception Handling 
//app.ConfigureBuildInExceptionHandler();
app.ConfigureCustomExceptionHandler();

app.MapControllers();

//AppDbInitializer.Seed(app);

app.Run();
