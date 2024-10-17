
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Tarker.Booking.Application.Database.Customer.Queries.GetCustomerByDocument
{
    public class GetCustomerByDocumentQuery : IGetCustomerByDocumentQuery
    {
        private readonly IDatabaseService _databaseService;
        private readonly IMapper _mapper;

        public GetCustomerByDocumentQuery(IDatabaseService databaseService, IMapper mapper)
        {
            _databaseService = databaseService;
            _mapper = mapper;
        }

        public async Task<GetCustomerByDocumentModel> Execute(string customerDocument)
        {
            var entity = await _databaseService.Customer.FirstOrDefaultAsync(customer => customer.DocumentNumber  == customerDocument);

            return _mapper.Map<GetCustomerByDocumentModel>(entity);
        }
    }
}
