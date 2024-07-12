namespace Domain.Entities
{
    public class LineInvoice
    {
        private decimal _price;
        private int _amount;
        private decimal _discount;

        public decimal Price
        {
            get { return _price; }
            set
            {
                if (value < 0) throw new ArgumentOutOfRangeException("price no puede ser negativo");
                _price = value;
            }
        }

        public int Amount
        {
            get { return _amount; }
            set
            {
                if (value < 0) throw new ArgumentOutOfRangeException("Amount no puede ser negativa");
                _amount = value;
            }
        }

        public decimal Discount
        {
            get { return _discount; }
            set
            {
                if (value < 0 || value > 100) throw new ArgumentOutOfRangeException("Discount debe estar entre 0 y 100");
                _discount = value;
            }
        }

        public decimal Subtotal
        {
            get
            {
                return Math.Round((price * Amount) * (1 - Discount / 100), 2);
            }
        }
    }
}