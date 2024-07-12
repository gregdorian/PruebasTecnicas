// Lógica del Dominio

public class InvoiceService
{
    private readonly IRepository<Invoice> _invoiceRepository;
    private readonly IRepository<LineInvoice> _lineInvoiceRepository;

    public InvoiceService(IRepository<Invoice> invoiceRepository, IRepository<LineInvoice> lineInvoiceRepository)
    {
        _invoiceRepository = invoiceRepository;
        _lineInvoiceRepository = lineInvoiceRepository;
    }

    public void CreateInvoice(Invoice invoice)
    {
        // Validar la factura
        if (!invoice.IsValid())
        {
            throw new InvalidOperationException("La factura no es válida");
        }

        // Crear la factura
        _invoiceRepository.Add(invoice);

        // Crear las líneas de la factura
        foreach (var line in invoice.Lines)
        {
            _lineInvoiceRepository.Add(line);
        }
    }
}

// Aplicación

public class InvoiceController
{
    private readonly InvoiceService _invoiceService;

    public InvoiceController(InvoiceService invoiceService)
    {
        _invoiceService = invoiceService;
    }

    public void CreateInvoice(InvoiceDTO invoiceDTO)
    {
        // Crear la factura
        var invoice = new Invoice
        {
            InvoiceNumber = invoiceDTO.InvoiceNumber,
            InvoiceDate = invoiceDTO.InvoiceDate,
            CustomerName = invoiceDTO.CustomerName,
            CustomerAddress = invoiceDTO.CustomerAddress,
            TotalAmount = invoiceDTO.TotalAmount
        };

        // Crear las líneas de la factura
        foreach (var lineDTO in invoiceDTO.Lines)
        {
            var line = new LineInvoice
            {
                Description = lineDTO.Description,
                Quantity = lineDTO.Quantity,
                UnitPrice = lineDTO.UnitPrice,
                LineTotal = lineDTO.LineTotal
            };
            invoice.Lines.Add(line);
        }

        // Crear la factura
        _invoiceService.CreateInvoice(invoice);
    }
}

// DTOs

public class InvoiceDTO
{
    public string InvoiceNumber { get; set; }
    public DateTime InvoiceDate { get; set; }
    public string CustomerName { get; set; }
    public string CustomerAddress { get; set; }
    public decimal TotalAmount { get; set; }
    public List<LineInvoiceDTO> Lines { get; set; }
}

public class LineInvoiceDTO
{
    public string Description { get; set; }
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal LineTotal { get; set; }
}