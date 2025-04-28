using ShopManagement.Interfaces.Category;
using ShopManagement.Interfaces.Customer;
using ShopManagement.Interfaces.Employee;
using ShopManagement.Interfaces.Product;
using ShopManagement.Interfaces.Sale;
using ShopManagement.Interfaces.Supplier;
using ShopManagement.Repositories.Category;
using ShopManagement.Repositories.Customer;
using ShopManagement.Repositories.Employee;
using ShopManagement.Repositories.Product;
using ShopManagement.Repositories.Sale;
using ShopManagement.Repositories.Supplier;

var builder = WebApplication.CreateBuilder(args);
var MyAllowSpecificOrigins = "AllowAllOrigins";
builder.Services.AddCors(options =>
{
    options.AddPolicy(MyAllowSpecificOrigins,
                      builder =>
                      {
                          //builder.WithOrigins("http://localhost:4200",
                          //                    "http://www.contoso.com");
                          builder.AllowAnyOrigin();
                          builder.AllowAnyHeader();
                          builder.AllowAnyMethod();
                      });
});


// Listen on all network interfaces (LAN accessible)
//;builder.WebHost.UseUrls("http://192.168.0.111:5000");

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ICategoriesRepository, CategoriesRepository>();
builder.Services.AddScoped<IEmployeesRepository, EmployeesRepository>();
builder.Services.AddScoped<ISuppliersRepository, SuppliersRepository>();
builder.Services.AddScoped<IProductsRepository, ProductsRepository>();
builder.Services.AddScoped<ICustomersRepository, CustomersRepository>();
builder.Services.AddScoped<ISalesRepository, SalesRepository>();
builder.Services.AddScoped<ISaleDetailsRepository, SaleDetailsRepository>();


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

app.UseCors(MyAllowSpecificOrigins);
app.Run();
