namespace Tarker.Booking.Application.Database.Bookings.Queries.GetBookingsByDocumentNumber
{
    public interface IGetBookingsByDocumentNumberQuery
    {
        Task<List<GetBookingsByDocumentNumberModel>> Execute(string documentNumber);
    }
}
