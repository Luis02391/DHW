using DWHNorthwindOrders;
using DWHNorthwindOrders.Context;
using DWHNorthwindOrders.Load;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

class Program
{
    static void Main(string[] args)
    {
        // Cadenas de conexión definidas directamente en el código
        var northwindConnectionString =
            "Server=LAPTOP-V5ANFQ7D\\MSSQLSERVER8;Database=Northwind;Trusted_Connection=True;MultipleActiveResultSets=True;TrustServerCertificate=True;";
        var dataWarehouseConnectionString =
            "Server=LAPTOP-V5ANFQ7D\\MSSQLSERVER8;Database=DWHNorthWindOrders;Trusted_Connection=True;MultipleActiveResultSets=True;TrustServerCertificate=True;";


        // Configuración del contenedor de dependencias
        var services = new ServiceCollection();
        services.AddDbContext<DbContextNw>(options =>
            options.UseSqlServer(northwindConnectionString));
        services.AddDbContext<DbContextDwh>(options =>
            options.UseSqlServer(dataWarehouseConnectionString));

        var serviceProvider = services.BuildServiceProvider();
        
        var cleaner = new DataScrubber(serviceProvider.GetService<DbContextDwh>());
        cleaner.CleanDimensions();


        var etlProcessor = new OperationHandler(
            serviceProvider.GetService<DbContextNw>(),
            serviceProvider.GetService<DbContextDwh>());
        
        etlProcessor.LoadDimCustomers();
        etlProcessor.LoadEmployees();
        etlProcessor.LoadCategories();
        etlProcessor.LoadShippers();
        etlProcessor.LoadSuppliers();
        etlProcessor.LoadProducts();

    }
}
