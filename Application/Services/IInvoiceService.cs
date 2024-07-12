namespace PruebasTecnicas.Application.Services
{
    public interface IInvoiceService
    {
        InvoiceDTO GetInvoiceById(int id);
        void AddInvoice(InvoiceDTO invoice);
        void UpdateInvoice(InvoiceDTO invoice);
        void DeleteInvoice(int id);
    }
}