using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using MovieAPIDemo.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<MovieDbContext>(options => 
    options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddControllers();
// Add CORS policy
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        builder =>
        {
            builder.AllowAnyOrigin()    // Cho phép t?t c? ngu?n g?c (Origin)
                   .AllowAnyMethod()    // Cho phép t?t c? các ph??ng th?c HTTP (GET, POST, PUT, DELETE, v.v.)
                   .AllowAnyHeader();   // Cho phép t?t c? các header
        });
});

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
// Enable CORS
app.UseCors("AllowAll");
app.UseAuthorization();
app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(@"C:\to-delete"),
    RequestPath = "/StaticFiles"
});

app.MapControllers();

app.Run();
