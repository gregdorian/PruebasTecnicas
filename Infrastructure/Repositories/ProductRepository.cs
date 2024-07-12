using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Domain.Entities;

namespace PruebasTecnicas.Infrastructure.Repositories
{
    public class ProductRepository : Repository<Product>
    {
        public ProductRepository(string connectionString) : base(connectionString) { }

        protected override string GetTableName() => "Products";

        protected override string GetColumnNames() => "IdProduct, ProductCode, ProductName, UnitPrice, CostPrice, Stock, MinimalStock, DateIngreso";

        protected override string GetParameterNames() => "@IdProduct, @ProductCode, @ProductName, @UnitPrice, @CostPrice, @Stock, @MinimalStock, @DateIngreso";

        protected override string GetUpdateColumnNames() => "ProductCode = @ProductCode, ProductName = @ProductName, UnitPrice = @UnitPrice, CostPrice = @CostPrice, Stock = @Stock, MinimalStock = @MinimalStock, DateIngreso = @DateIngreso";

        protected override Product MapToEntity(IDataReader reader)
        {
            return new Product
            {
                IdProduct = (int)reader["IdProduct"],
                ProductCode = (string)reader["ProductCode"],
                ProductName = (string)reader["ProductName"],
                UnitPrice = (decimal)reader["UnitPrice"],
                CostPrice = (decimal)reader["CostPrice"],
                Stock = (int)reader["Stock"],
                MinimalStock = (int)reader["MinimalStock"],
                DateIngreso = (DateTime)reader["DateIngreso"]
            };
        }
    }
}
// Similar implementations for CategoryRepository and SupplierRepository can be added here.