using DWHNorthwindOrders.Context;
using DWHNorthwindOrders.Entities.DWH;

namespace DWHNorthwindOrders.Load
{
    public class OperationHandler
    {
        private readonly DbContextNw _dbContextNw;
        private readonly DbContextDwh _dbContextDwh;

        public OperationHandler(DbContextNw dbContextNw, DbContextDwh dbContextDwh)
        {
            _dbContextNw = dbContextNw;
            _dbContextDwh = dbContextDwh;
        }
        
        public void LoadCategories()
        {
            try
            {
                var categories = _dbContextNw.Categories.Select(c => new DimCategory
                {
                    CategoryID = c.CategoryID,
                    CategoryName = c.CategoryName,
                    Description = c.Description,
                }).ToList();
                
                _dbContextDwh.DimCategories.AddRange(categories);
                _dbContextDwh.SaveChanges();
                Console.WriteLine("Categories Loaded");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error: {e.Message}");
            }
        }
        
        public void LoadEmployees()
        {
            try
            {
                var employee = _dbContextNw.Employees.Select(c => new DimEmployee
                {
                    EmployeeID = c.EmployeeId,
                    LastName = c.LastName,
                    FirstName = c.FirstName,
                    Title = c.Title,
                    TitleOfCourtesy = c.TitleOfCourtesy,
                    BirthDate = c.BirthDate,
                    HireDate = c.HireDate,
                    Address = c.Address,
                    City = c.City,
                    Region = c.Region,
                    PostalCode = c.PostalCode,
                    Country = c.Country,
                    HomePhone = c.HomePhone,
                    Extension = c.Extension,
                    ReportsTo = c.ReportsTo,
                }).ToList();
                _dbContextDwh.DimEmployees.AddRange(employee);
                _dbContextDwh.SaveChanges();
                Console.WriteLine("Employees Loaded");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error: {e.Message}");
            }
        }

        public void LoadDimCustomers()
        {
            try
            {
                var customers = _dbContextNw.Customers.Select(c => new DimCustomer
                {
                    
                    CustomerID = c.CustomerID, 
                    CustomerName = c.CompanyName,  
                    ContactName = c.ContactName ,           
                    ContactTitle = c.ContactTitle ,       
                    Address = c.Address ,      
                    City = c.City,            
                    Region = c.Region ,       
                    PostalCode = c.PostalCode , 
                    Country = c.Country ,      
                    Phone = c.Phone ,          
                    Fax = c.Fax               
                }).ToList();
            
                _dbContextDwh.DimCustomers.AddRange(customers);
                _dbContextDwh.SaveChanges();
                Console.WriteLine("Customers Loaded");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error: {e.Message}");
            }
        }
        
        public void LoadProducts()
        {
            try
            {
                var products = _dbContextNw.Products.Select(c => new DimProduct
                {
                    ProductID = c.ProductId,
                    SupplierID = c.SupplierId,
                    CategoryID = c.CategoryId,
                    ProductName = c.ProductName,
                    Discontinued = c.Discontinued,
                    UnitPrice = c.UnitPrice,
                    UnitsInStock = c.UnitsInStock,
                    UnitsOnOrder = c.UnitsOnOrder,
                    QuantityPerUnit = c.QuantityPerUnit,
                    ReorderLevel = c.ReorderLevel,
                    
                }).ToList();

                _dbContextDwh.DimProducts.AddRange(products);
                _dbContextDwh.SaveChanges();
                Console.WriteLine("Products Loaded");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error: {e.Message}");
            }
        }
        

        public void LoadSuppliers()
        {
            try
            {
                var suppliers = _dbContextNw.Suppliers.Select(c => new DimSupplier
                {
                    SupplierID = c.SupplierId,
                    Address = c.Address,
                    City = c.City,
                    PostalCode = c.PostalCode,
                    Country = c.Country,
                    Fax = c.Fax,
                    ContactName = c.ContactName,
                    SupplierName = c.CompanyName,
                    HomePage = c.HomePage,
                    Phone = c.Phone,
                    ContactTitle = c.ContactTitle,
                    Region = c.Region
                });
                
                _dbContextDwh.DimSuppliers.AddRange(suppliers);
                _dbContextDwh.SaveChanges();
                Console.WriteLine("Suppliers Loaded");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error: {e.Message}");
            }
        }

        public void LoadShippers()
        {
            try
            {
                var shippers = _dbContextNw.Shippers.Select(c => new DimShipper
                {
                    ShipperID = c.ShipperId,
                    ShipperName = c.CompanyName,
                    Phone = c.Phone
                });
                _dbContextDwh.DimShippers.AddRange(shippers);
                _dbContextDwh.SaveChanges();
                Console.WriteLine("Shippers Loaded");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error: {e.Message}");
            }
        }
        
        
    }

}
