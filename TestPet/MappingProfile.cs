using AutoMapper;
using TestPet.Views;
using AnimeShop.Common.DBModels;

namespace TestPet;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<UserCredentialsView, User>();
        CreateMap<ProductView, Product>();
        CreateMap<AnimeShopView, AnimeShop.Common.DBModels.AnimeShop>();
    }
}