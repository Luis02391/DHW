using DWHNorthwindOrders.Context;

namespace DWHNorthwindOrders.Load
{
    public class DataScrubber
    {
        private readonly DbContextDwh _contextDwh;

        public DataScrubber(DbContextDwh contextDwh)
        {
            _contextDwh = contextDwh;
        }

        public void CleanDimensions()
        {
            _contextDwh.DimCategories.RemoveRange(_contextDwh.DimCategories);
            _contextDwh.DimProducts.RemoveRange(_contextDwh.DimProducts);
            _contextDwh.DimCustomers.RemoveRange(_contextDwh.DimCustomers);
            _contextDwh.DimEmployees.RemoveRange(_contextDwh.DimEmployees);
            _contextDwh.DimSuppliers.RemoveRange(_contextDwh.DimSuppliers); 
            _contextDwh.DimShippers.RemoveRange(_contextDwh.DimShippers);
            _contextDwh.SaveChanges();
            
            Console.WriteLine("Cleared Dimensions");
        }
    }
}
