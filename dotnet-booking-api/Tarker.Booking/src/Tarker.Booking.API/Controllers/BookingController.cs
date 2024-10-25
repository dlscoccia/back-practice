using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Tarker.Booking.Application.Database.Bookings.Commands.CreateBooking;
using Tarker.Booking.Application.Database.Bookings.Queries.GetAllBookings;
using Tarker.Booking.Application.Database.Bookings.Queries.GetBookingsByDocumentNumber;
using Tarker.Booking.Application.Database.Bookings.Queries.GetBookingsByType;
using Tarker.Booking.Application.Exceptions;
using Tarker.Booking.Application.Features;

namespace Tarker.Booking.API.Controllers
{
    [Route("api/v1/booking")]
    [ApiController]
    [TypeFilter(typeof(ExceptionsManager))]
    public class BookingController : ControllerBase
    {
        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] CreateBookingModel model, 
                                                [FromServices] ICreateBookingCommand createBookingCommand,
                                                [FromServices] IValidator<CreateBookingModel> validator)
        {
            var validate = await validator.ValidateAsync(model);

            if (!validate.IsValid)
                return StatusCode(StatusCodes.Status400BadRequest, ResponseApiService.Response(StatusCodes.Status400BadRequest, validate.Errors));

            var data = await createBookingCommand.Execute(model);

            return StatusCode(StatusCodes.Status201Created, ResponseApiService.Response(StatusCodes.Status201Created, data));
        }

        [HttpGet("get-all")]
        public async Task<IActionResult> GetAll([FromServices] IGetAllBookingsQuery getAllBookingQuery)
        {

            var data = await getAllBookingQuery.Execute();

            if (data == null || data.Count == 0)
                return StatusCode(StatusCodes.Status204NoContent, ResponseApiService.Response(StatusCodes.Status204NoContent));

            return StatusCode(StatusCodes.Status200OK, ResponseApiService.Response(StatusCodes.Status200OK, data));

        }

        [HttpGet("get-by-document")]
        public async Task<IActionResult> GetById([FromQuery] string documentNumber, [FromServices] IGetBookingsByDocumentNumberQuery getBookingByDocument)
        {
            if (string.IsNullOrEmpty(documentNumber))
                return StatusCode(StatusCodes.Status400BadRequest, ResponseApiService.Response(StatusCodes.Status400BadRequest));

            var data = await getBookingByDocument.Execute(documentNumber);

            if (data == null)
                return StatusCode(StatusCodes.Status404NotFound, ResponseApiService.Response(StatusCodes.Status404NotFound));

            return StatusCode(StatusCodes.Status200OK, ResponseApiService.Response(StatusCodes.Status200OK, data));
        }


        [HttpGet("get-by-type")]
        public async Task<IActionResult> GetById([FromQuery] string type, [FromServices] IGetBookingsByTypeQuery getBookingByType)
        {
            if (string.IsNullOrEmpty(type))
                return StatusCode(StatusCodes.Status400BadRequest, ResponseApiService.Response(StatusCodes.Status400BadRequest));

            var data = await getBookingByType.Execute(type);

            if (data == null)
                return StatusCode(StatusCodes.Status404NotFound, ResponseApiService.Response(StatusCodes.Status404NotFound));

            return StatusCode(StatusCodes.Status200OK, ResponseApiService.Response(StatusCodes.Status200OK, data));
        }
    }
}
