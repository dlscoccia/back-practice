using Microsoft.EntityFrameworkCore;

namespace Tarker.Booking.Application.Database.Bookings.Queries.GetBookingsByType
{
    public class GetBookingsByTypeQuery : IGetBookingsByTypeQuery
    {
        private readonly IDatabaseService _databaseService;

        public GetBookingsByTypeQuery(IDatabaseService databaseService)
        {
            _databaseService = databaseService;
        }

        public async Task<List<GetBookingsByTypeModel>> Execute(string type)
        {
            var results = await (from booking in _databaseService.Booking
                                 join customer in _databaseService.Customer
                                 on booking.CustomerId equals customer.CustomerId
                                 where booking.Type == type
                                 select new GetBookingsByTypeModel
                                 {
                                     RegisterDate = booking.RegisterDate,
                                     Code = booking.Code,
                                     Type = booking.Type,
                                     CustomerFullName = customer.FullName,
                                     CustomerDocumentNumber = customer.DocumentNumber,
                                 }
                                 ).ToListAsync();

            return results;
        }
    }
}
