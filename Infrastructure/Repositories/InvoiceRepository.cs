using System.Data;
using System.Data.SqlClient;
using PruebasTecnicas.Domain.Entities;
using PruebasTecnicas.Domain.Repositories;

namespace PruebasTecnicas.Infrastructure.Repositories
{

    public class InvoiceRepository : Repository<Invoice>
{
    public InvoiceRepository(string connectionString) : base(connectionString) { }

    protected override string GetTableName() => "Invoices";

    protected override string GetColumnNames() => "IdInvoice, IdCustomer, InvoiceNumber, InvoiceDate, CostumerCode, Tax, Total, SubTotal";

    protected override string GetParameterNames() => "@IdInvoice, @IdCustomer, @InvoiceNumber, @InvoiceDate, @CostumerCode, @Tax, @Total, @SubTotal";

    protected override string GetUpdateColumnNames() => "IdCustomer = @IdCustomer, InvoiceNumber = @InvoiceNumber, InvoiceDate = @InvoiceDate, CostumerCode = @CostumerCode, Tax = @Tax, Total = @Total, SubTotal = @SubTotal";

    protected override Invoice MapToEntity(IDataReader reader)
    {
        return new Invoice
        {
            IdInvoice = (int)reader["IdInvoice"],
            IdCustomer = (int)reader["IdCustomer"],
            InvoiceNumber = (string)reader["InvoiceNumber"],
            InvoiceDate = (string)reader["InvoiceDate"],
            CostumerCode = (string)reader["CostumerCode"],
            Tax = (decimal)reader["Tax"],
            Total = (decimal)reader["Total"],
            SubTotal = (decimal)reader["SubTotal"],
            Lineas = GetLineasInvoice((int)reader["IdInvoice"])
        };
    }

    private List<LineInvoice> GetLineasInvoice(int idInvoice)
    {
        var lineInvoiceRepository = new LineInvoiceRepository(connectionString);
        return lineInvoiceRepository.GetAll().Where(li => li.InvoiceId == idInvoice).ToList();
    }
}
}
