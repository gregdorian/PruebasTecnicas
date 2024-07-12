namespace PruebasTecnicas.Application.Services
{
    public class InvoiceService : IInvoiceService
    {
        private readonly IInvoiceRepository _invoiceRepository;

        public InvoiceService(IInvoiceRepository invoiceRepository)
        {
            _invoiceRepository = invoiceRepository;
        }

        public InvoiceDTO GetInvoiceById(int id)
        {
            var invoice = _invoiceRepository.GetInvoiceById(id);
            return new InvoiceDTO
            {
                Id = invoice.Id,
                Amount = invoice.Amount,
                // Map other fields
            };
        }

        public void AddInvoice(InvoiceDTO invoiceDto)
        {
            var invoice = new Invoice
            {
                Amount = invoiceDto.Amount,
                // Map other fields
            };
            _invoiceRepository.AddInvoice(invoice);
        }

        public void UpdateInvoice(InvoiceDTO invoiceDto)
        {
            var invoice = new Invoice
            {
                Id = invoiceDto.Id,
                Amount = invoiceDto.Amount,
                // Map other fields
            };
            _invoiceRepository.UpdateInvoice(invoice);
        }

        public void DeleteInvoice(int id)
        {
            _invoiceRepository.DeleteInvoice(id);
        }
    }
}