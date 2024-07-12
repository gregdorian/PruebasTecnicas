using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    [Table("Invoices")]
    public class Invoice
    {
        public Invoice()
        {
           this.Lineas = new List<LineInvoice>();
        }
        public int IdInvoice { get; set; }

        public int IdCustomer { get; set; }

        public string InvoiceNumber { get; set; }

        public string InvoiceDate { get; set; }

        public string CostumerCode { get; set; }

        public decimal Tax { get; set; }

        public decimal Total { get; set; }

        public List<LineInvoice> Line { get; set; }

        public decimal SubTotal { get; set; }

    }
}
