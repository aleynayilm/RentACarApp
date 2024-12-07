using AutoMapper;
using Entities.DataTransferObjects;
using Entities.Models;

namespace RentACarApp.Api.Utilities.AutoMapper
{
    public class MappingProfile:Profile
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
               .ForMember(dest => dest.FuelTypeNavigation, opt => opt.MapFrom(src => new FuelType { Id = src.FuelType }))  // FuelType nesnesi
    .ForMember(dest => dest.GearTypeNavigation, opt => opt.MapFrom(src => new GearType { Id = src.GearType }))  // GearType nesnesi
    .ForMember(dest => dest.Dealership, opt => opt.MapFrom(src => new Dealership { Id = src.DealershipId }))  // Dealership nesnesi
    .ForMember(dest => dest.CreatedAt, opt => opt.Ignore());
        }
    }
}
