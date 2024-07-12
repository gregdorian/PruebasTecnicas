namespace PruebasTecnicas.Domain.Repositories
{
    public interface IInvoiceRepository
    {
        Invoice GetInvoiceById(int id);
        void AddInvoice(Invoice invoice);
        void UpdateInvoice(Invoice invoice);
        void DeleteInvoice(int id);
    }
}