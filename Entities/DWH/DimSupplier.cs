﻿namespace DWHNorthwindOrders.Entities.DWH;

public class DimSupplier
{
    public int SupplierID { get; set; }
    public string SupplierName { get; set; } = string.Empty;
    public string? ContactName { get; set; }
    public string? ContactTitle { get; set; }
    public string? Address { get; set; }
    public string? City { get; set; }
    public string? Region { get; set; }
    public string? PostalCode { get; set; }
    public string? Country { get; set; }
    public string? Phone { get; set; }
    public string? Fax { get; set; }
    public string? HomePage { get; set; }

}