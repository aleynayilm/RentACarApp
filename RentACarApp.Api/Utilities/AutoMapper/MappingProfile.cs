using AutoMapper;
using Entities.DataTransferObjects;
using Entities.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace RentACarApp.Api.Utilities.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CarDtoForUpdate, Car>()
           .ForMember(dest => dest.FuelType, opt => opt.MapFrom(src => src.FuelType))
    .ForMember(dest => dest.GearType, opt => opt.MapFrom(src => src.GearType))
    .ForMember(dest => dest.DealershipId, opt => opt.MapFrom(src => src.DealershipId))
    .ForMember(dest => dest.CreatedAt, opt => opt.Ignore());
            CreateMap<DealershipDtoForUpdate, Dealership>();
            CreateMap<AdminDtoForUpdate, Admin>()
            .ForMember(dest => dest.CreatedAt, opt => opt.Ignore());
            CreateMap<PaymentDtoForUpdate, Payment>()
                .ForMember(dest => dest.ReservationId, opt => opt.MapFrom(src => src.ReservationId))
                .ForMember(dest => dest.PaymentMethod, opt => opt.MapFrom(src => src.PaymentMethod))
                .ForMember(dest => dest.PaymentStatus, opt => opt.MapFrom(src => src.PaymentStatus))
                .ForMember(dest => dest.CreatedAt, opt => opt.Ignore());
            CreateMap<ReservationDtoForUpdate, Reservation>()
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
                .ForMember(dest => dest.CarId, opt => opt.MapFrom(src => src.CarId))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status))
                .ForMember(dest => dest.CreatedDate, opt => opt.Ignore());
            CreateMap<UserDtoForUpdate, User>()
                .ForMember(dest => dest.CreatedAt, opt => opt.Ignore());


            CreateMap<CarDtoForCreate, Car>()
                           .ForMember(dest => dest.FuelType, opt => opt.MapFrom(src => src.FuelType))
                .ForMember(dest => dest.GearType, opt => opt.MapFrom(src => src.GearType))
                .ForMember(dest => dest.DealershipId, opt => opt.MapFrom(src => src.DealershipId))
                .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
                .ForMember(dest => dest.FuelTypeNavigation, opt => opt.Ignore())
                .ForMember(dest => dest.GearTypeNavigation, opt => opt.Ignore())
                .ForMember(dest => dest.Dealership, opt => opt.Ignore());

            CreateMap<AdminDtoForCreate, Admin>()
                .ForMember(dest => dest.CreatedAt, opt => opt.Ignore());

            CreateMap<DealershipDtoForCreate, Dealership>();
            CreateMap<PaymentDtoForCreate, Payment>()
                 .ForMember(dest => dest.ReservationId, opt => opt.MapFrom(src => src.ReservationId))
                .ForMember(dest => dest.PaymentMethod, opt => opt.MapFrom(src => src.PaymentMethod))
                .ForMember(dest => dest.PaymentStatus, opt => opt.MapFrom(src => src.PaymentStatus))
                .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
                .ForMember(dest => dest.Reservation, opt => opt.Ignore())
                .ForMember(dest => dest.PaymentMethodNavigation, opt => opt.Ignore())
                .ForMember(dest => dest.PaymentStatusNavigation, opt => opt.Ignore());
            CreateMap<UserDtoForCreate, User>()
                .ForMember(dest => dest.CreatedAt, opt => opt.Ignore());
            CreateMap<ReservationsDtoForCreate, Reservation>()
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
                .ForMember(dest => dest.CarId, opt => opt.MapFrom(src => src.CarId))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status))
                .ForMember(dest => dest.CreatedDate, opt => opt.Ignore())
                .ForMember(dest => dest.User, opt => opt.Ignore())
                .ForMember(dest => dest.Car, opt => opt.Ignore())
                .ForMember(dest => dest.StatusNavigation, opt => opt.Ignore());


        }
    }
    
}
