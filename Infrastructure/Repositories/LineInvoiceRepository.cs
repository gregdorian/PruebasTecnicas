using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Domain.Entities;

namespace PruebasTecnicas.Infrastructure.Repositories
{

    public class LineInvoiceRepository : Repository<LineInvoice>
    {
        public LineInvoiceRepository(string connectionString) : base(connectionString) { }

        protected override string GetTableName() => "LineInvoices";

        protected override string GetColumnNames() => "IdLineInvoice, InvoiceId, ProductId, Price, Amount, Discount";

        protected override string GetParameterNames() => "@IdLineInvoice, @InvoiceId, @ProductId, @Price, @Amount, @Discount";

        protected override string GetUpdateColumnNames() => "Price = @Price, Amount = @Amount, Discount = @Discount";

        protected override LineInvoice MapToEntity(IDataReader reader)
        {
            return new LineInvoice
            {
                IdLineInvoice = (int)reader["IdLineInvoice"],
                InvoiceId = (int)reader["InvoiceId"],
                ProductId = (int)reader["ProductId"],
                Price = (decimal)reader["Price"],
                Amount = (int)reader["Amount"],
                Discount = (decimal)reader["Discount"]
            };
        }
    }
}