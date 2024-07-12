using System;

namespace Domain.Entities
{
    [Table("Customers")]
    public class Customer
    {
        private int _idCustomer;
        private string _customerCode;
        private string _customerNames;
        private string _customerAddress;
        private string _customerTelephone;
        private string _customerDescription;
        private DateTime _dateIn;

        public int IdCustomer
        {
            get => _idCustomer;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("IdCustomers debe ser mayor a cero.");
                }
                _idCustomer = value;
            }
        }

        public string CustomerCode
        {
            get => _customerCode;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("CustomerCode No puedes ser nulo o vacio.");
                }
                _customerCode = value;
            }
        }

        public string CustomerNames
        {
            get => _customerNames;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("CustomerNames cannot be null or empty.");
                }
                _customerNames = value;
            }
        }

        public string CustomerAddress
        {
            get => _customerAddress;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("CustomerAddress cannot be null or empty.");
                }
                _customersAddress = value;
            }
        }

        public string CustomerTelephone
        {
            get => _customerTelephone;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("CustomerTelephone cannot be null or empty.");
                }
                _customerTelephone = value;
            }
        }

        public string CustomerDescription
        {
            get => _customerDescription;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("CustomerDescription cannot be null or empty.");
                }
                _customerDescription = value;
            }
        }

        public DateTime DateIn
        {
            get => _dateIn;
            set
            {
                if (value > DateTime.Now)
                {
                    throw new ArgumentException("DateIn cannot be in the future.");
                }
                _dateIn = value;
            }
        }
    }
}
