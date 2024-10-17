namespace Tarker.Booking.Application.Database.Customer.Queries.GetCustomerByDocument
{
    public interface IGetCustomerByDocumentQuery
    {
        Task<GetCustomerByDocumentModel> Execute(string customerDocument);
    }
}
