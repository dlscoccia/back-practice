using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using Tarker.Booking.Application.Database.Customer.Commands.CreateCustomer;
using Tarker.Booking.Application.Database.Customer.Commands.DeleteCustomer;
using Tarker.Booking.Application.Database.Customer.Commands.UpdateCustomer;
using Tarker.Booking.Application.Database.Customer.Queries.GetAllCustomer;
using Tarker.Booking.Application.Database.Customer.Queries.GetCustomerByDocument;
using Tarker.Booking.Application.Database.Customer.Queries.GetCustomerById;
using Tarker.Booking.Application.Exceptions;
using Tarker.Booking.Application.Features;

namespace Tarker.Booking.API.Controllers
{
    [Route("api/v1/customer")]
    [ApiController]
    [TypeFilter(typeof(ExceptionsManager))]
    public class CustomerController : ControllerBase
    {

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] CreateCustomerModel model,
                                                [FromServices] ICreateCustomerCommand createCustomerCommand,
                                                [FromServices] IValidator<CreateCustomerModel> validator)
        {
            var validate = await validator.ValidateAsync(model);

            if (!validate.IsValid)
                return StatusCode(StatusCodes.Status400BadRequest, ResponseApiService.Response(StatusCodes.Status400BadRequest, validate.Errors));

            var data = await createCustomerCommand.Execute(model);

            return StatusCode(StatusCodes.Status201Created, ResponseApiService.Response(StatusCodes.Status201Created, data));
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update([FromBody] UpdateCustomerModel model,
                                             [FromServices] IUpdateCustomerCommand updateCustomerCommand,
                                             [FromServices] IValidator<UpdateCustomerModel> validator)
        {
            var validate = await validator.ValidateAsync(model);

            if (!validate.IsValid)
                return StatusCode(StatusCodes.Status400BadRequest, ResponseApiService.Response(StatusCodes.Status400BadRequest, validate.Errors));

            var data = await updateCustomerCommand.Execute(model);

            return StatusCode(StatusCodes.Status202Accepted, ResponseApiService.Response(StatusCodes.Status202Accepted, data));
        }

        [HttpDelete("delete/{customerId}")]
        public async Task<IActionResult> Delete(int customerId,
                                [FromServices] IDeleteCustomerCommand deleteCustomerCommand)
        {
            if (customerId == 0)
                return StatusCode(StatusCodes.Status400BadRequest, ResponseApiService.Response(StatusCodes.Status400BadRequest));

            var data = await deleteCustomerCommand.Execute(customerId);

            if (!data)
                return StatusCode(StatusCodes.Status404NotFound, ResponseApiService.Response(StatusCodes.Status404NotFound));

            return StatusCode(StatusCodes.Status200OK, ResponseApiService.Response(StatusCodes.Status200OK, data));
        }

        [HttpGet("get-all")]
        public async Task<IActionResult> GetAll([FromServices] IGetAllCustomerQuery getAllCustomerQuery)
        {

            var data = await getAllCustomerQuery.Execute();

            if (data == null || data.Count == 0)
                return StatusCode(StatusCodes.Status204NoContent, ResponseApiService.Response(StatusCodes.Status204NoContent));

            return StatusCode(StatusCodes.Status200OK, ResponseApiService.Response(StatusCodes.Status200OK, data));

        }

        [HttpGet("get-by-id/{customerId}")]
        public async Task<IActionResult> GetById(int customerId, [FromServices] IGetCustomerByIdQuery getCustomerById)
        {
            if (customerId == 0)
                return StatusCode(StatusCodes.Status400BadRequest, ResponseApiService.Response(StatusCodes.Status400BadRequest));

            var data = await getCustomerById.Execute(customerId);

            if (data == null)
                return StatusCode(StatusCodes.Status404NotFound, ResponseApiService.Response(StatusCodes.Status404NotFound));

            return StatusCode(StatusCodes.Status200OK, ResponseApiService.Response(StatusCodes.Status200OK, data));
        }

        [HttpGet("get-by-document/{documentNumber}")]
        public async Task<IActionResult> GetById(string documentNumber, [FromServices] IGetCustomerByDocumentQuery getCustomerByDocument)
        {
            if (string.IsNullOrEmpty(documentNumber))
                return StatusCode(StatusCodes.Status400BadRequest, ResponseApiService.Response(StatusCodes.Status400BadRequest));

            var data = await getCustomerByDocument.Execute(documentNumber);

            if (data == null)
                return StatusCode(StatusCodes.Status404NotFound, ResponseApiService.Response(StatusCodes.Status404NotFound));

            return StatusCode(StatusCodes.Status200OK, ResponseApiService.Response(StatusCodes.Status200OK, data));
        }

    }
}
