using AutoMapper;
using Tarker.Booking.Domain.Entities.User;
using Tarker.Booking.Domain.Entities.Customer;
using Tarker.Booking.Application.Database.User.Commands.CreateUser;
using Tarker.Booking.Application.Database.User.Commands.UpdateUser;
using Tarker.Booking.Application.Database.User.Queries.GetAllUser;
using Tarker.Booking.Application.Database.User.Queries.GetUserById;
using Tarker.Booking.Application.Database.User.Queries.GetUserByUserNameAndPassword;
using Tarker.Booking.Application.Database.Customer.Commands.CreateCustomer;
using Tarker.Booking.Application.Database.Customer.Commands.UpdateCustomer;
using Tarker.Booking.Application.Database.Customer.Queries.GetAllCustomer;
using Tarker.Booking.Application.Database.Customer.Queries.GetCustomerById;
using Tarker.Booking.Application.Database.Customer.Queries.GetCustomerByDocument;
using Tarker.Booking.Domain.Entities.Booking;
using Tarker.Booking.Application.Database.Bookings.Commands.CreateBooking;

namespace Tarker.Booking.Application.Configuration
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            #region User
            CreateMap<UserEntity, CreateUserModel>().ReverseMap();  
            CreateMap<UserEntity, UpdateUserModel>().ReverseMap();  
            CreateMap<UserEntity, GetAllUserModel>().ReverseMap();  
            CreateMap<UserEntity, GetUserByIdModel>().ReverseMap();  
            CreateMap<UserEntity, GetUserByUserNameAndPasswordModel>().ReverseMap();
            #endregion

            #region Customer
            CreateMap<CustomerEntity, CreateCustomerModel>().ReverseMap();
            CreateMap<CustomerEntity, UpdateCustomerModel>().ReverseMap();
            CreateMap<CustomerEntity, GetAllCustomerModel>().ReverseMap();
            CreateMap<CustomerEntity, GetCustomerByIdModel>().ReverseMap();
            CreateMap<CustomerEntity, GetCustomerByDocumentModel>().ReverseMap();
            #endregion

            #region Booking
            CreateMap<BookingEntity, CreateBookingModel>().ReverseMap();
            #endregion
        }
    }
}
