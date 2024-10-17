namespace Tarker.Booking.Application.Database.Bookings.Queries.GetAllBookings
{
    public interface IGetAllBookingsQuery
    {
        Task<List<GetAllBookingsModel>> Execute();
    }
}
