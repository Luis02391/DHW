using DWHNorthwindOrders.Context;
using DWHNorthwindOrders.Load;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

class Program
{
    static void Main(string[] args)
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .Build();

        var northwindConnectionString = configuration.GetConnectionString("Northwind");
        var dataWarehouseConnectionString = configuration.GetConnectionString("DataWarehouse");

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