using System.Data;
using System.Data.SqlClient;
using PruebasTecnicas.Domain.Entities;
using PruebasTecnicas.Domain.Repositories;

namespace PruebasTecnicas.Infrastructure.Repositories
{

    public class CustomersRepository : Repository<Customers>
    {
        public CustomersRepository(string connectionString) : base(connectionString)
        {
        }

        protected override string GetTableName()
        {
            return "Customers";
        }

        protected override Customers MapToEntity(SqlDataReader reader)
        {
            return new Customers
            {
                IdCustomers = Convert.ToInt32(reader["IdCustomer"]),
                CustomersCode = reader["CustomerCode"].ToString(),
                CustomersNames = reader["CustomerNames"].ToString(),
                CustomersAddress = reader["CustomerAddress"].ToString(),
                CustomersTelephone = reader["CustomerTelephone"].ToString(),
                CustomersDescription = reader["CustomerDescription"].ToString(),
                DateIn = Convert.ToDateTime(reader["DateIn"])
            };
        }

        protected override string GetColumnNames()
        {
            return "IdCustomer, CustomerCode, CustomerNames, CustomerAddress, CustomerTelephone, CustomerDescription, DateIn";
        }

        protected override string GetParameterNames()
        {
            return "@IdCustomer, @CustomerCode, @CustomerNames, @CustomerAddress, @CustomerTelephone, @CustomerDescription, @DateIn";
        }

        protected override string GetUpdateColumnNames()
        {
            return "CustomerCode = @CustomerCode, CustomerNames = @CustomerNames, CustomerAddress = @CustomerAddress, CustomerTelephone = @CustomerTelephone, CustomerDescription = @CustomerDescription, DateIn = @DateIn";
        }
    }
}