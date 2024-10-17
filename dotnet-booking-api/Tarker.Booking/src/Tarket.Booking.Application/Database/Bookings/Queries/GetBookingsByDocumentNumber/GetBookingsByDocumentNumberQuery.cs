using Microsoft.EntityFrameworkCore;

namespace Tarker.Booking.Application.Database.Bookings.Queries.GetBookingsByDocumentNumber
{
    public class GetBookingsByDocumentNumberQuery : IGetBookingsByDocumentNumberQuery
    {
        private readonly IDatabaseService _databaseService;

        public GetBookingsByDocumentNumberQuery(IDatabaseService databaseService)
        {
            _databaseService = databaseService;
        }

        public async Task<List<GetBookingsByDocumentNumberModel>> Execute(string documentNumber)
        {
            var results = await (from booking in _databaseService.Booking
                                 join customer in _databaseService.Customer
                                 on booking.CustomerId equals customer.CustomerId
                                 where customer.DocumentNumber == documentNumber
                                 select new GetBookingsByDocumentNumberModel
                                 {
                                     Code = booking.Code,
                                     RegisterDate = booking.RegisterDate,
                                     Type = booking.Type
                                 }).ToListAsync();

            return results;
        }
    }
}
